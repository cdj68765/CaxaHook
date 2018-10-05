using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Microsoft.VisualBasic.FileIO;

namespace ETCTool
{
    public class LdTermInInterface : MarshalByRefObject
    {
        public void Info(string v)
        {
            Variables.MainForm.OntherLog.Add(new[] { $"{DateTime.Now:hh:mm:ss}->{v}", "" });
        }

        public void RetOpenDate(string filePath, byte[] v, string operaMode)
        {
            try
            {
                HisFileData.Save(new FileData{ Time = $"{File.GetLastWriteTime(filePath).ToLocalTime()}", File = filePath, Data = v });
                FileSystem.DeleteFile(filePath, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                Thread.Sleep(500);
                FileSystem.WriteAllBytes(filePath, v, false);


            if (operaMode == "Open")
            {
                Variables.MainForm.OntherLog.Add(
                    new[] { $"{DateTime.Now:hh:mm:ss}->文件[{Path.GetFileName(filePath)}]打开完毕", $"" });
                Process.Start(filePath);
            }
            else
            {
                Variables.MainForm.OntherLog.Add(
                    new[] { $"{DateTime.Now:hh:mm:ss}->文件[{Path.GetFileName(filePath)}]解密完毕", $"" });
                }
            }
            catch (Exception e)
            {
                Variables.MainForm.OntherLog.Add(
                    new[] { $"{DateTime.Now:hh:mm:ss}->{e.Message}", $"" });
                return;
            }
        }
    }
}