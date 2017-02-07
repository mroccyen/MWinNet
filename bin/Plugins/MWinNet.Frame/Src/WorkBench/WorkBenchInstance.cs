using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MWinNet.Frame
{
    public class WorkBenchInstance
    {
        private static WorkBenchInstance _instance = new WorkBenchInstance();
        public static WorkBenchInstance Instance
        {
            get
            {
                return _instance;
            }
        }

        private WorkBench _workBench = new WorkBench();
        public WorkBench WorkBench
        {
            get
            {
                ApplicationConstructor constructor = new ApplicationConstructor();
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
