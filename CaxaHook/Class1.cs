using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaxaHook
{
    public class Class1
    {
        public static Form1 Form1;
    }
    public class HookDealWith : MarshalByRefObject
    {

        public void IsInstalled(Int32 InClientPID)
        {
            Console.WriteLine(InClientPID);
            Class1.Form1.Invoke(new Action(() => { Class1.Form1.label1.Text = InClientPID.ToString(); })); 
        }

        public void OnCreateFile(Int32 InClientPID, String[] InFileNames)
        {
            //Console.WriteLine(InClientPID);
            Console.WriteLine(InClientPID);
            foreach (var VARIABLE in InFileNames)
            {
                Console.WriteLine(VARIABLE);
            }
        }

        public void ReportException(Exception InInfo)
        {

        }

        public void Ping(int pid)
        {
            //  Console.WriteLine(pid);
        }

        public void info(string pwcsName, int grfMode, int stgfmt, int grfAttrs, IntPtr pStgOptions,
            IntPtr pSecurityDescriptor, ref Guid riid, ref object ppObjectOpen)
        {
            Console.WriteLine();
        }
    }
}
