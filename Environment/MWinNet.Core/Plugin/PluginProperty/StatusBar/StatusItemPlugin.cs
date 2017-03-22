using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MWinNet.Core
{
    public class StatusItemPlugin
    {
        public virtual void SetupPlugin(XmlReader reader)
        {
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.EndElement
                    && reader.LocalName.Equals("StatusBar"))
                {
                    break;
                }
                if (reader.NodeType == XmlNodeType.Element && reader.IsStartElement())
                {
                    switch (reader.LocalName)
                    {
                        case "StatusProgressBar":
                            StatusProgressBarPlugin progressBarPlugin = new StatusProgressBarPlugin();
                            progressBarPlugin.SetupPlugin(reader);
                            break;
                    }
                }
            }
        }
    }
}
