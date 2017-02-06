using MWinNet.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace MWinNet.Frame
{
    public class AssemblyUtil
    {
        public static string[] GetDlls()
        {
            List<string> dllFiles = new List<string>();
            DirectoryInfo[] directorys = FileToolkit.GetDirectorys();
            foreach (var dir in directorys)
            {
                string[] paths = FileToolkit.GetDllFiles(dir.FullName);
                dllFiles.AddRange(paths);
            }
            return dllFiles.ToArray();
        }

        public static string GetDll(string assemblyName)
        {
            string returnPath = null;
            DirectoryInfo[] directorys = FileToolkit.GetDirectorys();
            foreach (var dir in directorys)
            {
                string[] paths = FileToolkit.GetDllFiles(dir.FullName);
                foreach (var path in paths)
                {
                    if (path.Contains(assemblyName))
                    {
                        returnPath = path;
                        break;
                    }
                }
            }
            return returnPath;
        }

        public static T GetAssembly<T>(string path, string typeName) where T : class
        {
            Assembly assembly = Assembly.LoadFrom(path);
            var obj = assembly.CreateInstance(typeName);
            if (obj == null)
            {
                throw new NullReferenceException("获取type对象失败。");
            }
            return obj as T;
        }
    }
}
