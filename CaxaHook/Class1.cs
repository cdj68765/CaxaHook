using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;

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

        public void Save()
        {
            try
            {
                using (Stream fStream = new FileStream($"{Path}\\RuntimeInfo.xml", FileMode.Create, FileAccess.ReadWrite))
                {
                    SoapFormatter soapFormat = new SoapFormatter();
                    soapFormat.Serialize(fStream, this);
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
                using (Stream fStream = new FileStream($"{Path}\\RuntimeInfo.xml", FileMode.Open, FileAccess.Read))
                {
                    SoapFormatter soapFormat = new SoapFormatter();
                    return (RuntimeInfo)soapFormat.Deserialize(fStream);
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

            if (!File.Exists($"{Ass}\\EasyLoad64.dll"))
            {
                foreach (var VARIABLE in new[]
                {
                    "EasyHook32.dll", "EasyHook32Svc.exe", "EasyLoad32.dll",
                    "EasyHook64Svc.exe", "EasyHook64.dll", "EasyLoad64.dll",
                    "VisualPlus.dll", "EasyHook.dll","CaxaInject.dll"
                })
                {
                    SaveToDisk(Ass.FullName, VARIABLE);
                }
            }

            RuntimeInfo = File.Exists($"{Path}\\RuntimeInfo.xml") ? new RuntimeInfo(Path).Load() : new RuntimeInfo(Path);
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
        public bool CheckHook()
        {
            return Class1.Form1.SetHook;
        }

        public void IsInstalled(Int32 InClientPID)
        {
            Class1.Form1.Invoke(new Action(() => { Class1.Form1.HookAddress.Text = $@"Hook Address：{InClientPID}"; }));
        }

        public void OnCreateFile(Int32 InClientPID, String[] InFileNames)
        {
            Console.WriteLine(InClientPID);
            foreach (var VARIABLE in InFileNames)
            {
                Console.WriteLine(VARIABLE);
            }
        }

        public void ReportException(Exception InInfo)
        {
            Console.WriteLine();
        }

        public string SaveChange(string NewFile)
        {
            var TempSave = "";
            Class1.Form1.Invoke(new Action(() =>
            {
                TempSave = $@"{Class1.Form1.SelectSavePath.Text}\{Path.GetFileNameWithoutExtension(NewFile).Replace(".exb", "")}{Class1.savefile}";
                Class1.Form1.FROM.Text = NewFile;
                Class1.Form1.TO.Text = Path.GetFileNameWithoutExtension(NewFile).Replace(".exb", "");
                Console.WriteLine(TempSave);
                Class1.Form1.SetHook = false;
            }));
            if (string.IsNullOrWhiteSpace(Class1.savefile))
            {
                return NewFile;
            }
            return TempSave;
        }
    }
}