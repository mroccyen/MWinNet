namespace MWinNet.Core
{
    public class Plugin
    {
        #region 属性

        private PluginBase _pluginBase;
        public PluginBase PluginBase
        {
            get
            {
                return _pluginBase;
            }
            set
            {
                _pluginBase = value;
            }
        }

        #endregion

        public object CreateObject(string className)
        {
            return null;
        }

        public static void InitializePlugin(PluginBase pluginBase)
        {
            PluginTree.Singleton.Plugins.Add(new Plugin() { PluginBase = pluginBase });
            PluginTree.Singleton.SetupPluginTreeNode(new Plugin() { PluginBase = pluginBase });
        }

    }
}
