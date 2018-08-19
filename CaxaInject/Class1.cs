using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EasyHook;

namespace CaxaInject
{
    public class Main : EasyHook.IEntryPoint
    {

        public Main(
            RemoteHooking.IContext InContext,
            String InChannelName)
        {
          
        }

        public void Run(
            RemoteHooking.IContext InContext,
            String InChannelName)
        {
         
        }
    }
}
