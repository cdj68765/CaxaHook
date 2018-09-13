using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EasyHook;
using ETCTool;

namespace CaxaInject
{
    public class Main : IEntryPoint
    {
        private CaxaHookInterface Interface;

        public Main(
            RemoteHooking.IContext InContext,
            String InChannelName)
        {
            Interface = RemoteHooking.IpcConnectClient<CaxaHookInterface>(InChannelName);
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Unicode, SetLastError = true)]
        private delegate int StgCreateStorageEx(StringBuilder Wchar, int grfMode, int stgfmt, int grfAttrs, IntPtr pStgOptions, IntPtr pSecurityDescriptor, Guid riid, IntPtr ppObjectOpen);

        public void Run(
            RemoteHooking.IContext InContext,
            String InChannelName)
        {
            LocalHook CreateHook = null;
            try
            {
                CreateHook = LocalHook.Create(LocalHook.GetProcAddress("dftdb.dll", "StgCreateStorageEx"), new StgCreateStorageEx(StgCreateStorageEx_Hooked), this);
                CreateHook.ThreadACL.SetExclusiveACL(new Int32[] { 0 });
                Interface.Info("安装成功");
                while (true)
                {
                    Interface.Ping(out bool Ping);
                    if (Ping == false) break;
                    Thread.Sleep(1000);
                }
            }
            catch (Exception ex)
            {
                Interface.Info(ex.ToString());
            }
            finally
            {
                CreateHook.Dispose();
            }
        }

        private int StgCreateStorageEx_Hooked(StringBuilder Wchar, int grfMode, int stgfmt, int grfAttrs, IntPtr pStgOptions, IntPtr pSecurityDescriptor, Guid riid, IntPtr ppObjectOpen)
        {
            Main This = (Main)HookRuntimeInfo.Callback;
            This.Interface.HookInfo(Wchar, grfMode, stgfmt, grfAttrs, pStgOptions, pSecurityDescriptor, riid, ppObjectOpen);
            var Ret = LocalHook.GetProcDelegate<StgCreateStorageEx>("dftdb.dll", "StgCreateStorageEx");
            return Ret(Wchar, grfMode, stgfmt, grfAttrs, pStgOptions, pSecurityDescriptor, riid, ppObjectOpen);
        }
    }
}