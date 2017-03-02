using System;
using MWinNet.Frame;
using System.Windows.Forms;

namespace MWinNet.StartUp
{
    static class StartUp
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(WorkBenchSingleton.Singleton.WorkBench);
        }
    }
}
