﻿using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Threading;
using System.Windows.Forms;
using static ETCTool.NativeApi;

namespace ETCTool
{
    internal class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            if (!Environment.UserInteractive)
            {
                ServiceBase.Run(new ETCToolService(Application.ExecutablePath));
                return;
            }

            if (args.Length != 0 && args[0] == "Copy")
            {
                try
                {
                    var remoteDataHandle = (RemoteDataHandle)Activator.GetObject(typeof(RemoteDataHandle), "ipc://EtcToolChannel/RemoteDataHandle");
                    foreach (var item in remoteDataHandle.CopyData)
                    {
                        var TempFile = $"{args[1]}{item.Key}".Replace("\"", "");
                        File.WriteAllBytes(TempFile, item.Value);
                        remoteDataHandle.Info($"{TempFile}粘贴完成");
                    }
                    UpdateWindow(GetWindowDC(GetDesktopWindow()));
                    SHChangeNotify(HChangeNotifyEventID.SHCNE_ALLEVENTS, HChangeNotifyFlags.SHCNF_FLUSH, IntPtr.Zero, IntPtr.Zero);
                    remoteDataHandle.CopyData.Clear();
                    GC.Collect();
                }
                catch (Exception E)
                {
                    MessageBox.Show(E.Message);
                }
                return;
            }

            if (args.Length != 0 && args[0] == "Service")
            {
                Thread.Sleep(10000);
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