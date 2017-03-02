using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace MWinNet.Core
{
    public class AssemblyToolkit
    {
        public static string[] GetDlls()
        {
            List<string> dllFiles = new List<string>();
            DirectoryInfo[] directorys = CommonToolkit.GetPluginsDirectorys();
            foreach (var dir in directorys)
            {
                string[] paths = CommonToolkit.GetDllFiles(dir.FullName);
                dllFiles.AddRange(paths);
            }
            return dllFiles.ToArray();
        }

        public static string GetDll(string assemblyName)
        {
            string returnPath = null;
            DirectoryInfo[] directorys = CommonToolkit.GetPluginsDirectorys();
            foreach (var dir in directorys)
            {
                string[] paths = CommonToolkit.GetDllFiles(dir.FullName);
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

        public static T ActivateObject<T>(string path, string typeName) where T : class
        {
            Assembly assembly = Assembly.LoadFrom(path);
            var obj = assembly.CreateInstance(typeName);
            if (obj == null)
            {
                throw new NullReferenceException();
            }
            return obj as T;
        }
    }
}
