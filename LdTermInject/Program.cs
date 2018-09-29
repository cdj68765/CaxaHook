using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using EasyHook;
using ETCTool;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

namespace LdTermInject
{
    public class Main : IEntryPoint
    {
        private readonly LdTermInInterface Interface;
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

                
                CreateHook.ThreadACL.SetExclusiveACL(new[] {0});
                Interface.Info($"安装成功,当前线程:{RemoteHooking.GetCurrentThreadId()}");
                RemoteHooking.WakeUpProcess();
                Thread.Sleep(1000);

            }
            catch (Exception ex)
            {
                Interface.Info($"安装错误,错误信息:{ex}");
            }
            finally
            {
                CreateHook.Dispose();

            }
            LocalHook.Release();
        }

        [DllImport("kernel32.dll")]
        static extern void ExitProcess(uint uExitCode);

        private IntPtr GetSystemTimeAsFileTimeEx_Hooked(string LoadLibraryW)
        {
            var This = (Main) HookRuntimeInfo.Callback;
            This.Interface.ReadFile();
            ExitProcess(0);
            var Ret = LocalHook.GetProcDelegate<GetSystemTimeAsFileTimeEx>("kernel32.dll", "LoadLibraryW");
            return IntPtr.Zero;
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall,
            CharSet = CharSet.Auto,
            SetLastError = true)]
        private delegate IntPtr GetSystemTimeAsFileTimeEx(string LoadLibraryW);
    }
}
