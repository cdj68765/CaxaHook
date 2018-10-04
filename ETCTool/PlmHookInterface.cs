using System;
using System.Linq;
using System.Text;
using System.Threading;
using static ETCTool.NativeApi;

namespace ETCTool
{
    public class PlmHookInterface : MarshalByRefObject
    {
        public void Ping(out bool ping, string Channal)
        {
            if (!Variables.PlmMonitorRun)
            {
                try
                {
                    var Find = Variables.MainForm.PlmPid.FirstOrDefault(x => x.Value == Channal);
                    Variables.MainForm.PlmPid.Remove(Find.Key);
                    Variables.MainForm.PlmMonitorLog.Add(new[]
                        {$"{DateTime.Now:hh:mm:ss}->进程{Find.Key}删除完毕", $""});
                }
                catch (Exception e)
                {
                    Variables.MainForm.PlmMonitorLog.Add(new[]
                        {$"{DateTime.Now:hh:mm:ss}->删除错误，错误信息{e}", $""});
                }

                ping = false;
            }
            else
            {
                ping = true;
            }
        }

        public void Info(string v)
        {
            Variables.MainForm.PlmMonitorLog.Add(new[] { $"{DateTime.Now:hh:mm:ss}->{v}", $"" });
        }

        public void AutoPerformClick(IntPtr hwnd)
        {
            if (Variables.CheckAutoPerformClick)
            {
                if (Variables.AutoPerformClickCount > 0)
                {
                    ThreadPool.QueueUserWorkItem(state =>
                    {
                        GetCursorPos(out var lpPoint);
                        if (lpPoint.Equals(Variables.TheLastMouseCursor))
                        {
                            Interlocked.Decrement(ref Variables.AutoPerformClickCount);
                            Variables.MainForm.PlmMonitorLog.Add(new[]
                                {$"{DateTime.Now:hh:mm:ss}->鼠标未移动，剩余跳过次数", $"{Variables.AutoPerformClickCount}"});
                        }
                        else
                        {
                            Variables.MainForm.PlmMonitorLog.Add(new[]
                            {
                                $"{DateTime.Now:hh:mm:ss}->鼠标有移动，计数重置为", $"{Variables.setting.AutoPerformClickCount}"
                            });
                            Variables.AutoPerformClickCount = Variables.setting.AutoPerformClickCount;
                            Variables.TheLastMouseCursor = lpPoint;
                        }
                    });
                    ThreadPool.QueueUserWorkItem(state =>
                    {
                        Thread.Sleep(1000);
                        Variables.MainForm.PlmMonitorLog.Add(new[]
                            {$"{DateTime.Now:hh:mm:ss}->", $"尝试激活自动确认功能"});
                        var GetText = new StringBuilder(256);
                        GetWindowTextW(hwnd, GetText, 256);
                        for (var i = 0; i < 10; i++)
                        {
                            var childHwnd = FindWindowEx(hwnd, IntPtr.Zero, "SWT_Window0", "");
                            if (childHwnd != IntPtr.Zero)
                                for (var j = 0; j < 10; j++)
                                {
                                    var Button = FindWindowEx(childHwnd, IntPtr.Zero, "Button", "确定");
                                    if (Button == IntPtr.Zero)
                                    {
                                        childHwnd = GetWindow(childHwnd, 2);
                                    }
                                    else
                                    {
                                        var ret = SendMessageA(Button, 0xF5, IntPtr.Zero, IntPtr.Zero);
                                        do
                                        {
                                            ret = SendMessageA(Button, 0xF5, IntPtr.Zero, IntPtr.Zero);
                                        } while (ret != 0);

                                        break;
                                    }
                                }

                            Thread.Sleep(1000);
                        }
                    });
                }
                else
                {
                    Variables.MainForm.PlmMonitorLog.Add(new[]
                        {$"{DateTime.Now:hh:mm:ss}->超过自动确认计数，重置计数为", $"{Variables.setting.AutoPerformClickCount}"});
                    Variables.AutoPerformClickCount = Variables.setting.AutoPerformClickCount;
                }
            }
        }
    }
}