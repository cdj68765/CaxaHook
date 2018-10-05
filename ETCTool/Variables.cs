using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Channels.Ipc;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;
using System.Linq;
namespace ETCTool
{
    internal class Variables
    {
        internal static MainForm MainForm;
        internal static Setting setting;
        internal static bool AutoSaveRun;
        internal static bool PlmMonitorRun;
        internal static bool CheckAutoPerformClick;
        internal static int AutoPerformClickCount;
        internal static NativeApi.Point TheLastMouseCursor;
    }

    [Serializable]
    public class Setting
    {
        private bool _AdapterCaxaAutoSave;
        private int _AutoPerformClickCount;

        private string _AutoSavePath;

        private string _AutoSaveSpan;

        private bool _CheckAutoPerformClick;

        private bool _CheckCaxaFuntion;

        private bool _CheckClipbrdFuntion;

        private bool _CheckFileDecrypt;

        private bool _CheckPlmFuntion;
        private bool _RunMode;

        private string _TheLastSavePath;

        public bool RunMode
        {
            get => _RunMode;
            set
            {
                _RunMode = value;
                Save();
            }
        }

        public bool CheckClipbrdFuntion
        {
            get => _CheckClipbrdFuntion;
            set
            {
                _CheckClipbrdFuntion = value;
                Save();
            }
        }

        public bool CheckPlmFuntion
        {
            get => _CheckPlmFuntion;
            set
            {
                _CheckPlmFuntion = value;
                Save();
            }
        }

        public bool CheckCaxaFuntion
        {
            get => _CheckCaxaFuntion;
            set
            {
                _CheckCaxaFuntion = value;
                Save();
            }
        }

        public bool CheckFileDecrypt
        {
            get => _CheckFileDecrypt;
            set
            {
                _CheckFileDecrypt = value;
                Save();
            }
        }

        public StringCollection FormSize { get; set; }

        public StringCollection FileCollect { get; set; }
        public string AutoSavePath
        {
            get => _AutoSavePath;
            set
            {
                _AutoSavePath = value;
                Save();
            }
        }

        public string TheLastSavePath
        {
            get => _TheLastSavePath;
            set
            {
                _TheLastSavePath = value;
                Save();
            }
        }

        public string AutoSaveSpan
        {
            get => _AutoSaveSpan;
            set
            {
                if (!float.TryParse(value, out var ret)) return;
                _AutoSaveSpan = value;
                Save();
            }
        }

        public bool AdapterCaxaAutoSave
        {
            get => _AdapterCaxaAutoSave;
            set
            {
                _AdapterCaxaAutoSave = value;
                Save();
            }
        }

        public bool CheckAutoPerformClick
        {
            get => _CheckAutoPerformClick;
            set
            {
                _CheckAutoPerformClick = value;
                Variables.CheckAutoPerformClick = value;
                Save();
            }
        }

        public int AutoPerformClickCount
        {
            get
            {
                if (_AutoPerformClickCount == 0) return 1;

                return _AutoPerformClickCount;
            }
            set
            {
                _AutoPerformClickCount = value;
                Variables.AutoPerformClickCount = value;
                Save();
            }
        }

        internal Setting Init()
        {
            var path =
                $"{Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)}\\EtcTool\\Setting.dat";
            if (File.Exists(path))
                using (var fileStream = new FileStream(path, FileMode.Open))
                {
                    return new BinaryFormatter().Deserialize(fileStream) as Setting;
                }
            return new Setting();
        }

        public void Save()
        {
            ThreadPool.QueueUserWorkItem(state =>
            {
                try
                {
                    using (var fileStream =
                        new FileStream(
                            $"{Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)}\\EtcTool\\Setting.dat",
                            FileMode.OpenOrCreate))
                    {
                        new BinaryFormatter().Serialize(fileStream, Variables.setting);
                    }
                }
                catch (Exception e)
                {
                }
            });
        }
    }
    [Serializable]
    public struct FileData
    {
        public string Time;
        public string File;
        public byte[] Data;
    }

    public class HisFileData
    {
        static byte[] StructToBytes(FileData structObj)
        {
            using (var SaveStream = new MemoryStream())
            {
                new BinaryFormatter().Serialize(SaveStream, structObj);
                return SaveStream.ToArray();
            }
        }

        //byte[]转换为struct
        static FileData BytesToStruct(byte[] bytes)
        {
            return (FileData) new BinaryFormatter().Deserialize(new MemoryStream(bytes));

        }

        public static void Save(FileData fileData)
        {
            ThreadPool.QueueUserWorkItem(state =>
            {
                var path =
                    $"{Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)}\\EtcTool\\SaveDate.dat";
                try
                {
                    if (!File.Exists(path))
                    {
                        Variables.setting.FileCollect = new StringCollection();
                    }
                    using (var fileStream =
                        new FileStream(path, FileMode.Append,FileAccess.Write))
                    {
                        var TempByte = StructToBytes(fileData);
                        Variables.setting.FileCollect.Add(
                            $"{fileData.Time}|{fileData.File}|{fileStream.Position}|{TempByte.Length}");
                        Variables.setting.Save();
                        fileStream.Write(TempByte, 0, TempByte.Length);
                    }

                    Variables.MainForm.BeginInvoke(new Action(() =>
                    {
                        if (Variables.MainForm.DecryptRadio.Checked) return;
                        Variables.MainForm.OntherList.Items.Clear();
                        foreach (var VARIABLE in Variables.setting.FileCollect)
                        {
                            Variables.MainForm.OntherList.Items.Add(VARIABLE);
                        }
                    }));
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    Variables.setting.FileCollect = new StringCollection();
                    try
                    {
                        File.Delete(path);
                    }
                    catch (Exception exception)
                    {
                    }
                 
                }
            });
        }

        public static FileData Open(string DateIndex)
        {
            try
            {
                var path =
                    $"{Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)}\\EtcTool\\SaveDate.dat";
                if (File.Exists(path))
                {
                    using (var fileStream =
                        new FileStream(path, FileMode.OpenOrCreate))
                    {
                        var StringSplit = DateIndex.Split('|');
                        var TempByte = new byte[int.Parse(StringSplit[3])];
                        fileStream.Position = int.Parse(StringSplit[2]);
                        fileStream.Read(TempByte, 0, int.Parse(StringSplit[3]));
                        return BytesToStruct(TempByte);
                    }
                }
                else
                {
                    Variables.setting.FileCollect = new StringCollection();
                    Variables.setting.Save();
                }

            }
            catch (Exception e)
            {
                new MessageBoxForm(e.Message, MessageBoxButtons.OK, 5).ShowDialog();
            }

            return new FileData();
        }
    }

}