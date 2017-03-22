using MWinNet.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWinNet.Frame
{
    public class StatusProgressBarSetup
    {
        public void Setup(Plugin plugin)
        {
            StatusProgressBarPlugin progressBarPlugin = plugin.PluginBase as StatusProgressBarPlugin;
            StatusProgressBar bar = GetStatusProgressBar(Convert.ToInt32(progressBarPlugin.Length));
            bar.Value = Convert.ToInt32(progressBarPlugin.Value);
            StatusBarSingleton.MainStatusBar.Add(bar);
        }

        private StatusProgressBar GetStatusProgressBar(int sizeX)
        {
            StatusProgressBar bar = new StatusProgressBar();
            bar.Name = "toolStripProgressBar";
            bar.Size = new System.Drawing.Size(sizeX, 16);
            bar.Maximum = 100;
            return bar;
        }
    }
}
