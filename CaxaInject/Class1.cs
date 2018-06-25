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
        private Stack<String> Queue = new Stack<String>();

        public Main(
            RemoteHooking.IContext InContext,
            String InChannelName)
        {
            // connect to host...
            Interface = RemoteHooking.IpcConnectClient<CaxaHook.HookDealWith>(InChannelName);
            //  Interface.Ping();
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

                CreateFileHook.ThreadACL.SetInclusiveACL(new Int32[] { 0 });
                //  CreateFileHook.ThreadACL.SetInclusiveACL(new Int32[] { 0 });
            }
            catch (Exception ExtInfo)
            {
                Interface.ReportException(ExtInfo);
                return;
            }

            Interface.IsInstalled(RemoteHooking.GetCurrentThreadId());
            RemoteHooking.WakeUpProcess();
            try
            {
                while (true)
                {
                    Thread.Sleep(500);
                    if (Queue.Count > 0)
                    {
                        String[] Package = null;

                        lock (Queue)
                        {
                            Package = Queue.ToArray();

                            Queue.Clear();
                        }

                        //  Interface.OnCreateFile(RemoteHooking.GetCurrentProcessId(), Package);
                    }
                    else
                    {
                        //  Interface.Ping(RemoteHooking.GetCurrentThreadId());
                    }
                }
            }
            catch
            {
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
                Main This = (Main)HookRuntimeInfo.Callback;

                lock (This.Queue)
                {
                    if (OldFile.EndsWith("$"))
                    {
                        NewFile = This.Interface.SaveChange(NewFile);
                    }
                    else if (OldFile.EndsWith("exb"))
                    {
                        return new IntPtr(0);
                    }

                    /*This.Queue.Push("[" + RemoteHooking.GetCurrentProcessId() + ":" +
                        RemoteHooking.GetCurrentThreadId() + "]: \"" + InFileName + "\"");
                    InFileName = InFileName.Replace("C", "D");*/
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