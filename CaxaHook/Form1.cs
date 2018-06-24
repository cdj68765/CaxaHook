using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using EasyHook;
using VisualPlus.Events;
using VisualPlus.Toolkit.Dialogs;

namespace CaxaHook
{
    public partial class Form1 : VisualForm
    {
        readonly System.Timers.Timer TimeSPan = new System.Timers.Timer(1000);
        static String ChannelName = null;
        public bool HookStatus = false;

        public Form1()
        {
            InitializeComponent();
            ThreadPool.QueueUserWorkItem((object state) => { InstallHookTo_Process(NativeApi.GetProcessID("CDRAFT_M.exe")); });
        
            Class1.RuntimeInfo =
                new RuntimeInfo(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)).Load();
            if (!string.IsNullOrEmpty(Class1.RuntimeInfo.SavePath))
            {
                SelectSavePath.Text = Class1.RuntimeInfo.SavePath;
                TimeSpanNum.Value = Class1.RuntimeInfo.TimeSelect;
                RunOrStop.Toggled = Class1.RuntimeInfo.RunStatus;
                RunOrStop.Enabled = true;
            }

            if (RunOrStop.Toggled)
            {
                Start();
            }

            TimeSPan.AutoReset = true;
            TimeSPan.Elapsed += delegate
            {
                if (TryToHookTime())
                {
                    TimeSpanBar.Invoke(new Action(() =>
                    {
                        TimeSpanBar.Value += 1;
                        TimeSpanBar.Refresh();
                    }));
                }
                else
                {
                    TimeSpanBar.Invoke(new Action(() =>
                    {
                        TimeSpanBar.Value = 0;
                        TimeSpanBar.Refresh();
                    }));
                }
            };
            TimeSpanBar.ValueChanged += delegate
            {

                if (TimeSpanBar.Value >= TimeSpanBar.Maximum)
                {
                    TimeSpanBar.Value = 0;
                    NativeApi.WindowsLoopFindHwnd(out string WindowsName);
                    //工程图文档2
                    var FileName = Path.GetFileName(WindowsName.Split('[')[1].Split(']')[0]);
                    if (!FileName.StartsWith("工程图文档") && FileName.IndexOf("只读", StringComparison.Ordinal) == -1)
                    {
                        Class1.savefile = $@"{SelectSavePath.Text}\{FileName.Split('.')[0]}#{DateTime.Now:MM月dd日 HH时mm分}.{FileName.Split('.')[1].Replace("*", "")}";
                        var save = $@"{SelectSavePath.Text}\{FileName.Split('.')[0]}#{DateTime.Now:MM月dd日 HH时mm分}.{FileName.Split('.')[1].Replace("*", "")}";
                        if (NativeApi.CheckForegroundWindow())
                        {
                            NativeApi.KeySaveBykeybd_event();
                        }

                    }
                }
            };

            bool TryToHookTime()
            {
                var pid = NativeApi.GetProcessID("CDRAFT_M.exe");
                if (pid != -1)
                {
                    Invoke(new Action(() =>
                    {
                        PIDLabel.Text = $@"CAXA PID：{pid}";
                        PIDLabel.ForeColor = Color.LightSeaGreen;
                    }));
                    if (!HookStatus) InstallHookTo_Process(pid);
                    return true;
                }
                else
                {
                    HookStatus = false;
                    Invoke(new Action(() =>
                    {
                        PIDLabel.Text = $@"CAXA PID：未找到Caxa程序";
                        PIDLabel.ForeColor = Color.Red;
                    }));
                    return false;
                }
            }



            FormClosed += delegate { SaveStatus(); };
        }

        void InstallHookTo_Process(int PID)
        {
            try
            {
                Config.DependencyPath = Class1.RuntimeInfo.Path;
                Config.HelperLibraryLocation = Class1.RuntimeInfo.Path;
                RemoteHooking.IpcCreateServer<HookDealWith>(ref ChannelName, WellKnownObjectMode.SingleCall);
                RemoteHooking.Inject(
                    PID,
                    InjectionOptions.Default,
                    $"{Class1.RuntimeInfo.Path}\\CaxaInject.dll",
                    $"{Class1.RuntimeInfo.Path}\\CaxaInject.dll",
                    ChannelName
                );
            }
            catch (Exception ex)
            {
                HookStatus = false;
                // return false;
            }

            HookStatus = true;
            // return true;
        }

        private void SeletSaveButton()
        {
            var FolderOpen = new FolderBrowserDialog()
            {
                Description = @"选择保存目录"
            };
            FolderOpen.ShowDialog();
            if (!string.IsNullOrEmpty(FolderOpen.SelectedPath) && new DirectoryInfo(FolderOpen.SelectedPath).Exists)
            {
                SelectSavePath.Text = FolderOpen.SelectedPath;
                Class1.RuntimeInfo.SavePath = FolderOpen.SelectedPath;
                SaveStatus();
                RunOrStop.Enabled = true;
            }
        }

        private void SeletSaveButton(object sender, MouseEventArgs e)
        {
            SeletSaveButton();
        }

        private void RunOrStop_ToggleChanged(ToggleEventArgs e)
        {
            if (e.State)
            {
                RunOrStop.ButtonColorState.Enabled = Color.LightGreen;
                Start();
            }
            else
            {
                RunOrStop.ButtonColorState.Enabled = Color.Red;
                TimeSPan.Stop();
                TimeSpanBar.Value = 0;
                Refresh();
            }

            SaveStatus();
        }


        private void Start()
        {
            TimeSpanBar.Maximum = (int) (60 * TimeSpanNum.Value);
            TimeSPan.Start();
        }

        private void TimeSpanNum_ValueChanged(ValueChangedEventArgs e)
        {
            TimeSpanBar.Maximum = (int) (60 * TimeSpanNum.Value);
        }

        void SaveStatus()
        {
            Class1.RuntimeInfo.SavePath = SelectSavePath.Text = Class1.RuntimeInfo.SavePath;
            Class1.RuntimeInfo.TimeSelect = TimeSpanNum.Value;
            Class1.RuntimeInfo.RunStatus = RunOrStop.Toggled;
            Class1.RuntimeInfo.Save();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // NativeApi.OperaKeyBySend();
            Thread.Sleep(1000);
            NativeApi.WindowsLoopFindHwnd(out string WindowsName);
            //工程图文档2
            var FileName = Path.GetFileName(WindowsName.Split('[')[1].Split(']')[0]);
            if (!FileName.StartsWith("工程图文档") && FileName.IndexOf("只读", StringComparison.Ordinal)==-1)
            {
                Class1.savefile = $@"{SelectSavePath.Text}\{FileName.Split('.')[0]}#{DateTime.Now:MM月dd日 HH时mm分}.{FileName.Split('.')[1].Replace("*","")}";
                var save = $@"{SelectSavePath.Text}\{FileName.Split('.')[0]}#{DateTime.Now:MM月dd日 HH时mm分}.{FileName.Split('.')[1].Replace("*", "")}";
                if (NativeApi.CheckForegroundWindow())
                {
                    NativeApi.KeySaveBykeybd_event();
                }
            
            }

        }
    }
}
