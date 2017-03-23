using System.Xml;

namespace MWinNet.Core
{
    public class DockBarPlugin : PluginBase
    {
        public string Id
        {
            get; set;
        }

        public string Label
        {
            get; set;
        }

        public string DockType
        {
            get; set;
        }

        public string DockWindowClass
        {
            get; set;
        }

        public void SetupPlugin(XmlReader reader)
        {
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.EndElement
                    && reader.LocalName.Equals("DockBar"))
                {
                    break;
                }
                if (reader.LocalName.Equals("DockItem") && reader.IsStartElement())
                {
                    this.Path = reader.GetAttribute("path");
                    this.Id = reader.GetAttribute("id");
                    this.Label = reader.GetAttribute("label");
                    this.AssemblyName = reader.GetAttribute("assemblyName");
                    this.DockType = reader.GetAttribute("dockType");
                    this.DockWindowClass = reader.GetAttribute("dockWindowClass");

                    //初始化插件
                    InitializePlugin();
                    reader.MoveToElement(); //Moves the reader back to the element node.
                }
            }
        }


    }
}
