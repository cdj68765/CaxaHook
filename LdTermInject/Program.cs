using EasyHook;
using ETCTool;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace LdTermInject
{
    public class Main : IEntryPoint
    {
        private readonly LdTermInInterface Interface;

        private readonly TaskCompletionSource<uint> ShutdownResetEvent = new TaskCompletionSource<uint>();
        private LocalHook CreateHook;

        public Main(
            RemoteHooking.IContext InContext,
            string InChannelName)
        {
            Interface = RemoteHooking.IpcConnectClient<LdTermInInterface>(InChannelName);
        }

        public void Run(
            RemoteHooking.IContext InContext,
            string InChannelName)
        {
            try
            {
                CreateHook = LocalHook.Create(LocalHook.GetProcAddress("kernel32.dll", "LoadLibraryW"),
                    new GetSystemTimeAsFileTimeEx(GetSystemTimeAsFileTimeEx_Hooked), this);
                CreateHook.ThreadACL.SetExclusiveACL(new[] { 0 });
                RemoteHooking.WakeUpProcess();
                ExitProcess(ShutdownResetEvent.Task.Result);
            }
            catch (Exception ex)
            {
                Interface.Info($"安装错误,错误信息:{ex}");
            }
            finally
            {
                LocalHook.Release();
                CreateHook.Dispose();
            }
        }

        [DllImport("kernel32.dll")]
        private static extern void ExitProcess(uint uExitCode);

        private IntPtr GetSystemTimeAsFileTimeEx_Hooked(string LoadLibraryW)
        {
            var This = (Main)HookRuntimeInfo.Callback;
            try
            {
                var remoteDataHandle = (RemoteDataHandle)Activator.GetObject(typeof(RemoteDataHandle),
                    "ipc://EtcToolChannel/RemoteDataHandle");
                if (remoteDataHandle.OperaMode == "Open")
                {
                    var path = remoteDataHandle.FilePath;
                    This.Interface.RetOpenDate(remoteDataHandle.FilePath, File.ReadAllBytes(path),
                        remoteDataHandle.OperaMode);
                }
                else if (remoteDataHandle.OperaMode == "Decrypt")
                {
                    foreach (var VARIABLE in remoteDataHandle.FileList)
                        This.Interface.RetOpenDate(VARIABLE, File.ReadAllBytes(VARIABLE), remoteDataHandle.OperaMode);
                }
                else if (remoteDataHandle.OperaMode == "Copy")
                {
                    remoteDataHandle.CopyData = new Dictionary<string, byte[]>();
                    foreach (var VARIABLE in remoteDataHandle.FileList)
                        remoteDataHandle.AddToCopyData($@"\{Path.GetFileName(VARIABLE)}", File.ReadAllBytes(VARIABLE));
                }
            }
            catch (Exception E)
            {
                This.Interface.Info($"发生错误{E}");
            }
            finally
            {
                ShutdownResetEvent.TrySetResult(0);
            }

            return IntPtr.Zero;
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall,
            CharSet = CharSet.Auto,
            SetLastError = true)]
        private delegate IntPtr GetSystemTimeAsFileTimeEx(string LoadLibraryW);
    }
}