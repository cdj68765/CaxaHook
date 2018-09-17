using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ETCTool
{
    public class CaxaHookInterface : MarshalByRefObject
    {
        public bool Ping(out bool ping, string Channal)
        {
            ping = Variables.AutoSaveRun;
            if (!Variables.AutoSaveRun)
            {
                try
                {
                    var Find = Variables.MainForm.CaxaPid.FirstOrDefault(x => x.Value == Channal);
                    Variables.MainForm.CaxaPid.Remove(Find.Key);
                    Variables.MainForm.AutoSaveLog.Add(new[]
                        {$"{DateTime.Now:hh:mm:ss}->进程{Find.Key}删除完毕", $""});
                }
                catch (Exception e)
                {
                    Variables.MainForm.AutoSaveLog.Add(new[]
                        {$"{DateTime.Now:hh:mm:ss}->删除错误，错误信息{e}", $""});
                }
            }
            else
            {
                return Variables.MainForm.StartCaxaAutoSaveHook;
            }
            return false;
        }

        public void Info(string v)
        {
            Variables.MainForm.AutoSaveLog.Add(new[] { $"{DateTime.Now:hh:mm:ss}->{v}:", $"" });
        }

        public string GetNewPath(string lpNewFileName)
        {
            Variables.MainForm.AutoSaveLog.Add(new[]
                {$"{DateTime.Now:hh:mm:ss}->当前保存文件:", $"{Path.GetFileNameWithoutExtension(lpNewFileName)}"});
            Variables.setting.TheLastSavePath = $"{Variables.setting.AutoSavePath}\\{Path.GetFileName(lpNewFileName)}";
            return Variables.setting.TheLastSavePath;
        }
    }
}