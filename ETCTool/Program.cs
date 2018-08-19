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
using System.Windows.Forms;
using EasyHook;

namespace ETCTool
{
    class Program
    {
        static void Main(string[] args)
        {
            var Path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var Guid = ((GuidAttribute) Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(),
                typeof(GuidAttribute))).Value;
            if (args.Length == 0)
            {
                AssemblyHandler.AssemblyFileSaveToCaxaAutoSave(Path);
            }
            if (!Properties.Settings.Default.RunMode)
            {
                if (AppDomain.CurrentDomain.IsDefaultAppDomain() && args.Length == 0)
                {
                    AppDomain newDomain = AppDomain.CreateDomain("StartNewProcess", null, new AppDomainSetup()
                    {
                        PrivateBinPath = $"{Path}\\EtcTool",
                        ApplicationBase = $"{Path}\\EtcTool"
                    });
                    int ret = newDomain.ExecuteAssemblyByName(Assembly.GetExecutingAssembly().FullName, Guid);
                    AppDomain.Unload(newDomain);
                    Environment.ExitCode = ret;
                    Environment.Exit(0);
                }
                else
                {
                    ShowForm();
                }
            }
            void ShowForm()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //处理未捕获的异常
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                //处理UI线程异常
                Application.ThreadException += delegate { };
                //处理非UI线程异常
                AppDomain.CurrentDomain.UnhandledException += delegate { };
                Application.Run(new MainForm());
            }
        }
    }
}
