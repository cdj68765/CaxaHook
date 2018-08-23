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
using System.ServiceProcess;
using System.Threading;
using System.Windows.Forms;

namespace ETCTool
{
    class Program
    {
        static void Main(string[] args)
        {

            if (Environment.CurrentDirectory != Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory) &&
                args.Length == 0)
            {
                ServiceBase.Run(new ETCToolService(Application.ExecutablePath));
                return;
            }
            var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var Guid = ((GuidAttribute) Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(),
                typeof(GuidAttribute))).Value;
            if (args.Length == 0|| args[0]== "Service")
            {
                AssemblyHandler.AssemblyFileSaveToCaxaAutoSave(path);
            }
          /*  string filePath = @"D:\MyServiceLog.txt";
            using (FileStream stream = new FileStream(filePath, FileMode.Append))
            using (StreamWriter writer = new StreamWriter(stream))
            {
                writer.WriteLine($"{DateTime.Now},{args[0]}！");
            }*/

            if (AppDomain.CurrentDomain.IsDefaultAppDomain() && args.Length == 0 || args[0] == "Service")
            {
                AppDomain newDomain = AppDomain.CreateDomain("StartNewProcess", null, new AppDomainSetup()
                {
                    PrivateBinPath = $"{path}\\EtcTool",
                    ApplicationBase = $"{path}\\EtcTool"
                });
                int ret = newDomain.ExecuteAssemblyByName(Assembly.GetExecutingAssembly().FullName, Guid,
                    Application.ExecutablePath);
                AppDomain.Unload(newDomain);
                Environment.ExitCode = ret;
                Environment.Exit(0);
            }
            else
            {
                if (args[1] != Properties.Settings.Default.OriPath)
                {
                    Properties.Settings.Default.OriPath = args[1];
                    Properties.Settings.Default.Save();
                }

                if (!Properties.Settings.Default.RunMode)
                {

                }

                ShowForm();
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
                Variables.MainForm = new MainForm();
                Application.Run(Variables.MainForm);
            }
        }
    }
}
