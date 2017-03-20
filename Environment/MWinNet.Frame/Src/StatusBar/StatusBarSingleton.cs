using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWinNet.Frame
{
    public class StatusBarSingleton
    {
        private static StatusBar _mainStatusBar = null;
        public static StatusBar MainStatusBar
        {
            get
            {
                if (_mainStatusBar == null)
                {
                    _mainStatusBar = CreateStatusBar();
                }
                return _mainStatusBar;
            }
        }

        private static StatusBar CreateStatusBar()
        {
            StatusBar statusStrip = new StatusBar();
            statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            statusStrip.Location = new System.Drawing.Point(0, 0);
            statusStrip.Name = "statusStrip";
            statusStrip.TabIndex = 0;
            statusStrip.Text = "statusStrip";
            return statusStrip;
        }
    }
}
