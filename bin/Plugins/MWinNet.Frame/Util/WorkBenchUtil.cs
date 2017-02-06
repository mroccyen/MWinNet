using System.Windows.Forms;

namespace MWinNet.Frame
{
    public class WorkBenchUtil
    {
        private static WorkBench _workBench = WorkBenchInstance.Instance;
        public static WorkBench WorkBench
        {
            get
            {
                FrameConstructor constructor = new FrameConstructor();
                constructor.Initialize();
                return _workBench;
            }
        }

        public static void AddControl(Control control)
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
