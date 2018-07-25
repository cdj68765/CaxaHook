using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EasyHook;

namespace PLMInject
{
    public class Main : EasyHook.IEntryPoint
    {
        private CaxaHook.HookPlmDealWith Interface;
        private LocalHook CreateFileHook;

        public Main(
            RemoteHooking.IContext InContext,
            String InChannelName)
        {
            Interface = RemoteHooking.IpcConnectClient<CaxaHook.HookPlmDealWith>(InChannelName);
        }

        public void Run(
            RemoteHooking.IContext InContext,
            String InChannelName)
        {
            try
            {
                CreateFileHook = LocalHook.Create(
                    LocalHook.GetProcAddress("user32.dll", "BringWindowToTop"),
                    new BringWindowToTopEx(BringWindowToTop_Hooked),
                    this);
            }
            catch (Exception ExtInfo)
            {
                Interface.ReportException(ExtInfo);
                return;
            }
            Interface.IsInstalled(RemoteHooking.GetCurrentThreadId());
            try
            {
                while (true)
                {
                    Thread.Sleep(500);
                    if (!CreateFileHook.ThreadACL.IsExclusive)
                    {
                        CreateFileHook.ThreadACL.SetExclusiveACL(new Int32[] {0});
                    }

                }
            }
            catch (Exception ExtInfo)
            {
                CreateFileHook.Dispose();
                LocalHook.Release();
                Interface.ReportException(ExtInfo);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall,
            CharSet = CharSet.Unicode,
            SetLastError = true)]
        private delegate bool BringWindowToTopEx(IntPtr hwnd);

        public static extern bool BringWindowToTop(IntPtr hwnd);

        private static bool BringWindowToTop_Hooked(IntPtr hwnd)
        {
            try
            {
             
            }
            catch
            {
            }

            return true;
        }
    }
}
