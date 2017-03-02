using MWinNet.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MWinNet.Frame
{
    public class ToolBarButton : ToolStripButton
    {
        private Command _cmd;

        public ToolBarButton(Command cmd)
        {
            _cmd = cmd;
            if (cmd != null)
            {
                this.Enabled = cmd.Enable();
            }
            this.Click += ToolBarButton_Click;
        }

        private void ToolBarButton_Click(object sender, EventArgs e)
        {
            if (_cmd != null)
            {
                _cmd.Run();
            }
        }
    }
}
