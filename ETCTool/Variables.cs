using System;
using System.Collections.Specialized;
using System.IO;
using System.Runtime.Remoting.Channels.Ipc;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

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
        internal static bool FileDecryptStart;
        internal static IpcClientChannel ChannelServices;
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

}