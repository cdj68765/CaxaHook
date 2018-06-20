using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using System.Threading;
using EasyHook;

namespace CaxaHook
{
    class Program
    {
        static void Main(string[] args)
        {
            int PID=-1;
            foreach (var disk in new ManagementObjectSearcher(new SelectQuery("Select * from Win32_Process")).Get())
            {
                if (disk["Name"].ToString().StartsWith("Em"))
                {
                    PID = int.Parse(disk["ProcessId"].ToString());
                }
            }
           
            if (PID == -1)
            {
                return;
            }
            var _Process = Process.GetProcessById(PID);
            if (_Process == null)
            {
                return;
            }

          new  Run(PID);
            //  new Hook(PID);
            while (true)
            {
                Thread.Sleep(100);
            }
        }
    }

    internal class Hook
    {
        private int pID;
        [UnmanagedFunctionPointer(CallingConvention.StdCall,
            CharSet = CharSet.Unicode,
            SetLastError = true)]
        delegate IntPtr HookCreateFile(
            String InFileName,
            UInt32 InDesiredAccess,
            UInt32 InShareMode,
            IntPtr InSecurityAttributes,
            UInt32 InCreationDisposition,
            UInt32 InFlagsAndAttributes,
            IntPtr InTemplateFile);

        // just use a P-Invoke implementation to get native API access from C# (this step is not necessary for C++.NET)
        [DllImport("kernel32.dll",
            CharSet = CharSet.Unicode,
            SetLastError = true,
            CallingConvention = CallingConvention.StdCall)]
        static extern IntPtr CreateFile(
            String InFileName,
            UInt32 InDesiredAccess,
            UInt32 InShareMode,
            IntPtr InSecurityAttributes,
            UInt32 InCreationDisposition,
            UInt32 InFlagsAndAttributes,
            IntPtr InTemplateFile);
        static IntPtr CreateFile_Hooked(
            String InFileName,
            UInt32 InDesiredAccess,
            UInt32 InShareMode,
            IntPtr InSecurityAttributes,
            UInt32 InCreationDisposition,
            UInt32 InFlagsAndAttributes,
            IntPtr InTemplateFile)
        {

            try
            {
              /*  var This = HookRuntimeInfo.Callback;

                lock (This.Queue)
                {
                    This.Queue.Push("[" + RemoteHooking.GetCurrentProcessId() + ":" +
                                    RemoteHooking.GetCurrentThreadId() + "]: \"" + InFileName + "\"");
                }*/
            }
            catch
            {
            }

            // call original API...
            return CreateFile(
                InFileName,
                InDesiredAccess,
                InShareMode,
                InSecurityAttributes,
                InCreationDisposition,
                InFlagsAndAttributes,
                InTemplateFile);
        }

        public Hook(int pID)
        {
            this.pID = pID;
            var address = LocalHook.GetProcAddress("kernel32.dll", "CreateFileW");

            var hook = LocalHook.Create(address, new HookCreateFile(CreateFile_Hooked), null);
           // hook.ThreadACL.SetInclusiveACL(new int[RemoteHooking.GetCurrentThreadId()]);
            // hook.ThreadACL.SetExclusiveACL(new int[pID]);
            //   hook.Dispose();
            //   LocalHook.Release();

        }
    }

    internal class Run
    {
        private int pID;
        static String ChannelName = null;

        public Run(int pID)
        {
            this.pID = pID;
            InstallHookTo_Process();
        }

        private bool InstallHookTo_Process()
        {
            try
            {
                string injectionLibrary =
                    Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location),
                        "CaxaInject.dll");
                RemoteHooking.IpcCreateServer<HookDealWith>(ref ChannelName, WellKnownObjectMode.SingleCall);
                RemoteHooking.Inject(
                    pID,
                    InjectionOptions.Default,
                    injectionLibrary,
                    injectionLibrary,
                    ChannelName
                );
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
                return false;
            }

            return true;
        }
    }

    public class HookDealWith: MarshalByRefObject
    {
        public void IsInstalled(Int32 InClientPID)
        {
           // Console.WriteLine(InClientPID);
        }

        public void OnCreateFile(Int32 InClientPID, String[] InFileNames)
        {
            //Console.WriteLine(InClientPID);
            Console.WriteLine(InClientPID);
            foreach (var VARIABLE in InFileNames)
            {
                Console.WriteLine(VARIABLE);
            }
        }

        public void ReportException(Exception InInfo)
        {
        
        }

        public void Ping(int pid)
        {
          //  Console.WriteLine(pid);
        }
    }
}
