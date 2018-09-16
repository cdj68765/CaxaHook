using System;
using System.Linq;
using System.Collections.Specialized;
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
using EasyHook;
using System.Runtime.Remoting;
using System.Collections.Generic;
using System.Diagnostics;
using static ETCTool.Variables;
using System.Timers;

namespace ETCTool
{
    public partial class MainForm : MaterialForm
    {
        #region 日志管理

        public readonly BindingList<string[]> CliLog;
        public readonly BindingList<string[]> AutoSaveLog;

        #endregion 日志管理

        public MainForm()
        {
            InitializeComponent();
            setting = new Setting().Init();
            SetStyle(
                ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.ResizeRedraw
                | ControlStyles.Selectable
                | ControlStyles.AllPaintingInWmPaint
                | ControlStyles.UserPaint
                | ControlStyles.SupportsTransparentBackColor, true);
            /*  Task.Factory.StartNew(() =>
              {
                  do
                  {
                      Thread.Sleep(1000);
                      GetCursorPos(out var lpPoint);
                      try
                      {
                          Invoke(new Action(() => { MainTabPlmStation.Text = lpPoint.ToString(); }));
                      }
                      catch (Exception)
                      {
                      }
                  } while (true);
              });*/
            TOPMOST.CheckedChanged += delegate { this.TopMost = TOPMOST.Checked; };

            #region 状态初始化

            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(1000);
                BeginInvoke(new Action(() =>
                {
                    CheckClipbrdFuntion.Checked = setting.CheckClipbrdFuntion;
                    CheckPlmFuntion.Checked = setting.CheckPlmFuntion;
                    CheckCaxaFuntion.Checked = setting.CheckCaxaFuntion;
                    CheckFileDecrypt.Checked = setting.CheckFileDecrypt;
                    if (setting.FormSize == null)
                    {
                        setting.FormSize = new StringCollection();
                        setting.FormSize.AddRange(new[] {"480", "280", "480", "280", "480", "280"});
                        setting.Save();
                    }

                    if (Directory.Exists(setting.AutoSavePath))
                    {
                        Variables.MainForm.AutoSaveLog.Add(new[]
                        {
                            $"{DateTime.Now:hh:mm:ss}->当前保存文件数量:",
                            $"{new DirectoryInfo(setting.AutoSavePath).EnumerateFileSystemInfos("*.exb").Count()}"
                        });
                    }

                    SetAutoSaveTimeSpan.Text = setting.AutoSaveSpan;
                }));
            });

            if (!string.IsNullOrEmpty(setting.AutoSavePath))
            {
                AutoSavePathLine.Text = setting.AutoSavePath;
            }

            #endregion 状态初始化

            #region 初始化日志库

