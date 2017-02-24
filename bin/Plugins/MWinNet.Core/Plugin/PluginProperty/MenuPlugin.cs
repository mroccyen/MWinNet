using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MWinNet.Core
{
    public class MenuPlugin : PluginBase
    {
        public string Id
        {
            get; set;
        }

        public string Caption
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
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.EndElement
                    && reader.LocalName.Equals("Menu"))
                {
                    break;
                }
                if ((reader.LocalName.Equals("MenuItem")
                    || reader.LocalName.Equals("MenuTab")
                    || reader.LocalName.Equals("MenuDropGroup"))
                    && reader.IsStartElement())
                {
                    //for (int i = 0; i < reader.AttributeCount; i++)
                    //{
                    //    reader.MoveToAttribute(i);
                    //    // some values are frequently repeated (e.g. type="MenuItem"),
                    //    // so we also use the NameTable for attribute values
                    //    // (XmlReader itself only uses it for attribute names)
                    //    string val = reader.NameTable.Add(reader.Value);
                    //    //MessageBox.Show("name:" + reader.LocalName + "     " + "value:" + val);
                    //}

                    this.Path = reader.GetAttribute("path");
                    this.Id = reader.GetAttribute("id");
                    this.Caption = reader.GetAttribute("caption");
                    this.Image = reader.GetAttribute("image");
                    this.Index = reader.GetAttribute("index");
                    this.AssemblyName = reader.GetAttribute("assemblyName");
                    this.ClassName = reader.GetAttribute("className");

                    //初始化插件
                    InitializePlugin();
                    reader.MoveToElement(); //Moves the reader back to the element node.
                }
            }
        }
    }
}
