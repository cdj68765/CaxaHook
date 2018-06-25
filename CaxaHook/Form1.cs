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
using VisualPlus.Enumerators;
using VisualPlus.Events;
using VisualPlus.Toolkit.Child;
using VisualPlus.Toolkit.Controls.DataVisualization;
using VisualPlus.Toolkit.Dialogs;

namespace CaxaHook
{
    public partial class Form1 : VisualForm
    {
        private readonly System.Timers.Timer TimeSPan = new System.Timers.Timer(1000);
        public bool HookStatus = false;
        public bool SetHook = false;

        public Form1()
        {
            InitializeComponent();
            Class1.RuntimeInfo =
                new RuntimeInfo(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)).Load();

            Load += delegate
            {
                if (!string.IsNullOrWhiteSpace(Class1.RuntimeInfo.SavePath))
                {
                    SelectSavePath.Text = Class1.RuntimeInfo.SavePath;
                    TimeSpanNum.Value = Class1.RuntimeInfo.TimeSelect;
                    RunOrStop.Toggled = Class1.RuntimeInfo.RunStatus;
                    ALLSAVECOUNT.Text = Class1.RuntimeInfo.ALLSAVECOUNT.ToString();
                    OneSaveCount.Text = Class1.RuntimeInfo.OneSaveCount.ToString();
                    /*  int.TryParse(ALLSAVECOUNT.Text, out int rc);
                      if (Class1.RuntimeInfo.SaveList.Count >= rc)
                      {
                          ErrorCount.Text = @"已经达到最大总量数，请尽快清空";
                      }*/
                    RunOrStop.Enabled = true;
                }

                if (Class1.RuntimeInfo.SaveList == null)
                {
                    Class1.RuntimeInfo.SaveList = new Dictionary<string, List<RuntimeInfo.FileInfo>>();
                }
                else
                {
                    AutoSaveListUpdate();
                }

                if (RunOrStop.Toggled)
                {
                    Start();
                }
            };




            TimeSPan.AutoReset = true;
            TimeSPan.Elapsed += delegate
            {
                try
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
                }
                catch (Exception e)
                {

                }

            };
            TimeSpanBar.ValueChanged += delegate
            {
                if (TimeSpanBar.Value >= TimeSpanBar.Maximum)
                {
                    TimeSpanBar.Value = 0;
                    NativeApi.WindowsLoopFindHwnd(out string WindowsName);
                    if (string.IsNullOrEmpty(WindowsName))
                    {
                        AddLog("错误，窗口为空");
                        return;
                    }

                    var SPF = WindowsName.Split('[');
                    if (SPF.Length < 2)
                    {
                        AddLog("错误，未找到文档");
                        return;
                    }

                    var FileName = Path.GetFileName(SPF[1].Split(']')[0]);
                    if (FileName.EndsWith("*"))
                    {
                        if (!FileName.StartsWith("工程图文档") && FileName.IndexOf("只读", StringComparison.Ordinal) == -1)
                        {
                            SetHook = true;
                            Thread.Sleep(1000);
                            var exb = Path.GetExtension(FileName).Replace("*", "");
                            Class1.savefile = $@"#{DateTime.Now:MM月dd日 HH时mm分}{exb}";
                            if (NativeApi.CheckForegroundWindow())
                            {
                                NativeApi.KeySaveBykeybd_event();
                            }
                        }
                        else
                        {
                            AddLog("错误，当前文档为只读或者新建文档");
                        }
                    }
                }
            };

