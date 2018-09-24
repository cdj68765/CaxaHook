using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using static ETCTool.NativeApi;
using IDataObject = System.Runtime.InteropServices.ComTypes.IDataObject;

namespace ETCTool
{

    [ClassInterface(ClassInterfaceType.None)]
    [Guid("B3F0615C-D04E-41DC-A1EB-4E8B8DCC14A1")]
    [ComVisible(true)]
    public class FileContextMenuExt : IShellExtInit, IContextMenu
    {
        private readonly List<NativeApi.MenuItem> ContextItems = new List<NativeApi.MenuItem>();

        //用于记录文件数量
        private List<string> FilePath = new List<string>();

        public FileContextMenuExt()
        {
            ContextItems.Add(new NativeApi.MenuItem("EtcTool", true, null,
                ICO.ICO.System_preferences_tool_tools_128px_581754_easyicon_net1.GetHbitmap(), ""));
            ContextItems.Add(new NativeApi.MenuItem("解密打开", true, null, ICO.ICO.Start1.GetHbitmap(), "Open"));
            ContextItems.Add(new NativeApi.MenuItem("解密复制", true, null, ICO.ICO.button_purple1.GetHbitmap(),
                "Copy"));
            ContextItems.Add(new NativeApi.MenuItem("原地解密", true, null, ICO.ICO.circle_yellow1.GetHbitmap(),
                "Decrypt"));
        }

        //注册项目
        public int QueryContextMenu(IntPtr hMenu, uint iMenu, uint idCmdFirst, uint idCmdLast, uint uFlags)
        {
            new Mutex(true, "ETCTool", out var Close);
            if (!Close)
            {
                MainFun.FileDecryptFun(false);
                UpdateWindow(GetWindowDC(GetDesktopWindow(IntPtr.Zero)));
                SHChangeNotify(HChangeNotifyEventID.SHCNE_ALLEVENTS, HChangeNotifyFlags.SHCNF_FLUSH, IntPtr.Zero, IntPtr.Zero);
                return 0;
            }
            // If uFlags include CMF_DEFAULTONLY then we should not do anything.
            if (((uint) CMF.CMF_DEFAULTONLY & uFlags) != 0) return 0;

            // Add a separator.
            /*  var sep = new MENUITEMINFO();
              sep.cbSize = (uint)Marshal.SizeOf(sep);
              sep.fMask = MIIM.MIIM_TYPE;
              sep.fType = MFT.MFT_SEPARATOR;
              if (!InsertMenuItem(hMenu, 0, true, ref sep))
                  return Marshal.GetHRForLastWin32Error();*/

            // Register item 0: Submenu
            var hSubMenu = CreatePopupMenu();
            var item = ContextItems[0];
            RegisterMenuItem(0, idCmdFirst, item.Text, true, item.Bitmap, hSubMenu, 1, hMenu);
            // Register item 1: RunDefault
            item = ContextItems[1];
            RegisterMenuItem(1, idCmdFirst, item.Text, true, item.Bitmap, IntPtr.Zero, 0, hSubMenu);
            // Add a separator.
            /*  sep = new MENUITEMINFO();
              sep.cbSize = (uint)Marshal.SizeOf(sep);
              sep.fMask = MIIM.MIIM_TYPE;
              sep.fType = MFT.MFT_SEPARATOR;
              InsertMenuItem(hSubMenu, 1, true, ref sep);*/

            // Register item 2 (Submenu->ManageApp).
            item = ContextItems[2];
            RegisterMenuItem(2, idCmdFirst, item.Text, true, item.Bitmap, IntPtr.Zero, 2, hSubMenu);
            // Register item 3 (Submenu->ManageAll).
            item = ContextItems[3];
            RegisterMenuItem(3, idCmdFirst, item.Text, true, item.Bitmap, IntPtr.Zero, 3, hSubMenu);

            /*  sep = new MENUITEMINFO();
              sep.cbSize = (uint)Marshal.SizeOf(sep);
              sep.fMask = MIIM.MIIM_TYPE;
              sep.fType = MFT.MFT_SEPARATOR;*/
            return MAKE_HRESULT(0, 0, (uint) ContextItems.Count); //3个划线+4个项目

            int MAKE_HRESULT(uint sev, uint fac, uint code)
            {
                return (int) ((sev << 31) | (fac << 16) | code);
            }

            int RegisterMenuItem(uint id,
                uint _idCmdFirst,
                string text,
                bool enabled,
                IntPtr bitmap,
                IntPtr subMenu,
                uint position,
                IntPtr registerTo)
            {
                var sub = new MENUITEMINFO();
                sub.cbSize = (uint) Marshal.SizeOf(sub);

                var m = MIIM.MIIM_STRING | MIIM.MIIM_FTYPE | MIIM.MIIM_ID |
                        MIIM.MIIM_STATE;
                if (bitmap != IntPtr.Zero)
                    m |= MIIM.MIIM_BITMAP;
                if (subMenu != IntPtr.Zero)
                    m |= MIIM.MIIM_SUBMENU;
                sub.fMask = m;
                sub.wID = _idCmdFirst + id;
                sub.fType = MFT.MFT_STRING;
                sub.dwTypeData = text;
                sub.hSubMenu = subMenu;
                sub.fState = enabled ? MFS.MFS_ENABLED : MFS.MFS_DISABLED;
                sub.hbmpItem = bitmap;

                if (!InsertMenuItem(registerTo, position, true, ref sub))
                    return Marshal.GetHRForLastWin32Error();
                return 0;
            }
        }

