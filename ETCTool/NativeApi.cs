using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow(IntPtr hWnd);

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

        #endregion

    }
}
