using System.Collections.Generic;

namespace MWinNet.Core
{
    public class PluginTreeNode
    {
        private Dictionary<string, PluginTreeNode> _childNodes = new Dictionary<string, PluginTreeNode>();
        public Dictionary<string, PluginTreeNode> ChildNodes
        {
            get
            {
                return _childNodes;
            }
            set
            {
                _childNodes = value;
            }
        }

        private Plugin _plugin = new Plugin();
        public Plugin Plugin
        {
            get { return _plugin; }
        }

        public PluginTreeNode(Plugin plugin)
        {
            _plugin = plugin;
        }

        public PluginTreeNode()
        {

        }

        public void SetPlugin(Plugin plugin)
        {
            _plugin = plugin;
        }

    }
}
