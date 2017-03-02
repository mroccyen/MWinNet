using CCWin;
using System;
using System.Windows.Forms;

namespace MWinNet.Frame
{
    public partial class WorkBench : Skin_Metro
    {
        public WorkBench()
        {
            InitializeComponent();
            Application.Idle += Application_Idle;
        }

        private void Application_Idle(object sender, EventArgs e)
        {

        }
    }
}
