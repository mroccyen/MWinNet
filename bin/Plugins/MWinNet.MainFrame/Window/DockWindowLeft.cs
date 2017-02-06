
using MWinNet.Frame;
using System.Windows.Forms;

namespace MWinNet.MainFrame
{
    public partial class DockWindowLeft : ToolWindow
    {
        public DockWindowLeft()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("test");
        }
    }
}
