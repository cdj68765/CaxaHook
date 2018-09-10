using System;
using System.Collections;
using System.Configuration.Install;
using System.Linq;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using Microsoft.Win32;

namespace ETCTool
{
    internal class AutoRunServer
    {
        public static bool IsServiceExisted()
        {
            foreach (var sc in ServiceController.GetServices().AsParallel())
                if (sc.ServiceName == "ETCToolService")
                    return true;

            return false;
        }

        //安装服务
        public static void InstallService(string serviceFilePath)
        {
            using (var installer = new AssemblyInstaller())
            {
                installer.UseNewContext = true;
                installer.Path = serviceFilePath;
                IDictionary savedState = new Hashtable();
                installer.CommandLine = new[] {"StartService"};
                installer.Install(savedState);
                installer.Commit(savedState);
            }
        }

        //卸载服务
        public static void UninstallService(string serviceFilePath)
        {
            using (var installer = new AssemblyInstaller())
            {
                installer.UseNewContext = true;
                installer.Path = serviceFilePath;
                installer.Uninstall(null);
                installer.Dispose();
            }
        }

        //启动服务
        public static void ServiceStart()
        {
            using (var control = new ServiceController("ETCToolService"))
            {
                if (control.Status == ServiceControllerStatus.Stopped) control.Start();
            }
        }

        public static void Change(string serviceName)
        {
            using (var control = new ServiceController(serviceName))
            {
                if (control.Status == ServiceControllerStatus.Stopped) control.ServiceName = "ETCTool";
            }
        }

        //停止服务
        public static void ServiceStop()
        {
            if (!IsServiceExisted()) return;
            using (var control = new ServiceController("ETCToolService"))
            {
                if (control.Status == ServiceControllerStatus.Running) control.Stop();
            }
        }

        /// <summary>
        ///     设置服务启动类型
        ///     2为自动 3为手动 4 为禁用
        /// </summary>
        /// <param name="startType"></param>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        public static bool ChangeServiceStartType(object Value, string Valuename)
        {
            try
            {
                Registry.LocalMachine.OpenSubKey($@"SYSTEM\CurrentControlSet\Services\ETCToolService", true)
                    .SetValue(Valuename, Value, RegistryValueKind.DWord);
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public static bool CheckStartMode()
        {
            try
            {
                return int.Parse(Registry.LocalMachine.OpenSubKey($@"SYSTEM\CurrentControlSet\Services\ETCToolService")
                           .GetValue("Start").ToString()) == 2;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [DllImport("advapi32.dll")]
        public static extern IntPtr OpenSCManager(string lpMachineName, string lpSCDB, int scParameter);

        [DllImport("Advapi32.dll")]
        public static extern IntPtr CreateService(IntPtr SC_HANDLE, string lpSvcName, string lpDisplayName,
            int dwDesiredAccess, int dwServiceType, int dwStartType, int dwErrorControl, string lpPathName,
            string lpLoadOrderGroup, int lpdwTagId, string lpDependencies, string lpServiceStartName,
            string lpPassword);

        [DllImport("advapi32.dll")]
        public static extern void CloseServiceHandle(IntPtr SCHANDLE);

        [DllImport("advapi32.dll")]
        public static extern int StartService(IntPtr SVHANDLE, int dwNumServiceArgs, string lpServiceArgVectors);

        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern IntPtr OpenService(IntPtr SCHANDLE, string lpSvcName, int dwNumServiceArgs);

        [DllImport("advapi32.dll")]
        public static extern int DeleteService(IntPtr SVHANDLE);

        [DllImport("kernel32.dll")]
        public static extern int GetLastError();

        public static bool UnInstallService(string svcName = "ETCToolService")
        {
            var GENERIC_WRITE = 0x40000000;
            var sc_hndl = OpenSCManager(null, null, GENERIC_WRITE);
            if (sc_hndl.ToInt32() != 0)
            {
                var DELETE = 0x10000;
                var svc_hndl = OpenService(sc_hndl, svcName, DELETE);
                if (svc_hndl.ToInt32() != 0)
                {
                    var i = DeleteService(svc_hndl);
                    if (i != 0)
                    {
                        CloseServiceHandle(sc_hndl);
                        return true;
                    }

                    CloseServiceHandle(sc_hndl);
                    return false;
                }

                return false;
            }

            return false;
        }
    }
}