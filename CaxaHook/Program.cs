using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using System.Threading;
using EasyHook;
using System.Windows.Forms;

namespace CaxaHook
{
    class Program
    {
        static void Main(string[] args)
        {
            String Path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var Ass = new DirectoryInfo($"{Path}\\CaxaAutoSave");
            if (!Ass.Exists)
            {
               
                Ass.Create();
                foreach (var VARIABLE in new[]
                {
                    "EasyHook32.dll", "EasyHook32Svc.exe", "EasyLoad32.dll",
                    "EasyHook64Svc.exe", "EasyHook64.dll", "EasyLoad64.dll","EasyHook.dll"
                })
                {
                    SaveToDisk(Ass.FullName, VARIABLE);
                }
            }

         /*   if (args.Length == 0)
            {
                File.Copy($"{AppDomain.CurrentDomain.BaseDirectory}\\CaxaHook.exe", $"{Path}\\CaxaAutoSave\\CaxaHook.exe", true);
                File.Copy($"{AppDomain.CurrentDomain.BaseDirectory}\\CaxaInject.dll", $"{Path}\\CaxaAutoSave\\CaxaInject.dll", true);
                Process.Start($"{Path}\\CaxaAutoSave\\CaxaHook.exe", "Run");
                return;
            }
            else
            {
                Application.Run(new Form1());
                /* Class1.Form1 = new Form1();
                 Class1.Form1.Show();
            }*/
            if (AppDomain.CurrentDomain.IsDefaultAppDomain()&&args.Length==0)
            {
                File.Copy($"{AppDomain.CurrentDomain.BaseDirectory}\\CaxaHook.exe", $"{Path}\\CaxaAutoSave\\CaxaHook.exe",true);
                File.Copy($"{AppDomain.CurrentDomain.BaseDirectory}\\CaxaInject.dll", $"{Path}\\CaxaAutoSave\\CaxaInject.dll", true);
                var currentAssembly = Assembly.GetExecutingAssembly();
                AppDomainSetup setup = new AppDomainSetup();
                setup.ApplicationBase = Environment.CurrentDirectory;
               setup.PrivateBinPath = $"{Path}\\CaxaAutoSave";
                setup.ApplicationBase= $"{Path}\\CaxaAutoSave";
                AppDomain newDomain = AppDomain.CreateDomain("NewAppDomain", null, setup);
            
                int ret = newDomain.ExecuteAssemblyByName(currentAssembly.FullName,"Run");
                AppDomain.Unload(newDomain);
                Environment.ExitCode = ret;
                Environment.Exit(0);
            }
            Class1.Form1 = new Form1();
            Class1.Form1.ShowDialog();
            void SaveToDisk(string fullName, string v)
            {
                Stream sm = Assembly.GetExecutingAssembly().GetManifestResourceStream($"CaxaHook.{v}");
                if (sm != null)
                {
                    using (var File = new FileStream($"{fullName}\\{v}", FileMode.Create))
                    {
                        sm.CopyToAsync(File).Wait();
                    }

                    if (v == "EasyHook.dll")
                    {
                        new System.EnterpriseServices.Internal.Publish().GacInstall($"{fullName}\\{v}");
                    }
                }
            }

        }
    }

    internal class Hook
    {
        private int pID;
        [UnmanagedFunctionPointer(CallingConvention.StdCall,
            CharSet = CharSet.Unicode,
            SetLastError = true)]
        delegate IntPtr HookMoveFileEx(
            String OldFile,
            String NewFile,
            UInt32 dwFlags);

        // just use a P-Invoke implementation to get native API access from C# (this step is not necessary for C++.NET)
        [DllImport("kernel32.dll",
            CharSet = CharSet.Unicode,
            SetLastError = true,
            CallingConvention = CallingConvention.StdCall)]
        static extern IntPtr MoveFileEx(
            String OldFile,
            String NewFile,
            UInt32 dwFlags);
        static IntPtr MoveFileEx_Hooked(
            String OldFile,
            String NewFile,
            UInt32 dwFlags)
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
            return MoveFileEx(
                OldFile,
                NewFile,
                dwFlags);
        }

        public Hook(int pID)
        {
            this.pID = pID;
            var address = LocalHook.GetProcAddress("kernel32.dll", "CreateFileW");

            var hook = LocalHook.Create(address, new HookMoveFileEx(MoveFileEx_Hooked), null);
           // hook.ThreadACL.SetInclusiveACL(new int[RemoteHooking.GetCurrentThreadId()]);
            // hook.ThreadACL.SetExclusiveACL(new int[pID]);
            //   hook.Dispose();
            //   LocalHook.Release();

        }
    }


}
