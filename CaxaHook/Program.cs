using EasyHook;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;

namespace CaxaHook
{
    internal static class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            var Guid = ((GuidAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(),
                typeof(GuidAttribute))).Value;
            var Path = Class1.AssemblyFileSaveToCaxaAutoSave(out DirectoryInfo Ass);
            {
                if (args.Length == 0)
                {
                    using (var ReadFile = new FileStream(Process.GetCurrentProcess().MainModule.FileName,
                        FileMode.Open, FileAccess.Read,
                        FileShare.ReadWrite))
                    {
                        try
                        {
                            using (var SaveFile = new FileStream($"{Path}\\CaxaAutoSave\\{System.IO.Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName)}", FileMode.Create))
                            {
                                ReadFile.CopyToAsync(SaveFile).Wait();
                            }

                            /*  Stream sm = Assembly.GetExecutingAssembly().GetManifestResourceStream($"CaxaHook.CaxaInject.dll");
                              if (sm != null)
                              {
                                  using (var File = new FileStream($"{Path}\\CaxaAutoSave\\CaxaInject.dll", FileMode.Create))
                                  {
                                      sm.CopyToAsync(File).Wait();
                                  }
                                  sm.Dispose();
                              }*/
                        }
                        catch (Exception)
                        {
                        }
                    }

                    // File.Copy($"{AppDomain.CurrentDomain.BaseDirectory}\\CaxaInject.dll", $"{Path}\\CaxaAutoSave\\CaxaInject.dll", true);
                }
            }
            if (!Class1.RuntimeInfo.RunMode)
            {
                if (AppDomain.CurrentDomain.IsDefaultAppDomain() && args.Length == 0)
                {
                    AppDomain newDomain = AppDomain.CreateDomain("StartNewProcess", null, new AppDomainSetup()
                    {
                        PrivateBinPath = $"{Path}\\CaxaAutoSave",
                        ApplicationBase = $"{Path}\\CaxaAutoSave"
                    });
                    int ret = newDomain.ExecuteAssemblyByName(Assembly.GetExecutingAssembly().FullName, Guid);
                    AppDomain.Unload(newDomain);
                    Environment.ExitCode = ret;
                    Environment.Exit(0);
                }
                else
                {
                    try
                    {
                        if (RemoteHooking.IsAdministrator) ;
                    }
                    catch (Exception e)
                    {
                        Class1.RuntimeInfo.RunMode = true;
                        Class1.RuntimeInfo.Save();
                        StartNewProcess();
                        return;
                    }
                    Class1.Form1 = new Form1();
                    Class1.Form1.ShowDialog();
                }
            }
            else
            {
                if (args.Length == 0)
                {
                    StartNewProcess();
                }
                else if (args[0] == Guid)
                {
                    Class1.Form1 = new Form1();
                    Class1.Form1.ShowDialog();
                }
            }

            void StartNewProcess()
            {
                new Mutex(true, "CaxaHook", out bool Close);
                if (!Close) return;
                //Process.Start($"{Path}\\CaxaAutoSave\\CaxaHook.exe", Guid);
            }
        }
    }
}