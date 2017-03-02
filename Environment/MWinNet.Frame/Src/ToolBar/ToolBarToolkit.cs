using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MWinNet.Frame
{
    public class ToolBarToolkit
    {
        public static ToolStripItemDisplayStyle GetDisplayStyle(string displayStyle)
        {
            ToolStripItemDisplayStyle style = ToolStripItemDisplayStyle.ImageAndText;
            switch (displayStyle)
            {
                case "Text":
                    style = ToolStripItemDisplayStyle.Text;
                    break;
                case "Image":
                    style = ToolStripItemDisplayStyle.Image;
                    break;
                case "ImageAndText":
                    style = ToolStripItemDisplayStyle.ImageAndText;
                    break;
                default:
                    throw new Exception("参数输入不正确！");
            }
            return style;
        }
    }
}
