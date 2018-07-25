using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyHook;
using Newtonsoft.Json;

namespace CaxaHook
{
    [Serializable]
    public class RuntimeInfo
    {
        public RuntimeInfo()
        {
        }

        public RuntimeInfo(string path)
        {
            Path = path + "\\CaxaAutoSave";
            if (!File.Exists($"{Path}\\RuntimeInfo.xml"))
            {
                Save();
            }
        }

        public bool RunMode { get; set; }
        public string Path { get; set; }
        public bool RunStatus { get; set; }
        public string SavePath { get; set; }
        public long TimeSelect { get; set; }

        public Dictionary<string, List<FileInfo>> SaveList { get; set; }
        public int ALLSAVECOUNT { get; set; }
        public int OneSaveCount { get; set; }

        public class FileInfo
        {
            public string FilePath;
            public DateTime Date;

            public FileInfo(string path, DateTime now)
            {
                FilePath = path;
                Date = now;
            }
        }

        public void Save()
        {
            try
            {
                File.WriteAllText($"{Path}\\RuntimeInfo.xml", JsonConvert.SerializeObject(this));
                return;
                using (Stream fStream = new FileStream($"{Path}\\RuntimeInfo.xml", FileMode.Create, FileAccess.ReadWrite))
                {
                    /*  var soapFormat = new BinaryFormatter();
                      fStream.Position = 0;
                      soapFormat.Serialize(fStream, this);*/
                    string strSerializeJSON = JsonConvert.SerializeObject(this);
                    File.WriteAllText($"{Path}\\RuntimeInfo.xml", JsonConvert.SerializeObject(this));
                }
            }
            catch (Exception)
            {
            }
        }

        public RuntimeInfo Load()
        {
            try
            {
                if (!File.Exists($"{Path}\\RuntimeInfo.xml")) return null;
                return (RuntimeInfo)JsonConvert.DeserializeObject(File.ReadAllText($"{Path}\\RuntimeInfo.xml"), typeof(RuntimeInfo));
                var soapFormat = new BinaryFormatter();
                return (RuntimeInfo)soapFormat.Deserialize(new MemoryStream(File.ReadAllBytes($"{Path}\\RuntimeInfo.xml")));
                using (Stream fStream = new FileStream($"{Path}\\RuntimeInfo.xml", FileMode.Open, FileAccess.ReadWrite))
                {
                    fStream.Position = 0;
                    return (RuntimeInfo)soapFormat.Deserialize(new MemoryStream(File.ReadAllBytes($"{Path}\\RuntimeInfo.xml")));
                }
            }
            catch (Exception e)
            {
                Save();
                return Load();
            };
        }
    }

    public class Class1
    {
        public static Form1 Form1;
        public static RuntimeInfo RuntimeInfo;
        internal static string savefile;

        internal static string AssemblyFileSaveToCaxaAutoSave(out DirectoryInfo Ass)
        {
            String Path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            Ass = new DirectoryInfo(
                $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\CaxaAutoSave");

            if (!Ass.Exists)
            {
                Ass.Create();
            }

            if (!File.Exists($"{Ass}\\EasyLoad64.dll")||true)
            {
                foreach (var VARIABLE in new[]
                {
                    "EasyHook32.dll", "EasyHook32Svc.exe", "EasyLoad32.dll",
                    "EasyHook64Svc.exe", "EasyHook64.dll", "EasyLoad64.dll",
                    "VisualPlus.dll", "EasyHook.dll","CaxaInject.dll","Newtonsoft.Json.dll","PLMInject.dll"
                })
                {
                    try
                    {
                        SaveToDisk(Ass.FullName, VARIABLE);
                    }
                    catch (Exception e)
                    {
                    }
               
                }
            }

            RuntimeInfo = File.Exists($"{Path}\\RuntimeInfo.xml") ? new RuntimeInfo(Path).Load() : new RuntimeInfo(Path);
            Directory.SetCurrentDirectory(Ass.FullName);
            return Path;
            void SaveToDisk(string fullName, string v)
            {
                Stream sm = Assembly.GetExecutingAssembly().GetManifestResourceStream($"CaxaHook.{v}");
                if (sm != null)
                {
                    using (var File = new FileStream($"{fullName}\\{v}", FileMode.Create))
                    {
                        sm.CopyToAsync(File).Wait();
                    }
                    sm.Dispose();
                }
            }
        }
    }

    public class HookDealWith : MarshalByRefObject
    {
        public bool CheckHook(out bool uninstall)
        {
            uninstall = Class1.Form1.UninstallAllHooks;
            return Class1.Form1.SetHook;
        }

        public void info(string v)
        {
            Console.WriteLine(v);
        }

        public void IsInstalled(Int32 InClientPID)
        {
            Class1.Form1.Invoke(new Action(() =>
            {
                Class1.Form1.HookAddress.Text = $@"Hook Address：{InClientPID}";
                // Class1.Form1.AddLog($"Caxa挂钩成功，Hook地址：{InClientPID}");
            }));
        }

        public void ReportException(Exception InInfo)
        {
            try
            {
                Class1.Form1.Invoke(new Action(() =>
                {
                    Class1.Form1.AddLog($"Hook错误，错误信息：{InInfo}");
                }));
            }
            catch (Exception e)
            {
            }
        }

        public string SaveChange(string NewFile)
        {
            Class1.Form1.Invoke(new Action(() =>
            {
                if (Class1.Form1.SetHook)
                {
                    try
                    {
                        var OnlyFileName = Path.GetFileNameWithoutExtension(NewFile).Replace(".exb", "");
                        NewFile = $@"{Class1.Form1.SelectSavePath.Text}\{OnlyFileName}{Class1.savefile}";
                        Class1.Form1.AddLog($"自动保存成功,保存路径：{NewFile}");
                        Class1.Form1.SetHook = false;
                        Class1.Form1.SaveToAutoBackList(OnlyFileName, NewFile);
                    }
                    catch (Exception e)
                    {
                        Class1.Form1.AddLog($"自动保存失败，错误信息：{e}");
                    }
                }
            }));
            return NewFile;
        }
    }

    public class HookPlmDealWith : MarshalByRefObject
    {
        public void IsInstalled(int v)
        {
            Class1.Form1.Invoke(new Action(() =>
            {
                Class1.Form1.PLMAddress.Text = $@"Hook Address：{v}";

            }));

        }
        public void ReportException(Exception InInfo)
        {
            try
            {
                Class1.Form1.Invoke(new Action(() =>
                {
                    Class1.Form1.AddLog($"Hook错误，错误信息：{InInfo}");
                }));
            }
            catch (Exception e)
            {
            }
        }
    }

}