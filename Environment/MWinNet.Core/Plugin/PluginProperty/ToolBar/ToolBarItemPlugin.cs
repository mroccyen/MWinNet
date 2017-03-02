using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MWinNet.Core
{
    public class ToolBarItemPlugin
    {
        public virtual void SetupPlugin(XmlReader reader)
        {
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.EndElement
                    && reader.LocalName.Equals("ToolBar"))
                {
                    break;
                }
                if (reader.NodeType == XmlNodeType.Element && reader.IsStartElement())
                {
                    switch (reader.LocalName)
                    {
                        case "ToolBarButton":
                            ToolBarButtonPlugin buttonPlugin = new ToolBarButtonPlugin();
                            buttonPlugin.SetupPlugin(reader);
                            break;
                        case "ToolBarSeparator":
                            ToolBarSeparatorPlugin separatorPlugin = new ToolBarSeparatorPlugin();
                            separatorPlugin.SetupPlugin(reader);
                            break;
                    }
                }
            }
        }


    }
}
