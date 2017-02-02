namespace MWinNet.Core
{
    public class Plugin
    {
        #region 属性

        private PluginBase _pluginEntity;
        public PluginBase PluginEntity
        {
            get
            {
                return _pluginEntity;
            }
            set
            {
                _pluginEntity = value;
            }
        }

        #endregion

        public object CreateObject(string className)
        {
            return null;
        }

        public static void InitializePlugin(PluginBase entity)
        {
            PluginTree.Instance.Plugins.Add(new Plugin() { PluginEntity = entity });
            PluginTree.Instance.SetupPluginTreeNode(new Plugin() { PluginEntity = entity });
        }

    }
}
