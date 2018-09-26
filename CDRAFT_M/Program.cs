using ETCTool;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;

namespace CDRAFT_M
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IpcClientChannel channel = new IpcClientChannel();
            ChannelServices.RegisterChannel(channel, false);
            var remoteDataHandle = (RemoteDataHandle)Activator.GetObject(typeof(RemoteDataHandle),
                "ipc://EtcToolChannel/RemoteDataHandle");
            var path = remoteDataHandle.FIlePath;
            try
            {
                List<byte> Date = new List<byte>();
                var memoryFile = MemoryMappedFile.CreateFromFile(path,
                FileMode.Open, Path.GetFileName(path));
                var stream = memoryFile.CreateViewStream();
                remoteDataHandle.Save(path);
                //remoteDataHandle.Info($"{Data[0]}-{Data[1]}-{Data[2]}");
                /* using (var FileStream = new FileStream(args[0], FileMode.Open))
                 {
                     int Temp;
                     do
                     {
                         Temp = FileStream.ReadByte();
                         Date.Add(Convert.ToByte(Temp));
                     } while (Temp != -1);

                     // remoteDataHandle.Info($"返回数据2{Convert.ToByte(FileStream.ReadByte())}-{Convert.ToByte(FileStream.ReadByte())}-{Convert.ToByte(FileStream.ReadByte())}");
                 }*/
                // remoteDataHandle.RetDate(args[0], Date.ToArray());
                //remoteDataHandle.RetDate(path, File.ReadAllBytes(path));
            }
            catch (Exception E)
            {
                remoteDataHandle.Info($"{E.Message}");
            }
            finally
            {
                ChannelServices.UnregisterChannel(channel);
            }
        }
    }
}