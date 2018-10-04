using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Reflection;

namespace ETCTool
{
    internal class AssemblyHandler
    {
        internal static void AssemblyFileSaveToCaxaAutoSave(string Path)
        {
            var Ass = new DirectoryInfo(
                $"{Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)}\\EtcTool");
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
                catch (Exception) { }
            }

            if (!File.Exists($"{Ass}\\EasyLoad64.dll"))
                foreach (var VARIABLE in new[]
                {
                    "EasyHook32.dll", "EasyHook32Svc.exe", "EasyLoad32.dll",
                    "EasyHook64Svc.exe", "EasyHook64.dll", "EasyLoad64.dll",
                    "MaterialSkin.dll", "EasyHook.dll", "CaxaInject.dll",
                    "PlmInject.dll", "WPFFolderBrowser.dll", "LdTermInject.dll"
                })
                    try
                    {
                        SaveToDisk(Ass.FullName, VARIABLE);
                    }
                    finally
                    {
                    }
            if (!File.Exists($"{Ass.FullName}\\Crx.dll"))
            {
                DeCompressMulti(Ass.FullName);
            }

            Directory.SetCurrentDirectory(Ass.FullName);
            void SaveToDisk(string fullName, string v)
            {
                try
                {
                    var sm = Assembly.GetExecutingAssembly().GetManifestResourceStream($"ETCTool.{v}");
                    if (sm != null)
                    {
                        using (var File = new FileStream($"{fullName}\\{v}", FileMode.Create))
                        {
                            sm.CopyTo(File);
                        }

                        sm.Dispose();
                    }
                }
                catch (Exception)
                {
                }
            }
            void DeCompressMulti(string DirPath)
            {
                byte[] fileSize = new byte[4];
                using (MemoryStream ms = new MemoryStream())
                {
                    using (GZipStream zipStream =
                        new GZipStream(new MemoryStream(ICO.ICO.caxa), CompressionMode.Decompress))
                    {
                        zipStream.CopyTo(ms);
                    }

                    ms.Position = 0;
                    while (ms.Position != ms.Length)
                    {
                        ms.Read(fileSize, 0, fileSize.Length);
                        int fileNameLength = BitConverter.ToInt32(fileSize, 0);
                        byte[] fileNameBytes = new byte[fileNameLength];
                        ms.Read(fileNameBytes, 0, fileNameBytes.Length);
                        string fileName = System.Text.Encoding.UTF8.GetString(fileNameBytes);
                        ms.Read(fileSize, 0, 4);
                        int fileContentLength = BitConverter.ToInt32(fileSize, 0);
                        byte[] fileContentBytes = new byte[fileContentLength];
                        ms.Read(fileContentBytes, 0, fileContentBytes.Length);
                        using (FileStream childFileStream = File.Create($"{DirPath}\\{fileName}"))
                        {
                            childFileStream.Write(fileContentBytes, 0, fileContentBytes.Length);
                        }
                    }
                }
            }
        }
    }
}