using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
namespace ETCTool
{
    public static class MainFun
    {
        #region 文件加解密功能

        public static void FileDecryptFun(bool Start)
        {
            try
            {
                string clsid = "{B3F0615C-D04E-41DC-A1EB-4E8B8DCC14A1}";
                Variables.FileDecryptStart = Start;
                var rs = new RegistrationServices();
                if (Start)
                {
                    Task.Factory.StartNew(CreatePipeServer);
             
                    rs.RegisterAssembly(Assembly.GetAssembly(typeof(FileContextMenuExt)),
                        AssemblyRegistrationFlags.SetCodeBase);
                    using (var key = Registry.CurrentUser.CreateSubKey($@"Software\Classes\*\shellex\ContextMenuHandlers\{clsid}"))
                    {
                        key?.SetValue(null, clsid);
                    }
                    using (var key = Registry.ClassesRoot.CreateSubKey(@"DesktopBackground\Shell\解密粘贴\Command"))
                    {
                        key?.SetValue(null, Application.ExecutablePath+" Paste");
                    }
                    Variables.MainForm.OntherLog.Add(new[] {$"{DateTime.Now:hh:mm:ss}->", "文件右键菜单安装成功"});
                }
                else
                {
                    Registry.CurrentUser?.DeleteSubKeyTree($@"Software\Classes\*\shellex\ContextMenuHandlers\{clsid}");
                    Registry.ClassesRoot?.DeleteSubKeyTree(@"DesktopBackground\Shell\解密粘贴",false);
                    rs.UnregisterAssembly(Assembly.GetAssembly(typeof(FileContextMenuExt)));
                    Variables.MainForm.OntherLog.Add(new[] {$"{DateTime.Now:hh:mm:ss}->", "文件右键菜单删除成功"});
                }
            }
            catch (Exception e)
            {
                Variables.MainForm.OntherLog.Add(new[] {$"{DateTime.Now:hh:mm:ss}->", $"操作失败，失败原因{e.Message}"});
            }
            void CreatePipeServer()
            {
                using (var pipeServer = new NamedPipeServerStream("EtcTool", PipeDirection.In)) //创建管道
                {
                    try
                    {
                        pipeServer.WaitForConnection(); //等待客户端连接
                        List<byte> Read = new List<byte>();
                        do
                        {
                            Read.Add(Convert.ToByte(pipeServer.ReadByte()));
                        } while (!pipeServer.IsMessageComplete);
                        using (var MemoryStream = new MemoryStream(Read.ToArray()))
                        {
                            var Ret= new BinaryFormatter().Deserialize(MemoryStream) as string[];
                        }
                    }
                    catch (IOException e)
                    {
                        Variables.MainForm.OntherLog.Add(new[] { $"{DateTime.Now:hh:mm:ss}->", $"管道错误，失败原因{e.Message}" });
                    }
                }
            }
        }

    
        #endregion
    }
}
