using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MWinNet.Core
{
    public class ToolBarComboBoxItemPlugin : PluginBase
    {
        public string Id
        {
            get; set;
        }

        public string Label
        {
            get; set;
        }

        public void SetupPlugin(XmlReader reader)
        {
            do
            {
                if (reader.NodeType == XmlNodeType.EndElement
                 && reader.LocalName.Equals("ToolBarComboBoxItem"))
                {
                    break;
                }
                if (reader.LocalName.Equals("ToolBarComboBoxItem") && reader.IsStartElement())
                {
                    this.Path = reader.GetAttribute("path");
                    this.Id = reader.GetAttribute("id");
                    this.Label = reader.GetAttribute("label");
                    this.AssemblyName = reader.GetAttribute("assemblyName");
                    this.ClassName = reader.GetAttribute("className");

                    //初始化插件
                    InitializePlugin();
                    reader.MoveToElement(); 
                }
            }
            while (reader.Read());

        }
    }
}