            CliLog = new BindingList<string[]>();
            CliLog.ListChanged += (s, d) =>
            {
                if (d.ListChangedType == ListChangedType.ItemDeleted) return;
                var Item = CliLog[d.NewIndex];
                var FindCount = CliLog.Count(x => x[1] == Item[1] && x[1] != "");
                if (FindCount > 1)
                {
                    for (int i = 0; i < FindCount - 1; i++)
                    {
                        var Find = CliLog.FirstOrDefault(x => x[1] == Item[1] && x[1] != "");
                        if (Find != null)
                        {
                            CliLog.Remove(Find);
                            MainTabClipbrdStation.BeginInvoke(new Action(() =>
                            {
                                CaxaList.Items.Remove(Find[0] + Find[1]);
                            }));
                        }
                    }
                }

                MainTabClipbrdStation.BeginInvoke(new Action(() =>
                {
                    MainTabClipbrdStation.Text = Item[0] + Item[1];
                    if (CliRadio.Checked)
                    {
                        if (CaxaList.Items.Count == CliLog.Count)
                        {
                            CaxaList.Items.Add(MainTabClipbrdStation.Text);
                        }
                        else
                        {
                            CaxaList.Items.Clear();
                            foreach (var VARIABLE in CliLog) CaxaList.Items.Add(VARIABLE[0] + VARIABLE[1]);
                        }

                        CaxaList.SelectedIndex = CaxaList.Items.Count - 1;
                    }
                }));
            };
            CliRadio.CheckedChanged += delegate
            {
                if (CliRadio.Checked)
                {
                    CaxaList.Items.Clear();
                    foreach (var VARIABLE in CliLog) CaxaList.Items.Add(VARIABLE[0] + VARIABLE[1]);
                    CaxaList.SelectedIndex = CaxaList.Items.Count - 1;
                    CaxaList.ContextMenuStrip = CliCopyMenuStrip;
                }
                else
                {
                    CaxaList.ContextMenuStrip = null;
                    CaxaList.Items.Clear();
                    foreach (var VARIABLE in AutoSaveLog) CaxaList.Items.Add(VARIABLE[0] + VARIABLE[1]);
                    CaxaList.SelectedIndex = CaxaList.Items.Count - 1;
                }
            };
            CLICurrentText.MouseDown += delegate
            {
                ClipbrdMonitor.Onice = false;
                ClipbrdMonitor.SetText(CliLog[CaxaList.SelectedIndex][1]);
            };
            AutoSaveLog = new BindingList<string[]>();
            AutoSaveLog.ListChanged += (s, d) =>
            {
                if (d.ListChangedType == ListChangedType.ItemDeleted) return;
                var Item = AutoSaveLog[d.NewIndex];
                BeginInvoke(new Action(() =>
                {
                    MainTabAutoSaveStation.Text = Item[0] + Item[1];
                    if (!CliRadio.Checked)
                    {
                        if (CaxaList.Items.Count == AutoSaveLog.Count)
                        {
                            CaxaList.Items.Add(MainTabAutoSaveStation.Text);
                        }
                        else
                        {
                            CaxaList.Items.Clear();
                            foreach (var VARIABLE in AutoSaveLog) CaxaList.Items.Add(VARIABLE[0] + VARIABLE[1]);
                        }

                        CaxaList.SelectedIndex = CaxaList.Items.Count - 1;
                    }
                }));
            };

            #endregion 初始化日志库

