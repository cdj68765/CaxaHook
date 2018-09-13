using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETCTool
{
    public class CaxaHookInterface : MarshalByRefObject
    {
        public void HookInfo(StringBuilder wchar, int grfMode, int stgfmt, int grfAttrs, IntPtr pStgOptions, IntPtr pSecurityDescriptor, Guid riid, IntPtr ppObjectOpen)
        {
            Console.WriteLine();
        }

        public void Ping(out bool ping)
        {
            Variables.MainForm.AutoSaveLog.Add(new[] { $"{DateTime.Now:hh:mm:ss}->:", $"ping" });
            ping = true;
        }

        public void Info(string v)
        {
            Variables.MainForm.AutoSaveLog.Add(new[] { $"{DateTime.Now:hh:mm:ss}->:", $"{v}" });
        }
    }
}