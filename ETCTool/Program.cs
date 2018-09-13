using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Windows.Forms;
using ETCTool.Properties;

namespace ETCTool
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (!Environment.UserInteractive)
            {
                ServiceBase.Run(new ETCToolService(Application.ExecutablePath));
                return;
            }

            if (args.Length != 0 && args[0] == "Service")
            {
                ShowForm();
                AutoRunServer.ServiceStop();
                return;
            }

            var path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            var Guid = ((GuidAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(),
                typeof(GuidAttribute))).Value;
            if (args.Length == 0 || args[0] == "Service") AssemblyHandler.AssemblyFileSaveToCaxaAutoSave(path);
            if (AppDomain.CurrentDomain.IsDefaultAppDomain() && args.Length == 0 || args[0] == "Service")
            {
                var newDomain = AppDomain.CreateDomain("StartNewProcess", null, new AppDomainSetup
                {
                    PrivateBinPath = $"{path}\\EtcTool",
                    ApplicationBase = $"{path}\\EtcTool"

                });
               // createProcessAsUser.StartProcessAndBypassUAC(Application.ExecutablePath, " Service", out var info);
               var ret = newDomain.ExecuteAssemblyByName(Assembly.GetExecutingAssembly().FullName, Guid,
                    Application.ExecutablePath, "RunByService");
                AppDomain.Unload(newDomain);
                Environment.ExitCode = ret;
                Environment.Exit(0);
            }
            else
            {

               /* if (args[1] != Variables. Settings.OriPath)
                {
                    Variables.Settings.OriPath = args[1];
                    Variables.Settings.Save();
                }*/
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