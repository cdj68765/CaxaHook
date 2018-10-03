using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

using System.IO;

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;
using FileSystem = Microsoft.VisualBasic.FileIO.FileSystem;
using System.IO.MemoryMappedFiles;
using EasyHook;

namespace ETCTool
{
    public class RemoteDataHandle : MarshalByRefObject
    {

        void StartHook()
        {
            try
            {
                string ChannelName = null;
                var path = Environment.GetFolderPath(Environment.SpecialFolder
                    .CommonApplicationData);
                RemoteHooking.IpcCreateServer<LdTermInInterface>(ref ChannelName,
                    WellKnownObjectMode.SingleCall);
                Config.DependencyPath = $"{path}\\EtcTool\\";
                Config.HelperLibraryLocation = $"{path}\\EtcTool\\";
                RemoteHooking.CreateAndInject(
                    @"CDRAFT_M.exe", "", 0,
                    $"{path}\\EtcTool\\LdTermInject.dll",
                    $"{path}\\EtcTool\\LdTermInject.dll", out int PID,
                    ChannelName);
            }
            catch (Exception e)
            {
                Variables.MainForm.OntherLog.Add(new[] { $"{DateTime.Now:hh:mm:ss}->发生错误", $"{e}" });
            }
        }
        public void Info(string info)
        {
            Variables.MainForm.OntherLog.Add(new[] {$"{DateTime.Now:hh:mm:ss}->", $"{info}"});
        }

        public  string FilePath;
        public string OperaMode;
        public void Open(string Path)
        {
            FilePath = Path;
            OperaMode = "Open";
            StartHook();
        }

        public void Copy(string[] paths)
        {
            StartHook();
            OperaMode = "Copy";
            FileList = new List<string>();
            foreach (var VARIABLE in paths)
            {
                if (File.Exists(VARIABLE)) FileList.Add(VARIABLE);
            }
        }

        public List<string> FileList = new List<string>();
        public void Decrypt(string[] paths)
        {
            OperaMode = "Decrypt";
            FileList = new List<string>();
            foreach (var VARIABLE in paths)
            {
                if (File.Exists(VARIABLE)) FileList.Add(VARIABLE);
            }
            StartHook();
        }
    }

    public static class FileDecryptMainFun
    {
        #region 文件加解密功能

        private static CancellationTokenSource cancel = new CancellationTokenSource();
        private static IpcServerChannel channel = new IpcServerChannel("EtcToolChannel");

        public static void FileDecryptFun(bool Start)
        {
            try
            {
                string clsid = "{B3F0615C-D04E-41DC-A1EB-4E8B8DCC14A1}";
                Variables.FileDecryptStart = Start;
                var rs = new RegistrationServices();
                if (Start)
                {
                    cancel = new CancellationTokenSource();
                    Task.Factory.StartNew(CreateIpcServer, cancel.Token, TaskCreationOptions.LongRunning,
                        TaskScheduler.Default);
                    rs.RegisterAssembly(Assembly.GetAssembly(typeof(FileContextMenuExt)),
                        AssemblyRegistrationFlags.SetCodeBase);
                    using (var key =
                        Registry.CurrentUser.CreateSubKey($@"Software\Classes\*\shellex\ContextMenuHandlers\{clsid}"))
                    {
                        key?.SetValue(null, clsid);
                    }

                    using (var key = Registry.ClassesRoot.CreateSubKey(@"DesktopBackground\Shell\解密粘贴\Command"))
                    {
                        key?.SetValue(null, Application.ExecutablePath + " Paste");
                    }

                    Variables.MainForm.OntherLog.Add(new[] {$"{DateTime.Now:hh:mm:ss}->", "文件右键菜单安装成功"});
                }
                else
                {
                    cancel.Cancel();
                    ChannelServices.UnregisterChannel(channel);
                    Registry.CurrentUser?.DeleteSubKeyTree($@"Software\Classes\*\shellex\ContextMenuHandlers\{clsid}");
                    Registry.ClassesRoot?.DeleteSubKeyTree(@"DesktopBackground\Shell\解密粘贴", false);
                    rs.UnregisterAssembly(Assembly.GetAssembly(typeof(FileContextMenuExt)));
                    Variables.MainForm.OntherLog.Add(new[] {$"{DateTime.Now:hh:mm:ss}->", "文件右键菜单删除成功"});
                }
            }
            catch (Exception e)
            {
                Variables.MainForm.OntherLog.Add(new[] {$"{DateTime.Now:hh:mm:ss}->", $"操作失败，失败原因{e.Message}"});
            }

            void CreateIpcServer()
            {
                try
                {
                    ChannelServices.RegisterChannel(channel, false);
                    RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteDataHandle), "RemoteDataHandle",
                        WellKnownObjectMode.Singleton);
                    Variables.MainForm.OntherLog.Add(new[] {$"{DateTime.Now:hh:mm:ss}->", $"管道监听启动完毕"});
                }
                catch (IOException e)
                {
                    Variables.MainForm.OntherLog.Add(new[] {$"{DateTime.Now:hh:mm:ss}->", $"管道错误，失败原因{e.Message}"});
                }
            }

            #endregion 文件加解密功能
        }
    }
}