            bool TryToHookTime()
            {
                var pid = NativeApi.GetProcessID("CDRAFT_M.exe");
                if (pid != -1)
                {
                    if (!Class1.Form1.IsDisposed)
                    {
                        try
                        {
                            Invoke(new Action(() =>
                            {
                                PIDLabel.Text = $@"CAXA PID：{pid}";
                                PIDLabel.ForeColor = Color.LightSeaGreen;
                            }));
                        }
                        catch (Exception e)
                        {
                        }

                    }

                    if (!HookStatus)
                    {
                        InstallHookTo_Process(pid);
                    }

                    return true;
                }
                else
                {
                    if (HookStatus) AddLog($"Caxa关闭");
                    HookStatus = false;
                    if (!Class1.Form1.IsDisposed)
                    {
                        try
                        {
                            Invoke(new Action(() =>
                            {

                                if (!Class1.Form1.IsDisposed)
                                {
                                    PIDLabel.Text = $@"CAXA PID：未找到Caxa程序";
                                    HookAddress.Text = @"Hook Address：";
                                    PIDLabel.ForeColor = Color.Red;
                                }

                            }));
                        }
                        catch (Exception e)
                        {
                        }

                    }

                    return false;
                }
            }

            FormClosing += delegate
            {
                Class1.RuntimeInfo.ALLSAVECOUNT = int.Parse(ALLSAVECOUNT.Text);
                Class1.RuntimeInfo.OneSaveCount = int.Parse(OneSaveCount.Text);
                TimeSPan.Close();
                UninstallAllHooks = true;
                NativeAPI.LhUninstallAllHooks();
                SaveStatus();
            };
        }

        void AutoSaveListUpdate()
        {
            Invoke(new Action(() =>
            {
                AutoSaveList.BeginUpdate();
                AutoSaveList.Items.Clear();
                foreach (var VARIABLE in Class1.RuntimeInfo.SaveList.ToList()
                    .OrderByDescending(x => x.Value[x.Value.Count - 1].Date))
                {
                    var Find = AutoSaveList.Items.Find(VARIABLE.Key, false);
                    if (Find.Length == 0)
                    {
                        AutoSaveList.Items.Add(AddItem(VARIABLE.Key, VARIABLE.Value));
                    }
                }

                AutoSaveList.EndUpdate();
            }));
        }

        internal void SaveToAutoBackList(string onlyFileName, string path)
        {
            ThreadPool.QueueUserWorkItem((object state) =>
            {

                if (Class1.RuntimeInfo.SaveList.ContainsKey(onlyFileName))
                {
                    Class1.RuntimeInfo.SaveList[onlyFileName].Add(new RuntimeInfo.FileInfo(path, DateTime.Now));

                }
                else
                {
                    if (Class1.RuntimeInfo.SaveList.Count >= int.Parse(ALLSAVECOUNT.Text))
                    {
                        Class1.RuntimeInfo.SaveList.Remove(Class1.RuntimeInfo.SaveList.ToList()
                            .OrderBy(x => x.Value[x.Value.Count - 1].Date).First().Key);
                       // ErrorCount.Text = "已经达到最大总量数，请尽快清空";
                    }
                    Class1.RuntimeInfo.SaveList.Add(onlyFileName,
                        new List<RuntimeInfo.FileInfo>() {new RuntimeInfo.FileInfo(path, DateTime.Now)});
                }

                AutoSaveListUpdate();
            });
        }

        private VisualListViewItem AddItem(string onlyFileName, List<RuntimeInfo.FileInfo> saveList)
        {
            VisualListViewItem _item = new VisualListViewItem(Text = saveList[saveList.Count - 1].Date.ToString("F"));
            VisualListViewSubItem _content = new VisualListViewSubItem(saveList.Count.ToString());

            VisualListViewSubItem _date = new VisualListViewSubItem()
            {
                EmbeddedControl = new Label
                {
                    Text = onlyFileName,
                    TextAlign = System.Drawing.ContentAlignment.MiddleLeft
                }
            };
            VisualListViewSubItem _progress = new VisualListViewSubItem
            {
                EmbeddedControl = new VisualProgressBar
                {
                    Maximum = int.Parse(OneSaveCount.Text),
                    Value = saveList.Count
                }
            };
            VisualListViewSubItem _path = new VisualListViewSubItem
            {
                EmbeddedControl = new Label
                {
                    Text = saveList[saveList.Count - 1].FilePath,
                    TextAlign = System.Drawing.ContentAlignment.MiddleLeft
                }
            };
            _item.SubItems.Add(_content);
            _item.SubItems.Add(_date);
            _item.SubItems.Add(_progress);
            _item.SubItems.Add(_path);
            return _item;
        }

        public void AddLog(string Log)
        {
            try
            {
                Invoke(new Action(() =>
                {
                    if (LogListBox.Items.Count >= 100)
                    {
                        LogListBox.Items.Clear();
                        LogListBox.Refresh();
                    }

                    LogListBox.Items.Add($"{DateTime.Now:U},{Log}");
                    LogListBox.Invalidate();
                    LogListBox.SelectedIndex = LogListBox.Items.Count - 1;
                }));
            }
            catch (Exception e)
            {
            }
        }

        public bool UninstallAllHooks = false;

        private void InstallHookTo_Process(int PID)
        {
            try
            {
                String ChannelName = null;
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
                AddLog($"Hook失败，失败原因{ex}");
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

        private void SaveStatus()
        {
            if (!string.IsNullOrEmpty(SelectSavePath.Text))
            {
                Class1.RuntimeInfo.SavePath = SelectSavePath.Text;
                Class1.RuntimeInfo.TimeSelect = TimeSpanNum.Value;
                Class1.RuntimeInfo.RunStatus = RunOrStop.Toggled;
                Class1.RuntimeInfo.Save();
            }
        }
        public void MoreThanZeroNumCheck(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' && e.KeyChar == '.' && e.KeyChar != '\u0016' && e.KeyChar != '\u0003') //这是允许输入退格键
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9')) //这是允许输入0-9数字
                {
                    if (e.KeyChar != '-')
                    {
                        e.Handled = true;
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Class1.RuntimeInfo.Path);
            return;
            // NativeApi.OperaKeyBySend();
            Thread.Sleep(1000);
            NativeApi.WindowsLoopFindHwnd(out string WindowsName);
            //工程图文档2
            var FileName = Path.GetFileName(WindowsName.Split('[')[1].Split(']')[0]);
            if (!FileName.StartsWith("工程图文档") && FileName.IndexOf("只读", StringComparison.Ordinal) == -1)
            {
                Class1.savefile =
                    $@"{SelectSavePath.Text}\{FileName.Split('.')[0]}#{DateTime.Now:MM月dd日 HH时mm分}.{FileName.Split('.')[1].Replace("*", "")}";
                var save =
                    $@"{SelectSavePath.Text}\{FileName.Split('.')[0]}#{DateTime.Now:MM月dd日 HH时mm分}.{FileName.Split('.')[1].Replace("*", "")}";
                if (NativeApi.CheckForegroundWindow())
                {
                    NativeApi.KeySaveBykeybd_event();
                }
            }
        }

        private void OpenSaveFolder_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Class1.RuntimeInfo.SavePath);
        }

        private void OpenLast_Click(object sender, EventArgs e)
        {
            if (AutoSaveList.Items.Count != 0)
            {
                var FilePath = AutoSaveList.Items[0].SubItems[4].EmbeddedControl.Text;
                if (File.Exists(FilePath))
                {
                    Process.Start(FilePath);
                }
            }
        }

        private void CleanAllFile_Click(object sender, EventArgs e)
        {
            RunOrStop.Toggled = false;
            if (Class1.RuntimeInfo.SaveList.Count != 0)
            {
                Task.Factory.StartNew(() =>
                {
                    foreach (var VARIABLE in Class1.RuntimeInfo.SaveList)
                    {
                        foreach (var VARIABLE2 in VARIABLE.Value)
                        {
                            if (File.Exists(VARIABLE2.FilePath))
                            {
                                try
                                {
                                    File.Delete(VARIABLE2.FilePath);
                                }
                                catch (Exception exception)
                                {
                                }
                            }
                        }
                    }
                    Class1.RuntimeInfo.SaveList = new Dictionary<string, List<RuntimeInfo.FileInfo>>();
                    Class1.RuntimeInfo.Save();
                    AutoSaveListUpdate();
                 
                });

            }
        }
    }
}