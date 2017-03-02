using MWinNet.Frame;

namespace MWinNet.MainFrame
{
    public partial class WorkPropertyWindow : ToolWindow
    {
        public WorkPropertyWindow()
        {
            InitializeComponent();
            MidViewContent midView = new MidViewContent();
            ViewControl = midView.ViewControl;
        }
    }
}
