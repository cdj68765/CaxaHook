using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.IO.Pipes;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using static ETCTool.NativeApi;

namespace ETCTool
{
    public partial class MainForm : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;

        private void 管道通讯()
        {
            var memoryFile = MemoryMappedFile.CreateFromFile(@"C:\Users\Administrator\Desktop\FA7-10B-A10-N003.pdf", FileMode.Open, "MyFile");
            var stream = memoryFile.CreateViewStream();
            using (FileStream Cfile = new FileStream(@"C:\Users\Administrator\Desktop\FA7-10B-A10-N003-2.pdf", FileMode.OpenOrCreate))
            {
                var file = MemoryMappedFile.OpenExisting("MyFile");
                var accessor = file.CreateViewStream();
                int b = -1;
                do
                {
                    b = accessor.ReadByte();
                    if (b == -1)
                    {
                        break;
                    }
                    Cfile.WriteByte(Convert.ToByte(b));
                } while (b != -1);
            }
            using (NamedPipeServerStream pipeServer = new NamedPipeServerStream("mynamedpipe", PipeDirection.InOut))//创建管道
            {
                try
                {
                    pipeServer.WaitForConnection();//等待客户端连接
                    pipeServer.ReadMode = PipeTransmissionMode.Byte;
                    Console.WriteLine("sucess connected?" + pipeServer.IsConnected);
                    StreamReader sr = new StreamReader(pipeServer);//获取管道输入流
                    StreamWriter sw = new StreamWriter(pipeServer);//获取管道输出流
                    string result;
                    while (true)//循环接收客户端消息
                    {
                        result = sr.ReadLine();
                        if (result == null || result == "bye")
                            break;
                        Console.WriteLine(result);
                        sw.WriteLine("I'm Sever!");//返回客户端信息
                        sw.Flush();//清除缓存流，注意必须有这一步，否则会造成管道堵塞
                    }
                    Console.ReadKey();
                }
                catch (IOException e)
                {
                    throw e;
                }
            }
            using (NamedPipeClientStream pipeStream = new NamedPipeClientStream("localhost", "mynamedpipe"))//与服务端管道名一致，如果连接C++服务端，名称一致即可，“localhost”可以更换为IP地址，也可以进行网络通信
            {
                pipeStream.Connect();//连接服务端
                if (!pipeStream.IsConnected)
                {
                    Console.WriteLine("Failed to connect ....");
                    return;
                }
                StreamWriter sw = new StreamWriter(pipeStream);
                StreamReader sr = new StreamReader(pipeStream);
                while (true)//循环输入
                {
                    /* input = Console.ReadLine();
                     Console.WriteLine("SendMessage:" + input);
                     sw.WriteLine(input);//传递消息到服务端
                     sw.Flush();//注意一定要有，同服务端一样
                     string temp = "";
                     temp = sr.ReadLine();//获取服务端返回信息
                     Console.WriteLine("replyContent:" + temp);*/
                }
            }
        }

