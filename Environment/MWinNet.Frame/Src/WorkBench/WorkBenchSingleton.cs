using System.Windows.Forms;

namespace MWinNet.Frame
{
    public class WorkBenchSingleton
    {
        private static WorkBenchSingleton _singleton = new WorkBenchSingleton();
        public static WorkBenchSingleton Singleton
        {
            get
            {
                return _singleton;
            }
        }

        private WorkBench _workBench = new WorkBench();
        public WorkBench WorkBench
        {
            get
            {
                ApplicationSetup constructor = new ApplicationSetup();
                constructor.Initialize();
                return _workBench;
            }
        }

        public void AddControl(Control control)
        {
            _workBench.SuspendLayout();
            if ((control as Menu) != null)
            {
                _workBench.MainMenuStrip = control as Menu;
            }
            _workBench.Controls.Add(control);
            _workBench.ResumeLayout(false);
            _workBench.PerformLayout();
        }

    }
}
