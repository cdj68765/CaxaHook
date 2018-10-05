using EasyHook;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;
using System.Runtime.Serialization.Formatters;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Windows.Forms;

namespace ETCTool
{
    public class RemoteDataHandle : MarshalByRefObject
    {
        public Dictionary<string, byte[]> CopyData = new Dictionary<string, byte[]>();
        public List<string> FileList = new List<string>();
        public string FilePath;
        public string OperaMode;

        private void StartHook()
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
                    $"{path}\\EtcTool\\CDRAFT_M.exe", "", 0,
                    $"{path}\\EtcTool\\LdTermInject.dll",
                    $"{path}\\EtcTool\\LdTermInject.dll", out var PID,
                    ChannelName);
            }
            catch (Exception e)
            {
                Variables.MainForm.OntherLog.Add(new[] {$"{DateTime.Now:hh:mm:ss}->发生错误", $"{e}"});
            }
        }

        public void Info(string info)
        {
            Variables.MainForm.OntherLog.Add(new[] {$"{DateTime.Now:hh:mm:ss}->", $"{info}"});
        }

        public void Open(string Path)
        {
            FilePath = Path;
            OperaMode = "Open";
            StartHook();
        }

        public void Copy(string[] paths)
        {
            OperaMode = "Copy";
            FileList = new List<string>();
            foreach (var VARIABLE in paths)
                if (File.Exists(VARIABLE))
                    FileList.Add(VARIABLE);

            Info($"复制文件数量{paths.Length}");
            StartHook();
        }

        public void Decrypt(string[] paths)
        {
            OperaMode = "Decrypt";
            FileList = new List<string>();
            foreach (var VARIABLE in paths)
                if (File.Exists(VARIABLE))
                    FileList.Add(VARIABLE);

            StartHook();
        }

        public void AddToCopyData(string v1, byte[] v2)
        {
            HisFileData.Save(new FileData { Time = $"{File.GetLastWriteTime(v1).ToLocalTime()}", File = v1, Data = v2 });
            CopyData.Add(v1, v2);
        }
    }

    public static class FileDecryptMainFun
    {
        #region 文件加解密功能

        public static void FileDecryptFun(bool Start)
        {
            try
            {
                var clsid = "{B3F0615C-D04E-41DC-A1EB-4E8B8DCC14A1}";
                var rs = new RegistrationServices();
                if (Start)
                {
                    CreateIpcServer();
                    rs.RegisterAssembly(Assembly.GetAssembly(typeof(FileContextMenuExt)),
                        AssemblyRegistrationFlags.SetCodeBase);
                    using (var key =
                        Registry.ClassesRoot.CreateSubKey($@"*\shellex\ContextMenuHandlers\{clsid}"))
                    {
                        key?.SetValue(null, clsid);
                    }

                    using (var key = Registry.ClassesRoot.CreateSubKey(@"Directory\Background\shell\解密粘贴\Command"))
                    {
                        key?.SetValue(null, $"\"{Application.ExecutablePath}\" Copy \"%V\"");
                    }

                    Variables.MainForm.OntherLog.Add(new[] {$"{DateTime.Now:hh:mm:ss}->", "文件右键菜单安装成功"});
                }
                else
                {
                    Registry.ClassesRoot?.DeleteSubKeyTree($@"*\shellex\ContextMenuHandlers\{clsid}");
                    Registry.ClassesRoot?.DeleteSubKeyTree(@"Directory\Background\shell\解密粘贴", false);
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
                    if (ChannelServices.GetChannel("EtcTool") == null)
                    {
                        var DACL = new DiscretionaryAcl(false, false, 0);
                        DACL.AddAccess(AccessControlType.Allow, new SecurityIdentifier(WellKnownSidType.WorldSid, null),
                            -1, InheritanceFlags.None, PropagationFlags.None);
                        ChannelServices.RegisterChannel(new IpcServerChannel(
                            new Hashtable {["name"] = "EtcTool", ["portName"] = "EtcToolChannel"},
                            new BinaryServerFormatterSinkProvider {TypeFilterLevel = TypeFilterLevel.Full},
                            new CommonSecurityDescriptor(false, false,
                                ControlFlags.GroupDefaulted |
                                ControlFlags.OwnerDefaulted |
                                ControlFlags.DiscretionaryAclPresent,
                                null, null, null,
                                DACL)), false);
                        RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteDataHandle), "RemoteDataHandle",
                            WellKnownObjectMode.Singleton);
                        Variables.MainForm.OntherLog.Add(new[] {$"{DateTime.Now:hh:mm:ss}->", $"管道监听启动完毕"});
                    }
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