        public MainForm()
        {
            InitializeComponent();
            Task.Factory.StartNew(() =>
            {
                do
                {
                    Thread.Sleep(1000);
                    GetCursorPos(out NativeApi.Point lpPoint);
                    try
                    {
                        Invoke(new Action(() =>
                        {
                            MainTabPlmStation.Text = lpPoint.ToString();
                        }));
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                } while (true);
            });

            #region 状态初始化

            CheckClipbrdFuntion.Checked = Properties.Settings.Default.CheckClipbrdFuntion;
            CheckPlmFuntion.Checked = Properties.Settings.Default.CheckPlmFuntion;
            CheckCaxaFuntion.Checked = Properties.Settings.Default.CheckCaxaFuntion;
            CheckFileDecrypt.Checked = Properties.Settings.Default.CheckFileDecrypt;
            if (Properties.Settings.Default.FormSize == null)
            {
                Properties.Settings.Default.FormSize = new System.Collections.Specialized.StringCollection();
                Properties.Settings.Default.FormSize.AddRange(new[] { "480", "280", "480", "280", "480", "280" });
                Properties.Settings.Default.Save();
            }

            #endregion 状态初始化

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
                        NotifyStartRun.PerformClick();
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

        private bool CheckAutoRun()
        {
            if (AutoRunServer.IsServiceExisted())
            {
                return AutoRunServer.CheckStartMode();
            }

            return false;
        }

        #region 主界面代码段

        private void StartAllFuntion_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (StartAllFuntion.Text == @"启动下列勾选功能")
                {
                    StartAllFuntion.Text = @"关闭所有功能";
                    CheckClipbrdFuntion.Enabled = false;
                    CheckCaxaFuntion.Enabled = false;
                    CheckPlmFuntion.Enabled = false;
                    CheckFileDecrypt.Enabled = false;
                    Properties.Settings.Default.RunMode = true;
                    if (CheckClipbrdFuntion.Checked && Buttom_StartCaxaClipbrd.Text.StartsWith("启动"))
                    {
                        Buttom_StartCaxaClipbrd.Text = Buttom_StartCaxaClipbrd.Text.Replace("启动", "关闭");
                    }

                    if (CheckCaxaFuntion.Checked && Buttom_StartCaxaAutoSave.Text.StartsWith("启动"))
                    {
                        Buttom_StartCaxaAutoSave.Text = Buttom_StartCaxaAutoSave.Text.Replace("启动", "关闭");
                    }
                    if (CheckPlmFuntion.Checked && Buttom_StartPlmMonitor.Text.StartsWith("启动"))
                    {
                        Buttom_StartPlmMonitor.Text = Buttom_StartPlmMonitor.Text.Replace("启动", "关闭");
                    }
                    if (CheckFileDecrypt.Checked && Buttom_StartFileDecrypt.Text.StartsWith("启动"))
                    {
                        Buttom_StartFileDecrypt.Text = Buttom_StartFileDecrypt.Text.Replace("启动", "关闭");
                    }
                }
                else
                {
                    StartAllFuntion.Text = @"启动下列勾选功能";
                    CheckClipbrdFuntion.Enabled = true;
                    CheckCaxaFuntion.Enabled = true;
                    CheckPlmFuntion.Enabled = true;
                    CheckFileDecrypt.Enabled = true;
                    Properties.Settings.Default.RunMode = false;
                    if (CheckClipbrdFuntion.Checked && Buttom_StartCaxaClipbrd.Text.StartsWith("关闭"))
                    {
                        Buttom_StartCaxaClipbrd.Text = Buttom_StartCaxaClipbrd.Text.Replace("关闭", "启动");
                    } 

                    if (CheckCaxaFuntion.Checked && Buttom_StartCaxaAutoSave.Text.StartsWith("关闭"))
                    {
                        Buttom_StartCaxaAutoSave.Text = Buttom_StartCaxaAutoSave.Text.Replace("关闭", "启动");
                    }
                    if (CheckPlmFuntion.Checked && Buttom_StartPlmMonitor.Text.StartsWith("关闭"))
                    {
                        Buttom_StartPlmMonitor.Text = Buttom_StartPlmMonitor.Text.Replace("关闭", "启动");
                    }
                    if (CheckFileDecrypt.Checked && Buttom_StartFileDecrypt.Text.StartsWith("关闭"))
                    {
                        Buttom_StartFileDecrypt.Text = Buttom_StartFileDecrypt.Text.Replace("关闭", "启动");
                    }
                    Notify.Icon = ICO.ICO.System_preferences_tool_tools_128px_581754_easyicon_net;
                }
            }
            finally { Properties.Settings.Default.Save(); }
        }

        private void StartAllFuntion_MouseClick(object sender, MouseEventArgs e)
        {
            NotifyStartRun.PerformClick();
        }

