using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MWinNet.Frame
{
    public class StatusBar : StatusStrip
    {
        public void Add(ToolStripItem item)
        {
            //StatusBarSingleton.MainStatusBar.Items.Add(item);
            this.Items.Add(item);
        }
    }
}
