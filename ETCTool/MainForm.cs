using System;
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
            CheckClipbrdFuntion.Checked = Properties.Settings.Default.CheckClipbrdFuntion;
            CheckPlmFuntion.Checked = Properties.Settings.Default.CheckPlmFuntion;
            CheckCaxaFuntion.Checked = Properties.Settings.Default.CheckCaxaFuntion;
            AutoRunMode.Checked = CheckAutoRun();
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900,
                Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            WindowState = FormWindowState.Minimized;
            // ShowInTaskbar = false;
            new Mutex(true, "ClipboardControl", out var Close);
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
                Properties.Settings.Default.RunMode = true;
            }
            else
            {
                StartAllFuntion.Text = @"启动下列勾选功能";
                CheckClipbrdFuntion.Enabled = true;
                CheckCaxaFuntion.Enabled = true;
                CheckPlmFuntion.Enabled = true;
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
        #endregion

        #region 主窗口状态条

        private void MainTabClipbrdStation_MouseClick(object sender, MouseEventArgs e)
        {
            TabClipbrd.Select();
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

        private void MainTabAutoSaveStation_MouseClick(object sender, MouseEventArgs e)
        {
            TabAutoSave.Select();
        }

        private void MainTabAutoSaveStation_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MainTab.SelectedIndex = 3;
        }
        #endregion

        #endregion

    }
}
