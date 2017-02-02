using MWinNet.Core;
using System;
using System.Windows.Forms;

namespace MWinNet.Frame.UI
{
    public class MenuItem : ToolStripMenuItem, IStatusUpdate
    {
        private Command _command;

        public MenuItem(Command cmd, string caption)
        {
            if (cmd != null)
            {
                this._command = cmd;
                this.Enabled = _command.Enable();
            }
            this.Text = caption;
            this.Click += MenuItem_Click;
        }

        public MenuItem(string caption)
        {
            this.Text = caption;
            this.Enabled = true;
        }

        public void InitializeMenuItem(MenuPlugin menuEntity)
        {
            this.Name = menuEntity.Caption;
            this.Size = new System.Drawing.Size(52, 28);
            this.Text = menuEntity.Caption;
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
