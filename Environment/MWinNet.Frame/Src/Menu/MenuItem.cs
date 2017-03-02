using MWinNet.Core;
using System;
using System.Windows.Forms;

namespace MWinNet.Frame
{
    public class MenuItem : ToolStripMenuItem, IStatusUpdate
    {
        private Command _command;

        public MenuItem(Command cmd)
        {
            this._command = cmd;
            this.Enabled = _command == null ? true : _command.Enable();
            this.Click += MenuItem_Click;
        }

        public void AddMenuItemRange(ToolStripItem[] range)
        {
            Array.ForEach(range, item =>
            {
                this.DropDownItems.AddRange(new ToolStripItem[] { item });
            });
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
            if (_command != null)
            {
                _command.Run();
            }
        }

        public void UpdateStatus()
        {
            if (_command != null)
            {
                this.Enabled = _command.Enable();
            }
        }

        public void UpdateText()
        {
            if (_command != null)
            {

            }
        }
    }
}
