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
    }
    [Serializable]
    public class Setting
    {
        public bool RunMode { get; set; }
        public bool CheckClipbrdFuntion { get; set; }
        public bool CheckPlmFuntion { get; set; }
        public bool CheckCaxaFuntion { get; set; }
        public string OriPath { get; set; }
        public bool CheckFileDecrypt { get; set; }
        public StringCollection FormSize { get; set; }
        public string AutoSavePath { get; set; }
        public string TheLastSavePath { get; set; }
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
        internal void Save()
        {
            ThreadPool.QueueUserWorkItem(state =>
            {
                try
                {
                    using (var fileStream = new FileStream($"{Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)}\\EtcTool\\Setting.dat", FileMode.OpenOrCreate))
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