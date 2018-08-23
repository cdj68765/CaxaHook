﻿using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace ETCTool
{
    internal class AssemblyHandler
    {
        internal static void AssemblyFileSaveToCaxaAutoSave(string Path)
        {
            var Ass = new DirectoryInfo(
                $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\EtcTool");
            if (!Ass.Exists) Ass.Create();
            using (var ReadFile = new FileStream(Process.GetCurrentProcess().MainModule.FileName,
                FileMode.Open, FileAccess.Read,
                FileShare.ReadWrite))
            {
                try
                {
                    using (var SaveFile =
                        new FileStream(
                            $"{Path}\\EtcTool\\{System.IO.Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName)}",
                            FileMode.Create))
                    {
                        ReadFile.CopyTo(SaveFile);
                    }
                }
                finally
                {
                }
            }
            if (!File.Exists($"{Ass}\\EasyLoad64.dll") || true)
            {
                foreach (var VARIABLE in new[]
                {
                    "EasyHook32.dll", "EasyHook32Svc.exe", "EasyLoad32.dll",
                    "EasyHook64Svc.exe", "EasyHook64.dll", "EasyLoad64.dll",
                    "MaterialSkin.dll", "EasyHook.dll", "CaxaInject.dll", "PLMInject.dll"
                })
                {
                    try
                    {
                        SaveToDisk(Ass.FullName, VARIABLE);
                    }
                    finally
                    {
                    }
                }
            }
            Directory.SetCurrentDirectory(Ass.FullName);
            void SaveToDisk(string fullName, string v)
            {
                Stream sm = Assembly.GetExecutingAssembly().GetManifestResourceStream($"ETCTool.{v}");
                if (sm != null)
                {
                    using (var File = new FileStream($"{fullName}\\{v}", FileMode.Create))
                    {
                        sm.CopyTo(File);
                    }

                    sm.Dispose();
                }
            }
        }
    }
}