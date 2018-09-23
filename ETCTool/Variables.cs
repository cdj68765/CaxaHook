using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;

namespace ETCTool
{
    internal class Variables
    {
        internal static MainForm MainForm;
        internal static Setting setting;
        internal static bool AutoSaveRun;
    }

    [Serializable]
    public class Setting
    {
        bool _RunMode;

        public bool RunMode
        {
            get => _RunMode;
            set
            {
                _RunMode = value;
                Save();
            }
        }

        bool _CheckClipbrdFuntion;

        public bool CheckClipbrdFuntion
        {
            get => _CheckClipbrdFuntion;
            set
            {
                _CheckClipbrdFuntion = value;
                Save();
            }
        }

        bool _CheckPlmFuntion;

        public bool CheckPlmFuntion
        {
            get => _CheckPlmFuntion;
            set
            {
                _CheckPlmFuntion = value;
                Save();
            }
        }

        bool _CheckCaxaFuntion;

        public bool CheckCaxaFuntion
        {
            get => _CheckCaxaFuntion;
            set
            {
                _CheckCaxaFuntion = value;
                Save();
            }
        }

        bool _CheckFileDecrypt;

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

        string _AutoSavePath;

        public string AutoSavePath
        {
            get => _AutoSavePath;
            set
            {
                _AutoSavePath = value;
                Save();
            }
        }

        string _TheLastSavePath;

        public string TheLastSavePath
        {
            get => _TheLastSavePath;
            set
            {
                _TheLastSavePath = value;
                Save();
            }
        }

        string _AutoSaveSpan;

        public string AutoSaveSpan
        {
            get => _AutoSaveSpan;
            set
            {
                if (!float.TryParse(value, out float ret)) return;
                _AutoSaveSpan = value;
                Save();
            }
        }

        private bool _AdapterCaxaAutoSave;

        public bool AdapterCaxaAutoSave
        {
            get => _AdapterCaxaAutoSave;
            set
            {
                _AdapterCaxaAutoSave = value;
                Save();
            }
        }

        internal Setting Init()
        {
            var path =
                $"{Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)}\\EtcTool\\Setting.dat";
            if (File.Exists(path))
            {
                using (var fileStream = new FileStream(path, FileMode.Open))
                {
                    return new BinaryFormatter().Deserialize(fileStream) as Setting;
                }
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
}