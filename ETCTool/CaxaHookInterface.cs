using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ETCTool
{
    public class CaxaHookInterface : MarshalByRefObject
    {


        public void Ping(out bool ping)
        {
            ping = true;
        }

        public void Info(string v)
        {
            Variables.MainForm.AutoSaveLog.Add(new[] {$"{DateTime.Now:hh:mm:ss}->{v}:", $""});
        }

        public string GetNewPath(string lpNewFileName)
        {
            Variables.MainForm.AutoSaveLog.Add(new[]
                {$"{DateTime.Now:hh:mm:ss}->当前保存文件:", $"{Path.GetFileNameWithoutExtension(lpNewFileName)}"});
            Variables.setting.TheLastSavePath = $"{Variables.setting.AutoSavePath}\\{Path.GetFileName(lpNewFileName)}";
            Variables.setting.Save();
            return Variables.setting.TheLastSavePath;
        }
    }
}