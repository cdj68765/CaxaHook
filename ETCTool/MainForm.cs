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
            RunMode.Checked = Properties.Settings.Default.RunMode;

            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900,
                Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
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
            }
            else
            {
                StartAllFuntion.Text = @"启动下列勾选功能";
                CheckClipbrdFuntion.Enabled = true;
                CheckCaxaFuntion.Enabled = true;
                CheckPlmFuntion.Enabled = true;
            }
        }
        private void RunMode_CheckedChanged(object sender, System.EventArgs e)
        {
            Properties.Settings.Default.RunMode = RunMode.Checked;
            Properties.Settings.Default.Save();
        //   AutoRunServer.UninstallService(Properties.Settings.Default.OriPath);
            if (RunMode.Checked)
            {
                if (AutoRunServer.IsServiceExisted("ETCToolService"))
                {
                    //AutoRunServer.InstallService(Properties.Settings.Default.OriPath);
                    AutoRunServer.ServiceStart("ETCToolService");
                }
                else
                {
                    AutoRunServer.InstallService(Properties.Settings.Default.OriPath);
                }
            }
            else
            {
                if (AutoRunServer.IsServiceExisted("ETCToolService"))
                {
                    AutoRunServer.UninstallService("ETCToolService");
                }
            }
            return;
            if (RunMode.Checked)
            {
                using (RegistryKey LocalMachine = Registry.LocalMachine)
                {
                    using (RegistryKey SubKey = LocalMachine.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run"))
                    {
                        SubKey.SetValue("ETCTool", Properties.Settings.Default.OriPath);
                    }
                }
            }
            else
            {
                using (RegistryKey LocalMachine = Registry.LocalMachine)
                {
                    using (RegistryKey SubKey = LocalMachine.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run"))
                    {
                        SubKey.DeleteValue("ETCTool", false);
                    }
                }
            }
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
