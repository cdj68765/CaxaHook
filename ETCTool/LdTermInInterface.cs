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
        }

        public void ReadFile()
        {
            var retd = File.ReadAllBytes(@"C:\Users\Administrator\Desktop\TEST\1.pdf");
            Variables.MainForm.OntherLog.Add(new[] { $"{DateTime.Now:hh:mm:ss}->2+{retd[0]}-{retd[1]}-{retd[2]}", "" });
        }
    }
}