            AutoRunMode.Checked = CheckAutoRun();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900,
                Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            new Mutex(true, "ETCTool", out var Close);
            if (!Close)
                Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(1500);
                    this.Close();
                    Application.Exit();
                    Application.ExitThread();
                });
            if (setting.RunMode)
            {
                WindowState = FormWindowState.Minimized;
                ShowInTaskbar = false;
                Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(1500);
                    Invoke(new Action(() =>
                    {
                        StartAllFuntion.PerformClick();
                        NotifyStartRun.PerformClick();
                    }));
                });
            }

            Deactivate += delegate
            {
                if (WindowState == FormWindowState.Minimized)
                    if (setting.RunMode)
                        ShowInTaskbar = false;
            };
        }

        private void 管道通讯()
        {
            var memoryFile = MemoryMappedFile.CreateFromFile(@"C:\Users\Administrator\Desktop\FA7-10B-A10-N003.pdf",
                FileMode.Open, "MyFile");
            var stream = memoryFile.CreateViewStream();
            using (var Cfile = new FileStream(@"C:\Users\Administrator\Desktop\FA7-10B-A10-N003-2.pdf",
                FileMode.OpenOrCreate))
            {
                var file = MemoryMappedFile.OpenExisting("MyFile");
                var accessor = file.CreateViewStream();
                var b = -1;
                do
                {
                    b = accessor.ReadByte();
                    if (b == -1) break;
                    Cfile.WriteByte(Convert.ToByte(b));
                } while (b != -1);
            }

            using (var pipeServer = new NamedPipeServerStream("mynamedpipe", PipeDirection.InOut)) //创建管道
            {
                try
                {
                    pipeServer.WaitForConnection(); //等待客户端连接
                    pipeServer.ReadMode = PipeTransmissionMode.Byte;
                    Console.WriteLine("sucess connected?" + pipeServer.IsConnected);
                    var sr = new StreamReader(pipeServer); //获取管道输入流
                    var sw = new StreamWriter(pipeServer); //获取管道输出流
                    string result;
                    while (true) //循环接收客户端消息
                    {
                        result = sr.ReadLine();
                        if (result == null || result == "bye")
                            break;
                        Console.WriteLine(result);
                        sw.WriteLine("I'm Sever!"); //返回客户端信息
                        sw.Flush(); //清除缓存流，注意必须有这一步，否则会造成管道堵塞
                    }

                    Console.ReadKey();
                }
                catch (IOException e)
                {
                    throw e;
                }
            }

            using (var pipeStream = new NamedPipeClientStream("localhost", "mynamedpipe")
            ) //与服务端管道名一致，如果连接C++服务端，名称一致即可，“localhost”可以更换为IP地址，也可以进行网络通信
            {
                pipeStream.Connect(); //连接服务端
                if (!pipeStream.IsConnected)
                {
                    Console.WriteLine("Failed to connect ....");
                    return;
                }

                var sw = new StreamWriter(pipeStream);
                var sr = new StreamReader(pipeStream);
                while (true) //循环输入
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

        private bool CheckAutoRun()
        {
            if (AutoRunServer.IsServiceExisted()) return AutoRunServer.CheckStartMode();
            return false;
        }

        #region 主界面代码段

        private void StartAllFuntion_Click(object sender, EventArgs e)
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
                    setting.RunMode = true;
                    if (CheckClipbrdFuntion.Checked && Buttom_StartCaxaClipbrd.Text.StartsWith("启动"))
                        Buttom_StartCaxaClipbrd.Text = Buttom_StartCaxaClipbrd.Text.Replace("启动", "关闭");
                    if (CheckCaxaFuntion.Checked && Buttom_StartCaxaAutoSave.Text.StartsWith("启动"))
                        Buttom_StartCaxaAutoSave.Text = Buttom_StartCaxaAutoSave.Text.Replace("启动", "关闭");
                    if (CheckPlmFuntion.Checked && Buttom_StartPlmMonitor.Text.StartsWith("启动"))
                        Buttom_StartPlmMonitor.Text = Buttom_StartPlmMonitor.Text.Replace("启动", "关闭");
                    if (CheckFileDecrypt.Checked && Buttom_StartFileDecrypt.Text.StartsWith("启动"))
                        Buttom_StartFileDecrypt.Text = Buttom_StartFileDecrypt.Text.Replace("启动", "关闭");
                }
                else
                {
                    StartAllFuntion.Text = @"启动下列勾选功能";
                    CheckClipbrdFuntion.Enabled = true;
                    CheckCaxaFuntion.Enabled = true;
                    CheckPlmFuntion.Enabled = true;
                    CheckFileDecrypt.Enabled = true;
                    setting.RunMode = false;
                    if (CheckClipbrdFuntion.Checked && Buttom_StartCaxaClipbrd.Text.StartsWith("关闭"))
                        Buttom_StartCaxaClipbrd.Text = Buttom_StartCaxaClipbrd.Text.Replace("关闭", "启动");
                    if (CheckCaxaFuntion.Checked && Buttom_StartCaxaAutoSave.Text.StartsWith("关闭"))
                        Buttom_StartCaxaAutoSave.Text = Buttom_StartCaxaAutoSave.Text.Replace("关闭", "启动");
                    if (CheckPlmFuntion.Checked && Buttom_StartPlmMonitor.Text.StartsWith("关闭"))
                        Buttom_StartPlmMonitor.Text = Buttom_StartPlmMonitor.Text.Replace("关闭", "启动");
                    if (CheckFileDecrypt.Checked && Buttom_StartFileDecrypt.Text.StartsWith("关闭"))
                        Buttom_StartFileDecrypt.Text = Buttom_StartFileDecrypt.Text.Replace("关闭", "启动");
                    Notify.Icon = ICO.ICO.System_preferences_tool_tools_128px_581754_easyicon_net;
                }
            }
            catch (Exception)
            {
            }
        }

        private void StartAllFuntion_MouseClick(object sender, MouseEventArgs e)
        {
            NotifyStartRun.PerformClick();
        }

        private void RunMode_Click(object sender, EventArgs e)
        {
            // TabAnother.Select();
            var Status = AutoRunMode.Checked;

            var StartChange = new Task(() =>
            {
                if (Status)
                {
                    if (!AutoRunServer.IsServiceExisted())
                        AutoRunServer.InstallService(Application.ExecutablePath);
                    else
                        Status = AutoRunServer.ChangeServiceStartType(2, "Start");
                }
                else
                {
                    if (AutoRunServer.IsServiceExisted()) Status = !AutoRunServer.ChangeServiceStartType(3, "Start");
                }
            });
            StartChange.ContinueWith(
                obj => { BeginInvoke(new MethodInvoker(() => { AutoRunMode.Checked = Status; })); });
            StartChange.Start();
        }

        private void DeleteAutoRunService_Click(object sender, EventArgs e)
        {
            if (AutoRunServer.IsServiceExisted()) AutoRunServer.UnInstallService();

            AutoRunMode.Checked = false;
            AutoRunMode.Enabled = false;
        }

        #region 功能勾选段

        private void CheckClipbrdFuntion_MouseClick(object sender, MouseEventArgs e)
        {
            setting.CheckClipbrdFuntion = CheckClipbrdFuntion.Checked;
        }

        private void CheckPlmFuntion_MouseClick(object sender, MouseEventArgs e)
        {
            setting.CheckPlmFuntion = CheckPlmFuntion.Checked;
        }

        private void CheckCaxaFuntion_MouseClick(object sender, MouseEventArgs e)
        {
            if (Directory.Exists(setting.AutoSavePath))
            {
                setting.CheckCaxaFuntion = CheckCaxaFuntion.Checked;
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
            setting.CheckFileDecrypt = CheckFileDecrypt.Checked;
        }

        #endregion 功能勾选段

        #region 主窗口状态条

        private void MainTabClipbrdStation_MouseClick(object sender, MouseEventArgs e)
        {
            TabCaxa.Select();
        }

        private void AutoSavePathLine_Click(object sender, EventArgs e)
        {
            TabCaxa.Select();

            try
            {
                var SeleSavePath = new WPFFolderBrowser.WPFFolderBrowserDialog();
                // SeleSavePath.SelectedPath = setting.AutoSavePath;
                SeleSavePath.ShowDialog();
                SeleSavePath.InitialDirectory = setting.AutoSavePath;
                SeleSavePath.Title = "选择Caxa自动保存目录 ";
                SeleSavePath.AddToMruList = true;
                SeleSavePath.DereferenceLinks = true;
                AutoSavePathLine.Text = SeleSavePath.FileName;
                //  setting.AutoSavePath = SeleSavePath.SelectedPath;
                setting.AutoSavePath = SeleSavePath.FileName;
            }
            finally
            {
            }

            /*  var Nt = new Thread(() =>
              {
              });
              Nt.TrySetApartmentState(ApartmentState.STA);
              Nt.Start();*/
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

        private void Buttom_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender is MaterialFlatButton)
                {
                    var Button = sender as MaterialFlatButton;
                    if (!Button.Text.StartsWith("启动"))
                    {
                        Button.Icon = Image.FromStream(Assembly.GetExecutingAssembly()
                            .GetManifestResourceStream($"ETCTool.ICO.Start.ico"));
                        switch (Button.Name)
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
                                        GetWindowTextW(GetForegroundWindow(),
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
                                            if (Variables.MainForm == null) return;
                                            BeginInvoke(new Action(() =>
                                            {
                                                Notify.Icon = ICO.ICO.Clipboard_Plan_128px_1185105_easyicon_net;
                                            }));
                                        }
                                    }
                                }, TaskCreationOptions.LongRunning);
                            }
                                break;

                            case "Buttom_StartCaxaAutoSave":
                                StartCaxaAutoSaveFun(true, Button);
                                break;

                            case "Buttom_StartPlmMonitor":

                                break;
                        }
                    }
                    else
                    {
                        Button.Icon = Image.FromStream(Assembly.GetExecutingAssembly()
                            .GetManifestResourceStream($"ETCTool.ICO.Stop.ico"));
                        switch (Button.Name)
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
                        buttom.Image = Image.FromStream(Assembly.GetExecutingAssembly()
                            .GetManifestResourceStream($"ETCTool.ICO.Start.ico"));
                    else
                        buttom.Image = Image.FromStream(Assembly.GetExecutingAssembly()
                            .GetManifestResourceStream($"ETCTool.ICO.Stop.ico"));
                }
            }
            catch (Exception exception)
            {
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(state =>
            {
                dynamic Button = sender as Control;
                if (Button == null) Button = sender as ToolStripMenuItem;
                Invoke(new Action(() =>
                {
                    Button.Text = Button.Text.StartsWith("启动")
                        ? Button.Text.Replace("启动", "关闭")
                        : Button.Text.Replace("关闭", "启动");
                }));
            });
        }

        #region Clipbrd监控主函数

        private ClipbrdMonitor CaxaClipbrd;

        private class ClipbrdMonitor : Form
        {
            public static bool Onice = true;

            public ClipbrdMonitor()
            {
                AddClipboardFormatListener(Handle);
                Variables.MainForm.CliLog.Add(new[] {$"{DateTime.Now:hh:mm:ss}->启动剪切板监控", ""});
                FormClosing += delegate
                {
                    Variables.MainForm.CliLog.Add(new[] {$"{DateTime.Now:hh:mm:ss}->关闭剪切板监控", ""});
                    RemoveClipboardFormatListener(Handle);
                };
            }

            protected override void WndProc(ref Message m)
            {
                if (m.Msg == 0x031D && Onice)
                {
                    try
                    {
                        OpenClipboard(IntPtr.Zero);
                        var Get_Text = new StringBuilder(256);
                        GetWindowTextW(GetForegroundWindow(), Get_Text, 256);
                        if (Get_Text.ToString().StartsWith("CAXA"))
                        {
                            var Temp = GetText(13);
                            if (!string.IsNullOrEmpty(Temp))
                            {
                                ThreadPool.QueueUserWorkItem(obj =>
                                {
                                    Variables.MainForm.CliLog.Add(new[] {$"{DateTime.Now:hh:mm:ss}->获得字符:", Temp});
                                });
                                SetText(Temp);
                                Onice = false;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        ThreadPool.QueueUserWorkItem(obj =>
                        {
                            Variables.MainForm.CliLog.Add(new[]
                                {$"{DateTime.Now:hh:mm:ss}->发生错误:{e.ToString()}", ""});
                        });
                    }
                    finally
                    {
                        CloseClipboard();
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

            public static void SetText(string text)
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

        #region Caxa自动保存代码段

        // private System.Timers.Timer AutoSaveTimeSpan = new System.Timers.Timer(1000);
        public readonly Dictionary<int, string> CaxaPid = new Dictionary<int, string>();

        private void SetAutoSaveTimeSpan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' && e.KeyChar != '.' && e.KeyChar != '\u0016' && e.KeyChar != '\u0003')
            {
                if (e.KeyChar < '0' || e.KeyChar > '9') //这是允许输入0-9数字
                {
                    e.Handled = true;
                }
                else if (SetAutoSaveTimeSpan.Text.Length >= 3 && e.KeyChar != '\b')
                {
                    e.Handled = true;
                }
            }
            else if (e.KeyChar != '\b' && !float.TryParse($"{SetAutoSaveTimeSpan.Text}{e.KeyChar}", out float res))
            {
                e.Handled = true;
            }
        }

         System.Timers.Timer AutoSaveTimeSpan = new System.Timers.Timer(1000);

        string TimeSplit(int Time)
        {
            var TempDate = new DateTime().AddSeconds(Double.Parse(Time.ToString()));
            if (Time < 60) return $"{TempDate:s秒}";
            else if (Time < 3600) return $"{TempDate:m分s秒}";
            else return $"{TempDate:h:m:s}";
        }
        private void StartCaxaAutoSaveFun(bool Run, MaterialFlatButton button = null)
        {
            var SpanTime = GetAndSetTime();
            if (string.IsNullOrEmpty(SetAutoSaveTimeSpan.Text))
            {
                SetAutoSaveTimeSpan.Text = @"1";
            }

            var TextOfNow = SetAutoSaveTimeSpan.Text;
           
            if (Run)
            {
                if (Directory.Exists(setting.AutoSavePath))
                {
                    AutoSaveRun = true;
                    Variables.MainForm.AutoSaveLog.Add(new[]
                        {$"{DateTime.Now:hh:mm:ss}->自动保存功能启动，设定时间{TimeSplit(SpanTime)}", $""});
                    AutoSaveTimeSpan = new System.Timers.Timer(1000)
                    {
                        AutoReset = true,
                        Enabled = true
                    };
                    setting.AutoSaveSpan = SetAutoSaveTimeSpan.Text;
                    AutoSaveTimeSpan.Elapsed += SpanRun;
                }
                else
                {
                    new MessageBoxForm("未找到自动保存目录，请设置", MessageBoxButtons.OK, 5).ShowDialog();
                    setting.AutoSavePath = "";
                    button.PerformClick();
                }
            }
            else
            {
                AutoSaveTimeSpan.Dispose();
                AutoSaveSpan.BeginInvoke(new Action(() =>
                {
                    AutoSaveSpan.Value = 0;
                }));
                AutoSaveRun = false;
                Variables.MainForm.AutoSaveLog.Add(new[] {$"{DateTime.Now:hh:mm:ss}->自动保存功能关闭", $""});
                // AutoSaveTimeSpan.Dispose();
            }

            int GetAndSetTime()
            {
                if (float.TryParse(SetAutoSaveTimeSpan.Text,
                    out float ret))
                {
                    var _SpanTime = Convert.ToInt32(ret * 60);
                    if (_SpanTime == 0)
                    {
                        _SpanTime = 60;
                        Variables.MainForm.AutoSaveLog.Add(new[]
                            {$"{DateTime.Now:hh:mm:ss}->设定错误，时间恢复为1分钟", $""});
                    }
                    return AutoSaveSpan.Value = AutoSaveSpan.Maximum = _SpanTime;
                }
                else
                {
                    Variables.MainForm.AutoSaveLog.Add(new[]
                        {$"{DateTime.Now:hh:mm:ss}->设定错误，时间恢复为1分钟", $""});
                    return AutoSaveSpan.Value = AutoSaveSpan.Maximum = 60;
                }
            }

            void SpanRun(object sender, ElapsedEventArgs e)
            {
                Interlocked.Decrement(ref SpanTime);
                if (SpanTime == 0)
                {
                    AutoSaveSpan.BeginInvoke(new Action(() =>
                    {
                        if (TextOfNow == SetAutoSaveTimeSpan.Text)
                        {
                            SpanTime = AutoSaveSpan.Value = AutoSaveSpan.Maximum;
                        }
                        else
                        {
                            try
                            {
                                SpanTime = GetAndSetTime();
                                Variables.MainForm.AutoSaveLog.Add(new[]
                                    {$"{DateTime.Now:hh:mm:ss}->设定时间改变为{TimeSplit(SpanTime)}", $""});
                            }
                            catch (Exception)
                            {
                            }
                        }

                    }));
                }
                else
                {
                    AutoSaveSpan.BeginInvoke(new Action(() =>
                    {
                        try
                        {
                             AutoSaveSpan.Value=SpanTime;
                        }
                        catch (Exception )
                        {
                        }

                    }));

                }
                var Get_Text = new StringBuilder(256);
                var ForegroundWindow = GetForegroundWindow();
                GetWindowTextW(ForegroundWindow, Get_Text, 256);
                if (Get_Text.ToString().StartsWith("CAXA"))
                {
                    GetWindowThreadProcessId(ForegroundWindow, out int Pid);
                    if (!CaxaPid.ContainsKey(Pid))
                    {
                        try
                        {
                            string ChannelName = null;
                            RemoteHooking.IpcCreateServer<CaxaHookInterface>(ref ChannelName,
                                WellKnownObjectMode.SingleCall);
                            var path = Environment.GetFolderPath(Environment.SpecialFolder
                                .CommonApplicationData);
                            Config.DependencyPath = $"{path}\\EtcTool\\";
                            Config.HelperLibraryLocation = $"{path}\\EtcTool\\";
                            RemoteHooking.Inject(
                                Pid,
                                InjectionOptions.Default,
                                $"{path}\\EtcTool\\CaxaInject.dll",
                                $"{path}\\EtcTool\\CaxaInject.dll",
                                ChannelName);
                            CaxaPid.Add(Pid, ChannelName);
                            Variables.MainForm.AutoSaveLog.Add(new[]
                                {$"{DateTime.Now:hh:mm:ss}->捕获成功:", $"{Get_Text}"});
                        }
                        catch (Exception exception)
                        {
                            Variables.MainForm.AutoSaveLog.Add(new[]
                                {$"{DateTime.Now:hh:mm:ss}->错误信息:", $"{exception}"});
                        }
                    }
                    if (SpanTime == 0)
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
                                AddLog($"错误，未找到文档：{WindowsName}");
                                return;
                            }
                            else if (WindowsName.StartsWith("CAXA电子图板2013"))
                            {
                                var _FileName = Path.GetFileName(SPF[1].Split(']')[0]);
                                if (!_FileName.StartsWith("工程图文档") && _FileName.IndexOf("只读", StringComparison.Ordinal) == -1)
                                {
                                    SetHook = true;
                                    Thread.Sleep(1000);
                                    var exb = Path.GetExtension(_FileName);
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
                        Variables.MainForm.AutoSaveLog.Add(new[]
                            {$"{DateTime.Now:hh:mm:ss}->激活保存{Get_Text}", $""});
                        KeySaveBykeybd_event()
                    }
                }
            }
        }

        private void OpenTheLastAutoSaveButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (File.Exists(setting.TheLastSavePath))
            {
                Process.Start(setting.TheLastSavePath);
            }
            else
            {
                new MessageBoxForm("未找到最后一次保存的文件", MessageBoxButtons.OK, 5).ShowDialog();
            }
        }

        private void OpenAutoSavePath_MouseClick(object sender, MouseEventArgs e)
        {
            if (Directory.Exists(setting.AutoSavePath))
            {
                Process.Start(setting.AutoSavePath);
            }
            else
            {
                new MessageBoxForm("未找到自动保存目录", MessageBoxButtons.OK, 5).ShowDialog();
            }
        }

        private void DelAllFile_MouseClick(object sender, MouseEventArgs e)
        {
            if (Directory.Exists(setting.AutoSavePath))
            {
                foreach (var VARIABLE in new DirectoryInfo(setting.AutoSavePath).EnumerateFiles("*.exb"))
                {
                    try
                    {
                        File.Delete(VARIABLE.FullName);
                        Variables.MainForm.AutoSaveLog.Add(new[]
                            {$"{DateTime.Now:hh:mm:ss}->删除成功:", $"{VARIABLE.Name}"});
                    }
                    catch (Exception exception)
                    {
                        Variables.MainForm.AutoSaveLog.Add(new[]
                            {$"{DateTime.Now:hh:mm:ss}->删除失败:", $"{VARIABLE.Name}"});
                    }
                }
            }
            else
            {
                new MessageBoxForm("未找到自动保存目录", MessageBoxButtons.OK, 5).ShowDialog();
            }
        }
        
        #endregion Caxa自动保存代码段

        #endregion Caxa相关代码段

        #region 任务栏图标

        private void ShowForm_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
        }

        private void Notify_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (WindowState == FormWindowState.Normal)
                {
                    WindowState = FormWindowState.Minimized;
                    ShowInTaskbar = false;
                    return;
                }

                WindowState = FormWindowState.Normal;
                ShowInTaskbar = true;
            }
        }

        private void ExitClose_Click(object sender, EventArgs e)
        {
            Close();
            Application.Exit();
            Application.ExitThread();
        }

        private void NotifyStartRun_MouseDown(object sender, MouseEventArgs e)
        {
            StartAllFuntion.PerformClick();
        }

        #endregion 任务栏图标

        #region 鼠标控制窗体

        private bool isMouseDown; //表示鼠标当前是否处于按下状态，初始值为否

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
                    Width = 480;
                    Height = 280;
                    break;

                case 1:
                    setting.FormSize[0] = Width.ToString();
                    setting.FormSize[1] = Height.ToString();
                    break;

                case 2:
                    setting.FormSize[2] = Width.ToString();
                    setting.FormSize[3] = Height.ToString();
                    break;

                case 3:
                    setting.FormSize[4] = Width.ToString();
                    setting.FormSize[5] = Height.ToString();
                    break;
            }

            setting.Save();
        }

        private void MouseMoveSize_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isMouseDown)
                return;
            Cursor = Cursors.SizeNWSE;
            Width = MousePosition.X - Left;
            Height = MousePosition.Y - Top;
        }

        private void MainTab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            switch (e.TabPageIndex)
            {
                case 0:
                    Width = 480;
                    Height = 280;
                    break;

                case 1:
                    Width = int.Parse(setting.FormSize[0]);
                    Height = int.Parse(setting.FormSize[1]);
                    if (AutoSavePathLine.Text == string.Empty)
                    {
                        ThreadPool.QueueUserWorkItem(state =>
                        {
                            Thread.Sleep(500);
                            Invoke(new Action(() => { AutoSavePathLine.Focus(); }));
                            Thread.Sleep(500);
                            Invoke(new Action(() => { ChangeAutoSavePath.Focus(); }));
                            Thread.Sleep(500);
                            Invoke(new Action(() => { AutoSavePathLine.Focus(); }));
                            Thread.Sleep(500);
                            Invoke(new Action(() => { ChangeAutoSavePath.Focus(); }));
                            Thread.Sleep(500);
                        });
                    }

                    break;

                case 2:
                    Width = int.Parse(setting.FormSize[2]);
                    Height = int.Parse(setting.FormSize[3]);
                    break;

                case 3:
                    Width = int.Parse(setting.FormSize[4]);
                    Height = int.Parse(setting.FormSize[5]);
                    break;
            }
        }

        #endregion 鼠标控制窗体
    }
}