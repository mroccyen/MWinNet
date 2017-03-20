using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWinNet.Core
{
    public class PluginTree
    {
        private static PluginTree _singleton;
        public static PluginTree Singleton
        {
            get
            {
                if (_singleton == null)
                {
                    return _singleton = new PluginTree();
                }
                return _singleton;
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
            List<string> pathList = CommonToolkit.PathParse(treeNode.Plugin.PluginBase.Path);
            SetupPluginTreeNode(_rootNode, treeNode, pathList, 0);
        }

        private void SetupPluginTreeNode(PluginTreeNode currentNode, PluginTreeNode needSetNode, List<string> pathList, int index)
        {
            if (index >= pathList.Count)
            {
                return;
            }
            if (currentNode.ChildNodes.Keys.Contains(pathList[index]))
            {
                if (index == pathList.Count - 1)
                {
                    currentNode.SetPlugin(needSetNode.Plugin);
                }
                SetupPluginTreeNode(currentNode.ChildNodes[pathList[index]], needSetNode, pathList, ++index);
            }
            else
            {
                PluginTreeNode newNode = new PluginTreeNode();
                currentNode.ChildNodes.Add(pathList[index], newNode);
                if (index == pathList.Count - 1)
                {
                    newNode.SetPlugin(needSetNode.Plugin);
                }
                SetupPluginTreeNode(newNode, needSetNode, pathList, ++index);
            }
        }

    }
}
