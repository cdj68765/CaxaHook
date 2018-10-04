using System;
using System.Diagnostics;
using System.IO;

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
                File.WriteAllBytes(filePath, v);
            }
            catch (Exception e)
            {
                Variables.MainForm.OntherLog.Add(
                    new[] { $"{DateTime.Now:hh:mm:ss}->{e.Message}", $"" });
                return;
            }

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
    }
}