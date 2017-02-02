using MWinNet.Frame.UI;
using System.Windows.Forms;

namespace MWinNet.Frame
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
