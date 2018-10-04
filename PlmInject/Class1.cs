using EasyHook;
using ETCTool;
using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace PlmInject
{
    public class Main : IEntryPoint
    {
        private readonly PlmHookInterface Interface;
        private IntPtr HWND = IntPtr.Zero;
        private LocalHook IsZoomed;
        private LocalHook SetForegroundWindow;
        private LocalHook SetWindowTextW;
        private LocalHook Show_Window;

        public Main(RemoteHooking.IContext InContext, string InChannelName)
        {
            Interface = RemoteHooking.IpcConnectClient<PlmHookInterface>(InChannelName);
        }

        public void Run(RemoteHooking.IContext InContext, string InChannelName)
        {
            try
            {
                SetForegroundWindow =
                    LocalHook.Create(
                        LocalHook.GetProcAddress("swt-win32-3721.dll",
                            "_Java_org_eclipse_swt_internal_win32_OS_SetForegroundWindow@12"),
                        new SetForegroundWindow_delegate(SetForegroundWindow_Hooked), this);
                Show_Window = LocalHook.Create(LocalHook.GetProcAddress("user32.dll", "ShowWindow"),
                    new ShowWindow_delegate(ShowWindow_Hooked), this);
                IsZoomed = LocalHook.Create(
                    LocalHook.GetProcAddress("swt-win32-3721.dll",
                        "_Java_org_eclipse_swt_internal_win32_OS_IsZoomed@12"), new IsZoomed_delegate(IsZoomed_Hooked),
                    this);
                SetWindowTextW = LocalHook.Create(LocalHook.GetProcAddress("user32.dll", "SetWindowTextW"),
                    new SetWindowTextW_delegate(SetWindowTextW_Hooked), this);
                SetForegroundWindow.ThreadACL.SetExclusiveACL(new[] { 0 });
                Interface.Info($"安装成功,当前线程:{RemoteHooking.GetCurrentThreadId()}");
                RemoteHooking.WakeUpProcess();
            }
            catch (Exception ex)
            {
                Interface.Info($"安装错误,错误信息:{ex}");
                return;
            }

            try
            {
                while (true)
                {
                    Interface.Ping(out var Ping, InChannelName);
                    if (!Ping) break;
                    Thread.Sleep(1000);
                }
            }
            finally
            {
                SetForegroundWindow.Dispose();
                Show_Window.Dispose();
                IsZoomed.Dispose();
                SetWindowTextW.Dispose();
                LocalHook.Release();
            }
        }

        private bool SetWindowTextW_Hooked(IntPtr hwnd, IntPtr Cmd)
        {
            var This = (Main)HookRuntimeInfo.Callback;
            if (Marshal.PtrToStringAuto(Cmd) == "请确认") Interface.AutoPerformClick(hwnd);
            Show_Window.ThreadACL.SetExclusiveACL(new[] { 0 });
            IsZoomed.ThreadACL.SetExclusiveACL(new[] { 0 });
            SetWindowTextW.ThreadACL.SetExclusiveACL(new[] { 0 });
            return LocalHook.GetProcDelegate<SetWindowTextW_delegate>("user32.dll", "SetWindowTextW")(hwnd, Cmd);
        }

        private bool IsZoomed_Hooked(IntPtr hwnd)
        {
            var This = (Main)HookRuntimeInfo.Callback;
            if (This.HWND == hwnd && HWND != IntPtr.Zero) return false;

            var Ret = LocalHook.GetProcDelegate<IsZoomed_delegate>("swt-win32-3721.dll",
                "_Java_org_eclipse_swt_internal_win32_OS_IsZoomed@12");
            return Ret(hwnd);
        }

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hwnd, int cmd);

        private bool ShowWindow_Hooked(IntPtr hwnd, int Cmd)
        {
            if (Cmd == 3) Cmd = 8;
            return ShowWindow(hwnd, Cmd);
        }

        private bool SetForegroundWindow_Hooked(IntPtr hwnd)
        {
            var This = (Main)HookRuntimeInfo.Callback;
            HWND = hwnd;
            Show_Window.ThreadACL.SetInclusiveACL(new[] { 0 });
            IsZoomed.ThreadACL.SetInclusiveACL(new[] { 0 });
            SetWindowTextW.ThreadACL.SetInclusiveACL(new[] { 0 });
            return true;
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Auto, SetLastError = true)]
        private delegate bool SetForegroundWindow_delegate(IntPtr hwnd);

        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Auto, SetLastError = true)]
        private delegate bool IsZoomed_delegate(IntPtr hwnd);

        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Auto, SetLastError = true)]
        private delegate bool ShowWindow_delegate(IntPtr hwnd, int Cmd);

        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Auto, SetLastError = true)]
        private delegate bool SetWindowTextW_delegate(IntPtr hwnd, IntPtr Cmd);
    }
}