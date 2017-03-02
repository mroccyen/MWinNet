using System.Windows.Forms;
using MWinNet.Dock;

namespace MWinNet.Frame
{
    public partial class ToolWindow : DockContent, IViewContent
    {
        public ToolWindow()
        {
            InitializeComponent();
        }

        private Control _control = null;
        public virtual Control ViewControl
        {
            get { return _control; }
            set
            {
                if (_control != null)
                {
                    Controls.Remove(_control);
                }
                _control = value;
                Controls.Add(_control);
            }
        }
    }
}
