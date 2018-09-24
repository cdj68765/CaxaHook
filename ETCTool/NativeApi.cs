using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace ETCTool
{
    public class NativeApi
    {
        #region 剪切板用API

        [DllImport("user32.dll")]
        internal static extern bool AddClipboardFormatListener(IntPtr hwnd);

        [DllImport("user32.dll")]
        internal static extern bool RemoveClipboardFormatListener(IntPtr hwnd);

        [DllImport("user32.dll")]
        public static extern int GetWindowTextW(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpString,
            int nMaxCount);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("User32")]
        internal static extern bool OpenClipboard(IntPtr hWndNewOwner);

        [DllImport("User32")]
        internal static extern bool CloseClipboard();

        [DllImport("User32")]
        internal static extern bool EmptyClipboard();

        [DllImport("User32", CharSet = CharSet.Unicode)]
        internal static extern IntPtr SetClipboardData(int uFormat, IntPtr hMem);

        [DllImport("User32")]
        internal static extern bool IsClipboardFormatAvailable(int format);

        [DllImport("User32")]
        internal static extern IntPtr GetClipboardData(int uFormat);

        #endregion 剪切板用API

        #region 获得鼠标指针

        [StructLayout(LayoutKind.Sequential)]
        public struct Point
        {
            public int X;
            public int Y;

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public override string ToString()
            {
                return $"X:{X},Y:{Y}";
            }
        }

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetCursorPos(out Point lpPoint);

        #endregion 获得鼠标指针

        #region 自动保存用API

        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

        public const byte vbKeyControl = 0x11; // CTRL 键
        public const byte vbKeyS = 83;

        /// <summary>
        ///     导入模拟键盘的方法
        /// </summary>
        /// <param name="bVk">按键的虚拟键值</param>
        /// <param name="bScan">扫描码，一般不用设置，用0代替就行</param>
        /// <param name="dwFlags">选项标志：0：表示按下，2：表示松开</param>
        /// <param name="dwExtraInfo">一般设置为0</param>
        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        public static void KeySaveBykeybd_event()
        {
            keybd_event(vbKeyControl, 0, 0, 0);
            keybd_event(vbKeyS, 0, 0, 0);
            keybd_event(vbKeyControl, 0, 2, 0);
            keybd_event(vbKeyS, 0, 2, 0);
        }

        #endregion 自动保存用API

        #region PLM接管用相关API

        [DllImport("User32.dll ")]
        public static extern IntPtr FindWindowEx(IntPtr parent, IntPtr childe, string strclass,
            string strname);

        [DllImport("user32.dll")]
        public static extern int SendMessageA(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindow(IntPtr hwnd, uint wMsg);

        #endregion

        #region 文件右键管理用API

        #region 各种结构体

        [Flags]
        internal enum CMF : uint
        {
            CMF_NORMAL = 0x00000000,
            CMF_DEFAULTONLY = 0x00000001,
            CMF_VERBSONLY = 0x00000002,
            CMF_EXPLORE = 0x00000004,
            CMF_NOVERBS = 0x00000008,
            CMF_CANRENAME = 0x00000010,
            CMF_NODEFAULT = 0x00000020,
            CMF_INCLUDESTATIC = 0x00000040,
            CMF_ITEMMENU = 0x00000080,
            CMF_EXTENDEDVERBS = 0x00000100,
            CMF_DISABLEDVERBS = 0x00000200,
            CMF_ASYNCVERBSTATE = 0x00000400,
            CMF_OPTIMIZEFORINVOKE = 0x00000800,
            CMF_SYNCCASCADEMENU = 0x00001000,
            CMF_DONOTPICKDEFAULT = 0x00002000,
            CMF_RESERVED = 0xFFFF0000
        }

        [Flags]
        internal enum CMIC : uint
        {
            CMIC_MASK_ICON = 0x00000010,
            CMIC_MASK_HOTKEY = 0x00000020,
            CMIC_MASK_NOASYNC = 0x00000100,
            CMIC_MASK_FLAG_NO_UI = 0x00000400,
            CMIC_MASK_UNICODE = 0x00004000,
            CMIC_MASK_NO_CONSOLE = 0x00008000,
            CMIC_MASK_ASYNCOK = 0x00100000,
            CMIC_MASK_NOZONECHECKS = 0x00800000,
            CMIC_MASK_FLAG_LOG_USAGE = 0x04000000,
            CMIC_MASK_SHIFT_DOWN = 0x10000000,
            CMIC_MASK_PTINVOKE = 0x20000000,
            CMIC_MASK_CONTROL_DOWN = 0x40000000
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal struct CMINVOKECOMMANDINFO
        {
            public uint cbSize;
            public CMIC fMask;
            public IntPtr hwnd;
            public IntPtr verb;
            [MarshalAs(UnmanagedType.LPStr)] public string parameters;
            [MarshalAs(UnmanagedType.LPStr)] public string directory;
            public int nShow;
            public uint dwHotKey;
            public IntPtr hIcon;
        }

        [Flags]
        public enum MIIM : uint
        {
            MIIM_STATE = 0x00000001,
            MIIM_ID = 0x00000002,
            MIIM_SUBMENU = 0x00000004,
            MIIM_CHECKMARKS = 0x00000008,
            MIIM_TYPE = 0x00000010,
            MIIM_DATA = 0x00000020,
            MIIM_STRING = 0x00000040,
            MIIM_BITMAP = 0x00000080,
            MIIM_FTYPE = 0x00000100
        }

        public enum MFT : uint
        {
            MFT_STRING = 0x00000000,
            MFT_BITMAP = 0x00000004,
            MFT_MENUBARBREAK = 0x00000020,
            MFT_MENUBREAK = 0x00000040,
            MFT_OWNERDRAW = 0x00000100,
            MFT_RADIOCHECK = 0x00000200,
            MFT_SEPARATOR = 0x00000800,
            MFT_RIGHTORDER = 0x00002000,
            MFT_RIGHTJUSTIFY = 0x00004000
        }

        [Flags]
        public enum MFS : uint
        {
            MFS_ENABLED = 0x00000000,
            MFS_UNCHECKED = 0x00000000,
            MFS_UNHILITE = 0x00000000,
            MFS_GRAYED = 0x00000003,
            MFS_DISABLED = 0x00000003,
            MFS_CHECKED = 0x00000008,
            MFS_HILITE = 0x00000080,
            MFS_DEFAULT = 0x00001000
        }

        public struct MenuItem
        {
            internal IntPtr Bitmap;
            internal string Commands;
            internal bool? ShowInMainMenu;
            internal string Text;
            internal bool Enabled;

            internal MenuItem(string text, bool enabled, bool? showInMainMenu, IntPtr bitmap, string commands)
            {
                ShowInMainMenu = showInMainMenu;
                Text = text;
                Enabled = enabled;
                Bitmap = bitmap;
                Commands = commands;
            }
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct MENUITEMINFO
        {
            public uint cbSize;
            public MIIM fMask;
            public MFT fType;
            public MFS fState;
            public uint wID;
            public IntPtr hSubMenu;
            public IntPtr hbmpChecked;
            public IntPtr hbmpUnchecked;
            public UIntPtr dwItemData;
            public string dwTypeData;
            public uint cch;
            public IntPtr hbmpItem;
        }

        [Flags]
        public enum HChangeNotifyFlags
        {
            SHCNF_DWORD = 0x0003,
            SHCNF_IDLIST = 0x0000,
            SHCNF_PATHA = 0x0001,
            SHCNF_PATHW = 0x0005,
            SHCNF_PRINTERA = 0x0002,
            SHCNF_PRINTERW = 0x0006,
            SHCNF_FLUSH = 0x1000,
            SHCNF_FLUSHNOWAIT = 0x2000
        }

        [Flags]
        public enum HChangeNotifyEventID
        {
            SHCNE_ALLEVENTS = 0x7FFFFFFF,

            SHCNE_ASSOCCHANGED = 0x08000000,

            SHCNE_ATTRIBUTES = 0x00000800,

            SHCNE_CREATE = 0x00000002,

            SHCNE_DELETE = 0x00000004,

            SHCNE_DRIVEADD = 0x00000100,

            SHCNE_DRIVEADDGUI = 0x00010000,

            SHCNE_DRIVEREMOVED = 0x00000080,

            SHCNE_EXTENDED_EVENT = 0x04000000,

            SHCNE_FREESPACE = 0x00040000,

            SHCNE_MEDIAINSERTED = 0x00000020,

            SHCNE_MEDIAREMOVED = 0x00000040,

            SHCNE_MKDIR = 0x00000008,

            SHCNE_NETSHARE = 0x00000200,

            SHCNE_NETUNSHARE = 0x00000400,

            SHCNE_RENAMEFOLDER = 0x00020000,

            SHCNE_RENAMEITEM = 0x00000001,

            SHCNE_RMDIR = 0x00000010,

            SHCNE_SERVERDISCONNECT = 0x00004000,

            SHCNE_UPDATEDIR = 0x00001000,

            SHCNE_UPDATEIMAGE = 0x00008000,
        }

        #endregion


        [DllImport("user32", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool InsertMenuItem(IntPtr hMenu, uint uItem,
            [MarshalAs(UnmanagedType.Bool)] bool fByPosition,
            ref MENUITEMINFO mii);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern IntPtr CreatePopupMenu();

        [DllImport("shell32", CharSet = CharSet.Unicode)]
        public static extern uint DragQueryFile(
            IntPtr hDrop,
            uint iFile,
            StringBuilder pszFile,
            int cch);

        [DllImport("ole32.dll", CharSet = CharSet.Unicode)]
        public static extern void ReleaseStgMedium(ref STGMEDIUM pmedium);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetDesktopWindow(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr UpdateWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("shell32.dll")]
        public static extern void SHChangeNotify(HChangeNotifyEventID wEventId, HChangeNotifyFlags uFlags,
            IntPtr dwItem1, IntPtr dwItem2);

        #endregion
    }
}