        //点击后命令回调
        public void InvokeCommand(IntPtr pici)
        {
            try
            {
                var Index = ContextItems[
                    LowWord(((CMINVOKECOMMANDINFO) Marshal.PtrToStructure(pici, typeof(CMINVOKECOMMANDINFO))).verb
                        .ToInt32())];
                if (FilePath.Count == 0) return;
                switch (Index.Commands)
                {
                    case "Open":
                    {

                        if (FilePath.Count != 1)
                        {

                        }
                    }
                        break;
                    case "Copy":
                    {

                    }
                        break;
                    case "Decrypt":
                    {
                        using (var pipeClient = new NamedPipeClientStream("EtcTool")) //创建管道
                        {
                            try
                            {
                                    pipeClient.Connect();
                                if (pipeClient.IsConnected)
                                {
                                    using (var MemoryStream = new MemoryStream())
                                    {
                                        FilePath.Add("Decrypt");
                                        new BinaryFormatter().Serialize(MemoryStream, FilePath.ToArray());
                                        pipeClient.WaitForPipeDrain();
                                    }
                                }
                            }
                            catch (IOException e)
                            {
                                Variables.MainForm.OntherLog.Add(new[] { $"{DateTime.Now:hh:mm:ss}->", $"管道错误，失败原因{e.Message}" });
                            }
                        }
                        }
                        break;
                }
            }
            catch (Exception e)
            {
            }

            GC.Collect();

            int LowWord(int number)
            {
                return number & 0xffff;
            }
        }

        public void GetCommandString(UIntPtr idCmd, uint uFlags, IntPtr pReserved, StringBuilder pszName,
            uint cchMax)
        {
        }
        //在注册菜单之前发生，用于获得各种数据
        public void Initialize(IntPtr pidlFolder, IntPtr pDataObj, IntPtr hKeyProgId)
        {
            if (pDataObj == IntPtr.Zero)
            {
                Variables.MainForm.OntherLog.Add(new[] {$"{DateTime.Now:hh:mm:ss}->发生未知错误在获得数据时", ""});
                return;
            }
            var fe = new FORMATETC
            {
                cfFormat = 15,
                ptd = IntPtr.Zero,
                dwAspect = DVASPECT.DVASPECT_CONTENT,
                lindex = -1,
                tymed = TYMED.TYMED_HGLOBAL
            };
            STGMEDIUM stm;
            var dataObject = (IDataObject) Marshal.GetObjectForIUnknown(pDataObj);
            dataObject.GetData(ref fe, out stm);
            try
            {
                var hDrop = stm.unionmember;
                if (hDrop == IntPtr.Zero) throw new ArgumentException();
                var nFiles = DragQueryFile(hDrop, 0xFFFFFFFF, null, 0); //获得选中文件数
                if (nFiles != 0)
                {
                    FilePath = new List<string>();
                    for (uint i = 0; i <= nFiles - 1; i++)
                    {
                        var fileName = new StringBuilder(1024);
                        if (DragQueryFile(hDrop,
                                i,
                                fileName,
                                fileName.Capacity) != 0)
                            FilePath.Add(fileName.ToString());
                    }
                }
            }
            finally
            {
                ReleaseStgMedium(ref stm);
            }
        }
    }

    #region 右键菜单的接口

    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("000214e8-0000-0000-c000-000000000046")]
    internal interface IShellExtInit //接收explorer传递的信息
    {
        void Initialize(
            IntPtr /*LPCITEMIDLIST*/ pidlFolder,
            IntPtr /*LPDATAOBJECT*/ pDataObj,
            IntPtr /*HKEY*/ hKeyProgId);
    }

    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("000214e4-0000-0000-c000-000000000046")]
    internal interface IContextMenu //实现右键扩展
    {
        [PreserveSig]
        int QueryContextMenu(
            IntPtr /*HMENU*/ hMenu,
            uint iMenu,
            uint idCmdFirst,
            uint idCmdLast,
            uint uFlags);

        void InvokeCommand(IntPtr pici);

        void GetCommandString(
            UIntPtr idCmd,
            uint uFlags,
            IntPtr pReserved,
            StringBuilder pszName,
            uint cchMax);
    }

    #endregion

}