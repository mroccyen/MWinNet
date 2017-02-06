using System;
using System.IO;

namespace MWinNet.Core
{
    public class FileToolkit
    {
        public static string[] GetDllFiles(string directoryPath)
        {
            string[] files = Directory.GetFiles(directoryPath, "*.dll");
            return files;
        }

        public static string[] GetConfigFiles(string directoryPath)
        {
            string[] files = Directory.GetFiles(directoryPath, "*.config");
            return files;
        }

        public static DirectoryInfo[] GetDirectorys()
        {
            string exePath = Environment.CurrentDirectory;
            DirectoryInfo info = new DirectoryInfo(Directory.GetParent(exePath).FullName + @"\Environment");
            return info.GetDirectories();
        }
    }
}
