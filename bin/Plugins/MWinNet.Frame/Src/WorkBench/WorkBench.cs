using MWinNet.Core;
using System;
using System.Windows.Forms;
using System.Xml;

namespace MWinNet.Frame
{
    public partial class WorkBench : Form
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
