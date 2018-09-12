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
    }
}