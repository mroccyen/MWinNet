using MWinNet.Frame;
using System.Windows.Forms;

namespace MWinNet.MainFrame
{
    public partial class WorkMidWindow : ToolWindow
    {
        public WorkMidWindow()
        {
            InitializeComponent();
            MidViewContent midView = new MidViewContent();
            ViewControl = midView.ViewControl;
        }
    }
}
