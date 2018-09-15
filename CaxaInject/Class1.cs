using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EasyHook;
using ETCTool;

namespace CaxaInject
{
    internal struct STGOPTIONS
    {
        public ushort usVersion { get; set; }
        public ushort reserved { get; set; }
        public ulong ulSectorSize { get; set; }
        public String pwcsTemplateFile { get; set; }
    }

    public class Main : IEntryPoint
    {
        private CaxaHookInterface Interface;

        public Main(
            RemoteHooking.IContext InContext,
            String InChannelName)
        {
            Interface = RemoteHooking.IpcConnectClient<CaxaHookInterface>(InChannelName);
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
            String OldFile,
            String NewFile,
            MoveFileFlags dwFlags);

        public void Run(
            RemoteHooking.IContext InContext,
            String InChannelName)
        {
            LocalHook CreateHook = null;
            try
            {
                CreateHook = LocalHook.Create(LocalHook.GetProcAddress("kernel32.dll", "MoveFileExW"), new HookMoveFileEx(MoveFileEx_Hooked), this);
                CreateHook.ThreadACL.SetExclusiveACL(new Int32[] { 0 });
                Interface.Info("安装成功");
                while (true)
                {
                    Interface.Ping(out bool Ping, InChannelName);
                    if (Ping == false) break;
                    Thread.Sleep(5000);
                }
            }
            catch (Exception ex)
            {
                Interface.Info(ex.ToString());
            }
            finally
            {
                CreateHook.Dispose();
            }
        }

        private bool MoveFileEx_Hooked(string lpExistingFileName, string lpNewFileName, MoveFileFlags dwFlags)
        {
            Main This = (Main)HookRuntimeInfo.Callback;
            if (Path.GetExtension(lpExistingFileName).ToLower() == ".exb")
            {
                return true;
            }
            if (Path.GetExtension(lpExistingFileName).ToLower() == ".es$")
            {
                lpNewFileName = This.Interface.GetNewPath(lpNewFileName);
            }

            var Ret = LocalHook.GetProcDelegate<HookMoveFileEx>("kernel32.dll", "MoveFileExW");
            return Ret(lpExistingFileName, lpNewFileName, dwFlags);
        }
    }
}