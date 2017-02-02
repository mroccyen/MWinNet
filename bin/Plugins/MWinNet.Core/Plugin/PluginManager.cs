using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace MWinNet.Core
{
    public class PluginManager
    {
        public static void SetupPlugin(string path)
        {
            using (XmlReader reader = XmlReader.Create(path))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.IsStartElement())
                    {
                        switch (reader.LocalName)
                        {
                            case "Menu":
                                MenuPlugin menuEntity = new MenuPlugin();
                                menuEntity.SetupPlugin(reader);
                                break;
                            case "DockBar":
                                DockBarPlugin dockBarPlugin = new DockBarPlugin();
                                dockBarPlugin.SetupPlugin(reader);
                                break;
                        }
                    }
                }

            }
        }

        public static void SetupPlugin()
        {
            FileInfo[] files = FileToolkit.GetFileInfo();
            foreach (var file in files)
            {
                SetupPlugin(file.FullName);
            }
        }
    }
}
