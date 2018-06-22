using EasyHook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaxaHook
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private int pID;
        static String ChannelName = null;

        public void Run(int pID)
        {
            this.pID = pID;
            if (InstallHookTo_Process())
            {
                label3.Text = "XXXX";
            }
        }

        private bool InstallHookTo_Process()
        {
            try
            {

                string injectionLibrary =
                    Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location),
                        "CaxaInject.dll");
                RemoteHooking.IpcCreateServer<HookDealWith>(ref ChannelName, WellKnownObjectMode.SingleCall);
                RemoteHooking.Inject(
                    pID,
                    InjectionOptions.Default,
                    injectionLibrary,
                    injectionLibrary,
                    ChannelName
                );
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
                return false;
            }

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int PID = -1;
            foreach (var disk in new ManagementObjectSearcher(new SelectQuery("Select * from Win32_Process")).Get())
            {
                if (disk["Name"].ToString() == "CDRAFT_M.exe")
                {
                    PID = int.Parse(disk["ProcessId"].ToString());
                    break;
                }
            }

            if (PID == -1)
            {
                return;
            }

            var _Process = Process.GetProcessById(PID);
            if (_Process == null)
            {
                return;
            }

            label2.Text = PID.ToString();
            Run(PID);
        }
    }
}

