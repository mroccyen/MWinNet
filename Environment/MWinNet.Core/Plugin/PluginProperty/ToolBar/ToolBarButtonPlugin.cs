using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MWinNet.Core
{
    public class ToolBarButtonPlugin : PluginBase
    {
        public string Id
        {
            get; set;
        }

        public string DisplayStyle
        {
            get; set;
        }

        public string Label
        {
            get; set;
        }

        public string Image
        {
            get; set;
        }

        public string Index
        {
            get; set;
        }

        public void SetupPlugin(XmlReader reader)
        {
            do
            {
                if (reader.NodeType == XmlNodeType.EndElement
                 && reader.LocalName.Equals("ToolBarButton"))
                {
                    break;
                }
                if (reader.LocalName.Equals("ToolBarButton") && reader.IsStartElement())
                {
                    this.Path = reader.GetAttribute("path");
                    this.Id = reader.GetAttribute("id");
                    this.DisplayStyle = reader.GetAttribute("displayStyle");
                    this.Label = reader.GetAttribute("label");
                    this.Image = reader.GetAttribute("image");
                    this.Index = reader.GetAttribute("index");
                    this.AssemblyName = reader.GetAttribute("assemblyName");
                    this.ClassName = reader.GetAttribute("className");

                    //初始化插件
                    InitializePlugin();
                    reader.MoveToElement(); //Moves the reader back to the element node.
                }
            }
            while (reader.Read());

        }

    }
}
