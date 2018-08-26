using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Win32;

namespace ETCTool
{
    public partial class MainForm : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        public MainForm()
        {
            InitializeComponent();
            #region 状态初始化
            CheckClipbrdFuntion.Checked = Properties.Settings.Default.CheckClipbrdFuntion;
            CheckPlmFuntion.Checked = Properties.Settings.Default.CheckPlmFuntion;
            CheckCaxaFuntion.Checked = Properties.Settings.Default.CheckCaxaFuntion;
            CheckFileDecrypt.Checked = Properties.Settings.Default.CheckFileDecrypt;
            #endregion


            AutoRunMode.Checked = CheckAutoRun();
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900,
                Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
           
            new Mutex(true, "ETCTool", out var Close);
            if (!Close)
            {
                Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(1500);
                    this.Close();
                    Application.Exit();
                    Application.ExitThread();
                });
            }
            if (Properties.Settings.Default.RunMode)
            {
                WindowState = FormWindowState.Minimized;
                ShowInTaskbar = false;
                Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(1500);
                    this.Invoke(new Action(() =>
                    {
                        StartAllFuntion.PerformClick();
                    }));
                });
            }
            this.Deactivate += delegate
            {
                if (this.WindowState == FormWindowState.Minimized)
                {
                    if (Properties.Settings.Default.RunMode)
                    {
                        ShowInTaskbar = false;
                    }
                }
            };
        }
        bool  CheckAutoRun()
        {
            if (AutoRunServer.IsServiceExisted())
            {
               return AutoRunServer.CheckStartMode();
            }
          return  false;
        }

        #region 主界面代码段

        private void StartAllFuntion_Click(object sender, System.EventArgs e)
        {
            if (StartAllFuntion.Text == @"启动下列勾选功能")
            {
                StartAllFuntion.Text = @"关闭所有功能";
                CheckClipbrdFuntion.Enabled = false;
                CheckCaxaFuntion.Enabled = false;
                CheckPlmFuntion.Enabled = false;
                CheckFileDecrypt.Enabled = false;
                Properties.Settings.Default.RunMode = true;

            }
            else
            {
                StartAllFuntion.Text = @"启动下列勾选功能";
                CheckClipbrdFuntion.Enabled = true;
                CheckCaxaFuntion.Enabled = true;
                CheckPlmFuntion.Enabled = true;
                CheckFileDecrypt.Enabled = true;
                Properties.Settings.Default.RunMode = false;
            }

            Properties.Settings.Default.Save();
        }
        private void RunMode_Click(object sender, System.EventArgs e)
        {
            var Status = AutoRunMode.Checked;
            AutoRunMode.Enabled = false;
            var StartChange = new Task(() =>
            {
                if (Status)
                {
                    if (!AutoRunServer.IsServiceExisted())
                    {
                        AutoRunServer.InstallService( Application.ExecutablePath);
                        //AutoRunServer.InstallService(Properties.Settings.Default.OriPath);
                    }
                    else
                    {
                        Status = AutoRunServer.ChangeServiceStartType(2, "Start");
                    }
                }
                else
                {
                    if (AutoRunServer.IsServiceExisted())
                    {
                        //AutoRunServer.UninstallService(Properties.Settings.Default.OriPath);
                        Status = !AutoRunServer.ChangeServiceStartType(3,"Start");
                    }
                }
            });
            StartChange.ContinueWith(obj =>
            {
                Invoke(new Action(() =>
                {
                    AutoRunMode.Checked = Status;
                    AutoRunMode.Enabled = true;
                }));
            });
            StartChange.Start();
        }

        private void DeleteAutoRunService_Click(object sender, EventArgs e)
        {
            if (AutoRunServer.IsServiceExisted())
            {
                AutoRunServer.UnInstallService();
            }
            AutoRunMode.Checked = false;
            AutoRunMode.Enabled = false;
        }

        #region 功能勾选段

        private void CheckClipbrdFuntion_MouseClick(object sender, MouseEventArgs e)
        {
            Properties.Settings.Default.CheckClipbrdFuntion = CheckClipbrdFuntion.Checked;
            Properties.Settings.Default.Save();
        }
        private void CheckPlmFuntion_MouseClick(object sender, MouseEventArgs e)
        {
            Properties.Settings.Default.CheckPlmFuntion = CheckPlmFuntion.Checked;
            Properties.Settings.Default.Save();
        }

        private void CheckCaxaFuntion_MouseClick(object sender, MouseEventArgs e)
        {
            Properties.Settings.Default.CheckCaxaFuntion = CheckCaxaFuntion.Checked;
            Properties.Settings.Default.Save();
        }
        private void CheckFileDecrypt_MouseClick(object sender, MouseEventArgs e)
        {
            Properties.Settings.Default.CheckFileDecrypt = CheckFileDecrypt.Checked;
            Properties.Settings.Default.Save();
        }
        #endregion

        #region 主窗口状态条

        private void MainTabClipbrdStation_MouseClick(object sender, MouseEventArgs e)
        {
            TabCaxa.Select();
        }

        private void MainTabClipbrdStation_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MainTab.SelectedIndex = 1;
        }

        private void MainTabPlmStation_MouseClick(object sender, MouseEventArgs e)
        {
            TabPlm.Select();
        }

        private void MainTabPlmStation_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MainTab.SelectedIndex = 2;
        }

        private void MainTabMainTabFileDecryptStationStation_MouseClick(object sender, MouseEventArgs e)
        {
            TabAnother.Select();
        }

        private void MainTabMainTabFileDecryptStationStation_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MainTab.SelectedIndex = 3;
        }
        #endregion

        #endregion
        #region Caxa相关代码段
        private void Buttom_TextChanged(object sender, EventArgs e)
        {
           var Buttom= sender as MaterialFlatButton;
            if (!Buttom.Text.StartsWith("启动"))
            {
                Buttom.Icon = Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream($"ETCTool.ICO.Start.ico"));
            }
            else
            {
                Buttom.Icon = Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream($"ETCTool.ICO.Stop.ico"));
            }
        }
        private void Buttom_Click(object sender, EventArgs e)
        {
            var Buttom = sender as MaterialFlatButton;
            Buttom.Text = Buttom.Text.StartsWith("启动") ? Buttom.Text.Replace("启动", "关闭") : Buttom.Text.Replace("关闭", "启动");
        }


        #endregion
        #region 任务栏图标
        private void Notify_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                (sender as NotifyIcon).ContextMenuStrip = NotifyContextMenuStrip;
            }
        }
        private void ShowForm_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }
        private void Notify_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
            }
           
        }
        private void NotifyStartRun_MouseUp(object sender, MouseEventArgs e)
        {
            if (NotifyStartRun.Text.StartsWith("启动"))
            {
                NotifyStartRun.Text = NotifyStartRun.Text.Replace("启动", "关闭");

                NotifyStartRun.Image = Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream($"ETCTool.ICO.Start.ico"));

            }
            else
            {
                NotifyStartRun.Text = NotifyStartRun.Text.Replace("关闭", "启动");
                NotifyStartRun.Image = Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream($"ETCTool.ICO.Stop.ico"));
            }
        }
        #endregion


    }
}
