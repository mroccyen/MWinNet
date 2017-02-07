using System.Collections.Generic;
using MWinNet.Core;

namespace MWinNet.Frame
{
    public class ApplicationConstructor
    {
        private PluginTree _pluginTree = PluginTree.Instance;
        private MenuManage _menuManager = new MenuManage();
        private DockManage _dockManage = new DockManage();

        public void Initialize()
        {
            PluginManager.SetupPlugin();
            InitializeFrame();
        }

        private void InitializeFrame()
        {
            ConfigureFrame();
            foreach (var plugin in _pluginTree.Plugins)
            {
                string curpath = plugin.PluginEntity.Path;
                //如果插件为MenuItem
                if (curpath.Contains(PluginConfig.MENUITEM))
                {
                    List<string> pathList = CommonToolkit.PathParse(curpath);
                    _menuManager.ConfigureMenuItem(pathList, plugin);
                }
                //如果插件为DockBar
                if (curpath.Contains(PluginConfig.DOCKBAR))
                {
                    _dockManage.SetupDockBar(plugin);
                }
            }
            //初始化菜单
            _menuManager.SetupMenuItem();
        }

        private void ConfigureFrame()
        {
            WorkBenchInstance.Instance.AddControl(DockPanelInstance.Instance);
            WorkBenchInstance.Instance.AddControl(Menu.Instance.MainMenu);
        }
    }
}
