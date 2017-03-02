using MWinNet.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWinNet.Frame
{
    public class ToolBarSeparatorSetup
    {
        public void Setup(Plugin plugin)
        {
            ToolBarSeparator separator = new ToolBarSeparator();
            ToolBarSingleton.MainToolbar.Add(separator);
        }
    }
}
