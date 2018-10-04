using EasyHook;
using ETCTool;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace CaxaInject
{
    internal struct STGOPTIONS
    {
        public ushort usVersion { get; set; }
        public ushort reserved { get; set; }
        public ulong ulSectorSize { get; set; }
        public string pwcsTemplateFile { get; set; }
    }

    public class Main : IEntryPoint
    {
        private readonly CaxaHookInterface Interface;
        private LocalHook CreateHook;

        public Main(
            RemoteHooking.IContext InContext,
            string InChannelName)
        {
            Interface = RemoteHooking.IpcConnectClient<CaxaHookInterface>(InChannelName);
        }

        public void Run(
            RemoteHooking.IContext InContext,
            string InChannelName)
        {
            try
            {
                CreateHook = LocalHook.Create(LocalHook.GetProcAddress("kernel32.dll", "MoveFileExW"),
                    new HookMoveFileEx(MoveFileEx_Hooked), this);
                Interface.Info($"安装成功,当前线程:{RemoteHooking.GetCurrentThreadId()}");
                RemoteHooking.WakeUpProcess();
                while (true)
                {
                    if (Interface.Ping(out var Ping, InChannelName)) CreateHook.ThreadACL.SetExclusiveACL(new[] { 0 });
                    if (!Ping) break;
                    Thread.Sleep(500);
                }
            }
            catch (Exception ex)
            {
                Interface.Info($"安装错误,错误信息:{ex}");
            }
            finally
            {
                CreateHook.Dispose();
                LocalHook.Release();
            }
        }

        private bool MoveFileEx_Hooked(string lpExistingFileName, string lpNewFileName, MoveFileFlags dwFlags)
        {
            var This = (Main)HookRuntimeInfo.Callback;
            if (Path.GetExtension(lpExistingFileName).ToLower() == ".exb") return true;
            if (Path.GetExtension(lpExistingFileName).ToLower() == ".es$")
            {
                lpNewFileName = This.Interface.GetNewPath(lpNewFileName);
                CreateHook.ThreadACL.SetExclusiveACL(new[] { 0 });
            }
            else
            {
                lpNewFileName = This.Interface.GetNewPath(lpNewFileName, lpExistingFileName);
            }

            var Ret = LocalHook.GetProcDelegate<HookMoveFileEx>("kernel32.dll", "MoveFileExW");
            return Ret(lpExistingFileName, lpNewFileName, dwFlags);
        }

        [Flags]
        private enum MoveFileFlags
        {
            MOVEFILE_REPLACE_EXISTING = 0x00000001,
            MOVEFILE_COPY_ALLOWED = 0x00000002,
            MOVEFILE_DELAY_UNTIL_REBOOT = 0x00000004,
            MOVEFILE_WRITE_THROUGH = 0x00000008,
            MOVEFILE_CREATE_HARDLINK = 0x00000010,
            MOVEFILE_FAIL_IF_NOT_TRACKABLE = 0x00000020
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall,
            CharSet = CharSet.Unicode,
            SetLastError = true)]
        private delegate bool HookMoveFileEx(
            string OldFile,
            string NewFile,
            MoveFileFlags dwFlags);
    }
}