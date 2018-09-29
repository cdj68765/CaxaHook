using System;
using System.Collections.Generic;
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
            Variables.MainForm.OntherLog.Add(new[] { $"{DateTime.Now:hh:mm:ss}->{v}", "" });
            var retd = File.ReadAllBytes("E:\\TorToMag.exe");
            Variables.MainForm.OntherLog.Add(new[] { $"{DateTime.Now:hh:mm:ss}->1+{retd[0]}-{retd[1]}-{retd[2]}", "" });
        }

        public void ReadFile()
        {
         var retd=  File.ReadAllBytes("E:\\Emil2.ppx");
            Variables.MainForm.OntherLog.Add(new[] { $"{DateTime.Now:hh:mm:ss}->2+{retd[0]}-{retd[1]}-{retd[2]}", "" });
        }
    }
}
