using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EasyHook;

namespace CaxaInject
{
    public class Main : EasyHook.IEntryPoint
    {
        private CaxaHook.HookDealWith Interface;
        private LocalHook CreateFileHook;

        public Main(
            RemoteHooking.IContext InContext,
            String InChannelName)
        {
            Interface = RemoteHooking.IpcConnectClient<CaxaHook.HookDealWith>(InChannelName);
        }

        public void Run(
            RemoteHooking.IContext InContext,
            String InChannelName)
        {
            try
            {
                CreateFileHook = LocalHook.Create(
                    LocalHook.GetProcAddress("kernel32.dll", "MoveFileExW"),
                    new HookMoveFileEx(MoveFileEx_Hooked),
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
                    if (Interface.CheckHook(out bool Uninstall))
                    {
                        if (!CreateFileHook.ThreadACL.IsExclusive)
                        {
                            CreateFileHook.ThreadACL.SetExclusiveACL(new Int32[] {0});
                            Interface.info("Hook");
                        }
                    }
                    else
                    {
                        if (!CreateFileHook.ThreadACL.IsInclusive)
                        {
                            CreateFileHook.ThreadACL.SetInclusiveACL(new Int32[] {0});
                            Interface.info("UnHook");
                        }
                    }

                    if (Uninstall)
                    {
                        CreateFileHook.ThreadACL.SetInclusiveACL(new Int32[] {0});
                        CreateFileHook.Dispose();
                        LocalHook.Release();
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
        private delegate IntPtr HookMoveFileEx(
            String OldFile,
            String NewFile,
            UInt32 dwFlags);

        [DllImport("kernel32.dll",
            CharSet = CharSet.Unicode,
            SetLastError = true,
            CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr MoveFileExW(
            String OldFile,
            String NewFile,
            UInt32 dwFlags);

        private static IntPtr MoveFileEx_Hooked(
            String OldFile,
            String NewFile,
            UInt32 dwFlags)
        {
            try
            {
                Main This = (Main) HookRuntimeInfo.Callback;

                if (OldFile.EndsWith("$"))
                {
                    NewFile = This.Interface.SaveChange(NewFile);
                }
                else if (OldFile.EndsWith("exb"))
                {
                    return new IntPtr(0);
                }
            }
            catch
            {
            }
            return MoveFileExW(
                OldFile,
                NewFile,
                dwFlags);
        }
    }
}