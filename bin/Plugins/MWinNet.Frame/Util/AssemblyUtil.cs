using MWinNet.Core;
using System;
using System.IO;
using System.Reflection;

namespace MWinNet.Frame
{
    public class AssemblyUtil
    {
        /// <summary>
        /// 获取当前环境的执行路径
        /// </summary>
        public static string AssemblyPath
        {
            get { return Environment.CurrentDirectory; }
        }

        public static string[] GetDlls()
        {
            return Directory.GetFiles(Environment.CurrentDirectory, "*.dll");
        }

        public static string GetDll(string assemblyName)
        {
            string returnPath = null;
            string[] paths = Directory.GetFiles(Environment.CurrentDirectory, "*.dll");
            foreach (var path in paths)
            {
                if (path.Contains(assemblyName))
                {
                    returnPath = path;
                    break;
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
                throw new NullReferenceException("获取Command失败。");
            }
            return obj as T;
        }
    }
}
