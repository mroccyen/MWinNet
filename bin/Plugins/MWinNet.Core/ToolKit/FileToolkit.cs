using System;
using System.IO;

namespace MWinNet.Core
{
    public class FileToolkit
    {
        public static FileInfo[] GetFileInfo()
        {
            string exePath = Environment.CurrentDirectory;
            DirectoryInfo info = new DirectoryInfo(Directory.GetParent(exePath).FullName + @"\Environment");
            return info.GetFiles();
        }
    }
}
