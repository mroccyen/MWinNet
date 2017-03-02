using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWinNet.Frame
{
    public class ToolBarSingleton
    {
        private static ToolBar _mainToolBar = null;
        public static ToolBar MainToolbar
        {
            get
            {
                if (_mainToolBar == null)
                {
                    _mainToolBar = CreateToolBar();
                }
                return _mainToolBar;
            }
        }

        private static ToolBar CreateToolBar()
        {
            ToolBar bar = new ToolBar();
            bar.ImageScalingSize = new System.Drawing.Size(24, 24);
            bar.Location = new System.Drawing.Point(0, 0);
            bar.Name = "_mainToolBar";
            bar.TabIndex = 0;
            bar.Text = "MainToolBar";
            return bar;
        }

    }
}