        private void RunMode_Click(object sender, System.EventArgs e)
        {
            // TabAnother.Select();
            var Status = AutoRunMode.Checked;

            var StartChange = new Task(() =>
            {
                if (Status)
                {
                    if (!AutoRunServer.IsServiceExisted())
                    {
                        AutoRunServer.InstallService(Application.ExecutablePath);
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
                        Status = !AutoRunServer.ChangeServiceStartType(3, "Start");
                    }
                }
            });
            StartChange.ContinueWith(obj =>
            {
                BeginInvoke(new MethodInvoker(() =>
                {
                    AutoRunMode.Checked = Status;
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
            if (Directory.Exists(Properties.Settings.Default.AutoSavePath))
            {
                Properties.Settings.Default.CheckCaxaFuntion = CheckCaxaFuntion.Checked;
                Properties.Settings.Default.Save();
            }
            else
            {
                if (!CheckCaxaFuntion.Checked) return;
                new MessageBoxForm("未找到自动保存目录，请设置", MessageBoxButtons.OK, 5).ShowDialog();
                CheckCaxaFuntion.Checked = false;
                MainTab.SelectedIndex = 1;
            }
        }

        private void CheckFileDecrypt_MouseClick(object sender, MouseEventArgs e)
        {
            Properties.Settings.Default.CheckFileDecrypt = CheckFileDecrypt.Checked;
            Properties.Settings.Default.Save();
        }

        #endregion 功能勾选段

        #region 主窗口状态条

        private void MainTabClipbrdStation_MouseClick(object sender, MouseEventArgs e)
        {
            TabCaxa.Select();
            Thread Nt = new Thread(() =>
            {
                using (FolderBrowserDialog SeleSavePath = new FolderBrowserDialog())
                {
                    SeleSavePath.SelectedPath = Properties.Settings.Default.AutoSavePath;
                    SeleSavePath.ShowDialog();
                    materialSingleLineTextField1.Invoke(new Action(() =>
                    {
                        {
                            materialSingleLineTextField1.Text = SeleSavePath.SelectedPath;
                        }
                    }));

                }
            });
            Nt.TrySetApartmentState(ApartmentState.STA);
            Nt.Start();

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

        #endregion 主窗口状态条

        #endregion 主界面代码段

        #region Caxa相关代码段

        #region Clipbrd监控主函数
        public partial class ClipbrdMonitor : Form
        {
            private bool Onice = true;

            protected override void WndProc(ref Message m)
            {
                if (m.Msg == 0x031D && Onice)
                {
                    var Get_Text = new StringBuilder(256);
                    GetWindowTextW(GetForegroundWindow(IntPtr.Zero), Get_Text, 256);
                    if (Get_Text.ToString().StartsWith("CAXA"))
                    {
                        var Temp = GetText(13);
                        if (!string.IsNullOrEmpty(Temp))
                        {
                            SetText(Temp);
                            Onice = false;
                        }
                    }
                }
                else if (!Onice)
                {
                    Onice = true;
                }
                else
                {
                    base.WndProc(ref m);
                }
            }

            public ClipbrdMonitor()
            {
                AddClipboardFormatListener(this.Handle);
                this.FormClosing += delegate { RemoveClipboardFormatListener(this.Handle); };
            }

            private void SetText(string text)
            {
                if (!OpenClipboard(IntPtr.Zero))
                {
                    SetText(text);
                    Thread.Sleep(50);
                    return;
                }

                EmptyClipboard();
                SetClipboardData(13, Marshal.StringToCoTaskMemAuto(text));
                CloseClipboard();
            }

            private string GetText(int format)
            {
                var value = string.Empty;
                OpenClipboard(IntPtr.Zero);
                if (IsClipboardFormatAvailable(format))
                {
                    var ptr = GetClipboardData(format);
                    if (ptr != IntPtr.Zero) value = Marshal.PtrToStringUni(ptr);
                }

                CloseClipboard();
                return value;
            }
        }

        #endregion Clipbrd监控主函数

        private ClipbrdMonitor CaxaClipbrd;

        private void Buttom_TextChanged(object sender, EventArgs e)
        {
            if (sender is MaterialFlatButton)
            {
                var Buttom = sender as MaterialFlatButton;
                if (!Buttom.Text.StartsWith("启动"))
                {
                    Buttom.Icon = Image.FromStream(Assembly.GetExecutingAssembly()
                        .GetManifestResourceStream($"ETCTool.ICO.Start.ico"));
                    switch (Buttom.Name)
                    {
                        case "Buttom_StartCaxaClipbrd":
                            {
                                CaxaClipbrd = new ClipbrdMonitor();
                                Task.Factory.StartNew(() =>
                                {
                                    while (true)
                                    {
                                        Thread.Sleep(500);
                                        if (CaxaClipbrd == null) break;
                                        var GetText = new StringBuilder(256);
                                        GetWindowTextW(GetForegroundWindow(IntPtr.Zero),
                                            GetText, 256);
                                        if (GetText.ToString().StartsWith("CAXA"))
                                        {
                                            Invoke(new Action(() =>
                                            {
                                                Notify.Icon = ICO.ICO.clipboard_80px_1121225_easyicon_net;
                                            }));
                                        }
                                        else
                                        {
                                            Invoke(new Action(() =>
                                            {
                                                Notify.Icon = ICO.ICO.Clipboard_Plan_128px_1185105_easyicon_net;
                                            }));
                                        }
                                    }
                                }, TaskCreationOptions.LongRunning);
                            }
                            break;
                        case "Buttom_StartCaxaAutoSave":
                            StartCaxaAutoSaveFun(true);
                            break;
                        case "Buttom_StartPlmMonitor":

                            break;
                    }
                }
                else
                {
                    Buttom.Icon = Image.FromStream(Assembly.GetExecutingAssembly()
                        .GetManifestResourceStream($"ETCTool.ICO.Stop.ico"));
                    switch (Buttom.Name)
                    {
                        case "Buttom_StartCaxaClipbrd":
                            {
                                if (CaxaClipbrd != null)
                                {
                                    CaxaClipbrd.Close();
                                    CaxaClipbrd.Dispose();
                                    CaxaClipbrd = null;
                                    GC.Collect();
                                }
                            }
                            break;
                        case "Buttom_StartCaxaAutoSave":
                            StartCaxaAutoSaveFun(false);
                            break;
                    }
                }
            }
            else if (sender is ToolStripMenuItem buttom)
            {
                if (!buttom.Text.StartsWith("启动"))
                {
                    buttom.Image = Image.FromStream(Assembly.GetExecutingAssembly()
                        .GetManifestResourceStream($"ETCTool.ICO.Start.ico"));
                }
                else
                {
                    buttom.Image = Image.FromStream(Assembly.GetExecutingAssembly()
                        .GetManifestResourceStream($"ETCTool.ICO.Stop.ico"));
                }
            }
        }

        private void StartCaxaAutoSaveFun(bool Run)
        {
            if (Run)
            {
                if (Directory.Exists(Properties.Settings.Default.AutoSavePath))
                {

                }
                else
                {
                    new MessageBoxForm("未找到自动保存目录，请设置",MessageBoxButtons.OK,5).ShowDialog();
                    Properties.Settings.Default.AutoSavePath = "";
                    Properties.Settings.Default.Save();
                    StartCaxaAutoSaveFun(false);
                }
            }
            else
            {

            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem((state) =>
            {
                dynamic Button = sender as Control;
                if (Button == null)
                {
                    Button = sender as ToolStripMenuItem;
                }

                Invoke(new Action(() =>
                {
                    Button.Text = Button.Text.StartsWith("启动")
                        ? Button.Text.Replace("启动", "关闭")
                        : Button.Text.Replace("关闭", "启动");
                }));
            });
        }

        #endregion Caxa相关代码段

        #region 任务栏图标

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

        private void ExitClose_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
            Application.ExitThread();
        }

        private void NotifyStartRun_MouseDown(object sender, MouseEventArgs e)
        {
            StartAllFuntion.PerformClick();
        }

        #endregion 任务栏图标

        #region 鼠标控制窗体

        private bool isMouseDown = false; //表示鼠标当前是否处于按下状态，初始值为否

        private void MouseMoveSize_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
        }

        private void MouseMoveSize_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            switch (MainTab.SelectedIndex)
            {
                case 0:
                    this.Width = 480;
                    this.Height = 280;
                    break;

                case 1:
                    Properties.Settings.Default.FormSize[0] = this.Width.ToString();
                    Properties.Settings.Default.FormSize[1] = this.Height.ToString();
                    break;

                case 2:
                    Properties.Settings.Default.FormSize[2] = this.Width.ToString();
                    Properties.Settings.Default.FormSize[3] = this.Height.ToString();
                    break;

                case 3:
                    Properties.Settings.Default.FormSize[4] = this.Width.ToString();
                    Properties.Settings.Default.FormSize[5] = this.Height.ToString();
                    break;
            }

            Properties.Settings.Default.Save();
        }

        private void MouseMoveSize_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isMouseDown)
                return;
            this.Cursor = Cursors.SizeNWSE;
            this.Width = MousePosition.X - this.Left;
            this.Height = MousePosition.Y - this.Top;
        }

        private void MainTab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            switch (e.TabPageIndex)
            {
                case 0:
                    this.Width = 480;
                    this.Height = 280;
                    break;

                case 1:
                    this.Width = int.Parse(Properties.Settings.Default.FormSize[0]);
                    this.Height = int.Parse(Properties.Settings.Default.FormSize[1]);
                    break;

                case 2:
                    this.Width = int.Parse(Properties.Settings.Default.FormSize[2]);
                    this.Height = int.Parse(Properties.Settings.Default.FormSize[3]);
                    break;

                case 3:
                    this.Width = int.Parse(Properties.Settings.Default.FormSize[4]);
                    this.Height = int.Parse(Properties.Settings.Default.FormSize[5]);
                    break;
            }
        }

        #endregion 鼠标控制窗体
    }
}