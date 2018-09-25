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
namespace ETCTool
{
    public class RemoteDataHandle : MarshalByRefObject
    {
        public RemoteDataHandle()
        {
            Variables.MainForm.OntherLog.Add(new[] {$"{DateTime.Now:hh:mm:ss}->", $"接收到远程信号，创建实例"});
        }

        public void RetDate(string Path, byte[] Date)
        {
            Variables.MainForm.OntherLog.Add(new[] {$"{DateTime.Now:hh:mm:ss}->", $"返回数据{Path}"});
            Variables.MainForm.OntherLog.Add(new[] {$"{DateTime.Now:hh:mm:ss}->", $"返回数据{Date.Length}"});
        }

        public void Info(string info)
        {
            Variables.MainForm.OntherLog.Add(new[] {$"{DateTime.Now:hh:mm:ss}->", $"{info}"});
        }

        public void Open(string path)
        {
            Variables.MainForm.OntherLog.Add(new[] {$"{DateTime.Now:hh:mm:ss}->", $"打开文件{Path.GetFileName(path)}"});
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "CDRAFT_M.exe",
                Arguments = path, //设定参数，其中的“/C”表示执行完命令后马上退出
               //  UseShellExecute = false, //不使用系统外壳程序启动
               //  RedirectStandardInput = true, //不重定向输入
               //  RedirectStandardOutput = true, //重定向输出
                 CreateNoWindow = true //不创建窗口
            };
            process.StartInfo = startInfo;
            process.Start();

        }

        public void Copy(string[] paths)
        {
            Variables.MainForm.OntherLog.Add(new[] {$"{DateTime.Now:hh:mm:ss}->", $"启动复制文件模式"});
        }

        public void Decrypt(string paths)
        {
            Variables.MainForm.OntherLog.Add(new[] {$"{DateTime.Now:hh:mm:ss}->", $"启动解密文件模式"});
        }
    }

    public static class FileDecryptMainFun
    {
        #region 文件加解密功能

        static CancellationTokenSource cancel = new CancellationTokenSource();
        static IpcServerChannel channel = new IpcServerChannel("EtcToolChannel");
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
                    Variables.MainForm.OntherLog.Add(new[] { $"{DateTime.Now:hh:mm:ss}->", $"管道监听启动完毕" });
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
