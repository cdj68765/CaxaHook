using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace ETCTool
{
    public class LdTermInInterface : MarshalByRefObject
    {
        public void Info(string v)
        {
            Variables.MainForm.OntherLog.Add(new[] {$"{DateTime.Now:hh:mm:ss}->{v}", ""});
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
                    new[] {$"{DateTime.Now:hh:mm:ss}->{e.Message}", $""});
                return;
            }

            if (operaMode == "Open")
            {
                Variables.MainForm.OntherLog.Add(
                    new[] {$"{DateTime.Now:hh:mm:ss}->打开文件{filePath}", $"{v[0]}-{v[1]}-{v[2]}"});
                Process.Start(filePath);
            }
            else
            {
                Variables.MainForm.OntherLog.Add(
                    new[] { $"{DateTime.Now:hh:mm:ss}->解密文件{filePath}", $"{v[0]}-{v[1]}-{v[2]}" });
            }

        }

        public void BatchFileOpera(string operaMode)
        {
        }
    }
}