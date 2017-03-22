using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MWinNet.Core
{
    public class StatusProgressBarPlugin : PluginBase
    {
        public string Id
        {
            get; set;
        }

        public string Value
        {
            get; set;
        }

        public string Length
        {
            get; set;
        }

        public void SetupPlugin(XmlReader reader)
        {
            do
            {
                if (reader.NodeType == XmlNodeType.EndElement && reader.LocalName.Equals("StatusProgressBar"))
                {
                    break;
                }
                if (reader.LocalName.Equals("StatusProgressBar") && reader.IsStartElement())
                {
                    this.Path = reader.GetAttribute("path");
                    this.Id = reader.GetAttribute("id");
                    this.Value = reader.GetAttribute("value");
                    this.Length = reader.GetAttribute("length");
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
