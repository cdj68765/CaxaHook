using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaxaHook
{
    internal class NativeApi
    {
        internal static int[] GetProcessID(string name)
        {
            var PIDList = new List<int>();

            foreach (var disk in new ManagementObjectSearcher(
                new SelectQuery("Select Name,ProcessId from Win32_Process Where (Name = 'CDRAFT_M.exe')")).Get())
            {
                PIDList.Add(int.Parse(disk["ProcessId"].ToString()));
                //Class1.Form1.AddLog(disk["ProcessId"].ToString());
                // PID = int.Parse(disk["ProcessId"].ToString());
                /* if (disk["Name"].ToString() == name)
                  {
                      PID = int.Parse(disk["ProcessId"].ToString());
                      //break;
                  }*/
            }
            return PIDList.ToArray();
        }

        public const byte vbKeyControl = 0x11; // CTRL 键
        public const byte vbKeyS = 83;

        /// <summary>
        /// 导入模拟键盘的方法
        /// </summary>
        /// <param name="bVk" >按键的虚拟键值</param>
        /// <param name= "bScan" >扫描码，一般不用设置，用0代替就行</param>
        /// <param name= "dwFlags" >选项标志：0：表示按下，2：表示松开</param>
        /// <param name= "dwExtraInfo">一般设置为0</param>
        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        public static void KeySaveBykeybd_event()
        {
            keybd_event(vbKeyControl, 0, 0, 0);
            keybd_event(vbKeyS, 0, 0, 0);
            keybd_event(vbKeyControl, 0, 2, 0);
            keybd_event(vbKeyS, 0, 2, 0);
        }

        [DllImport("user32.dll", EntryPoint = "SendMessage", SetLastError = true)]
        public static extern int PostMessage(IntPtr hWnd, int Msg, Keys wParam, int lParam);

        public static void KeySaveByPostMessage()
        {
            var hWnd = WindowsLoopFindHwnd(out string HWND);
            //PostMessage(hWnd, 256, Keys.ControlKey, 1);
            PostMessage(hWnd, 256, Keys.S, 1);
            // Thread.Sleep(100);
            //PostMessage(hWnd, 257, Keys.ControlKey, 1);
            PostMessage(hWnd, 257, Keys.S, 1);
        }

        public delegate bool CallBack(IntPtr hwnd, IntPtr lParam);

        [DllImport("user32")]
        public static extern bool EnumWindows(CallBack hwnd, int uCmd);

        [DllImport("user32.dll")]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll")]
        public static extern int GetWindowTextW(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpString,
            int nMaxCount);

        public static IntPtr WindowsLoopFindHwnd(out String WinHmd)
        {
            var lpString = new StringBuilder(1024);
            var winHmd = IntPtr.Zero;
            EnumWindows((a, b) =>
            {
                GetWindowText(a, lpString, lpString.Capacity);
                if (lpString.ToString().IndexOf("电子图板", StringComparison.Ordinal) != -1 && lpString.ToString().StartsWith("CAXA"))
                {
                  /*  NativeApi.GetWindowThreadProcessId(a, out uint pid);
                    Console.WriteLine($"pid:{pid}");*/
                    winHmd = a;
                    return false;
                }
                return true;
            }, 0);
            WinHmd = lpString.ToString();
            return winHmd;
        }
        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow(IntPtr hWnd);

        internal static bool CheckForegroundWindow()
        {
            var GetText = new StringBuilder(256);
            GetWindowTextW(GetForegroundWindow(IntPtr.Zero), GetText, 256);
            if (GetText.ToString().IndexOf("电子图板", StringComparison.Ordinal) != -1)
                return true;
            else
                return false;
            /*  if (GetText.ToString().IndexOf("电子图版") != -1 && GetText.ToString().StartsWith("CAXA") && GetText.ToString() != "Default IME")
                  return true;
              else
                  return false;*/
        }//查找窗体

        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, uint wParam, uint lParam);

        public static void OperaKeyBySend()
        {
            var hwnd = WindowsLoopFindHwnd(out string hWND);
            SendMessage(hwnd, 0x0104, 0x11, 1);//0x11 == VK_CONTROL == ALT键
            SendMessage(hwnd, 0x0104, 0x53, 1);//
            SendMessage(hwnd, 0x0105, 0x53, 1);//
            SendMessage(hwnd, 0x0105, 0x11, 1);//
        }
    }
}