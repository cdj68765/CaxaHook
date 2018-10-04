using System;
using System.IO;
using System.Linq;

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
                if (Variables.setting.AdapterCaxaAutoSave) return true;

                return Variables.MainForm.StartCaxaAutoSaveHook;
            }

            return false;
        }

        public void Info(string v)
        {
            Variables.MainForm.AutoSaveLog.Add(new[] { $"{DateTime.Now:hh:mm:ss}->{v}", $"" });
        }

        public string GetNewPath(string lpNewFileName, string lpExistingFileName = "")
        {
            if (Variables.MainForm.StartCaxaAutoSaveHook)
            {
                if (Path.GetExtension(lpNewFileName).ToLower() == ".exb")
                {
                    Variables.MainForm.AutoSaveLog.Add(new[]
                        {$"{DateTime.Now:hh:mm:ss}->当前保存文件:", $"{Path.GetFileNameWithoutExtension(lpNewFileName)}"});
                    Variables.setting.TheLastSavePath =
                        $"{Variables.setting.AutoSavePath}\\{Path.GetFileNameWithoutExtension(lpNewFileName)}.exb";
                    Variables.MainForm.StartCaxaAutoSaveHook = false;
                    return Variables.setting.TheLastSavePath;
                }
            }
            else if (Variables.setting.AdapterCaxaAutoSave)
            {
                if (Path.GetExtension(lpNewFileName).ToLower() == ".eb$")
                {
                    Variables.MainForm.AutoSaveLog.Add(new[]
                    {
                        $"{DateTime.Now:hh:mm:ss}->当前保存文件:", $"{Path.GetFileNameWithoutExtension(lpExistingFileName)}"
                    });
                    Variables.setting.TheLastSavePath =
                        $"{Variables.setting.AutoSavePath}\\{Path.GetFileNameWithoutExtension(lpExistingFileName)}.exb";
                    return Variables.setting.TheLastSavePath;
                }
            }

            return lpNewFileName;
        }
    }
}