using ETCTool;
using System;
using System.IO;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;

namespace CDRAFT_M
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                IpcClientChannel channel = new IpcClientChannel();
                try
                {
                    ChannelServices.RegisterChannel(channel, false);
                    var remoteDataHandle = (RemoteDataHandle)Activator.GetObject(typeof(RemoteDataHandle),
                        "ipc://EtcToolChannel/RemoteDataHandle");
                    remoteDataHandle.RetDate(args[0],File.ReadAllBytes(args[0]));
                }
                finally
                {
                    ChannelServices.UnregisterChannel(channel);
                }
            }
        }
    }
}