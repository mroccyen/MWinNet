using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWinNet.Core
{
    public class PluginTree
    {
        private static PluginTree _instance;
        public static PluginTree Instance
        {
            get
            {
                if (_instance == null)
                {
                    return _instance = new PluginTree();
                }
                return _instance;
            }
        }

        private List<Plugin> _plugins = new List<Plugin>();
        public List<Plugin> Plugins
        {
            get
            {
                return _plugins;
            }
        }

        private PluginTreeNode _rootNode = new PluginTreeNode();
        public PluginTreeNode RootNode
        {
            get { return _rootNode; }
        }

        public void AddPlugin(Plugin plugin)
        {
            _plugins.Add(plugin);

        }

        public void SetupPluginTreeNode(Plugin plugin)
        {
            SetupPluginTreeNode(new PluginTreeNode(plugin));
        }

        public void SetupPluginTreeNode(PluginTreeNode treeNode)
        {
            List<string> pathList = CommonToolkit.PathParse(treeNode.Plugin.PluginEntity.Path);
            SetupPluginTreeNode(_rootNode, treeNode, pathList, 0);
        }

        private void SetupPluginTreeNode(PluginTreeNode currentNode, PluginTreeNode p, List<string> pathList, int index)
        {
            if (index >= pathList.Count)
            {
                return;
            }
            if (currentNode.ChildNodes.Keys.Contains(pathList[index]))
            {
                if (index == pathList.Count - 1)
                {
                    currentNode.SetPlugin(p.Plugin);
                }
                SetupPluginTreeNode(currentNode.ChildNodes[pathList[index]], p, pathList, ++index);
            }
            else
            {
                PluginTreeNode pn = new PluginTreeNode();
                currentNode.ChildNodes.Add(pathList[index], pn);
                if (index == pathList.Count - 1)
                {
                    pn.SetPlugin(p.Plugin);
                }
                SetupPluginTreeNode(pn, p, pathList, ++index);
            }
        }


    }
}
