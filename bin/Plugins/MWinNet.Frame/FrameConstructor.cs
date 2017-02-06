using System.Collections.Generic;
using MWinNet.Core;
using MWinNet.Frame.UI;

namespace MWinNet.Frame
{
    public class FrameConstructor
    {
        private PluginTree _pluginTree = PluginTree.Instance;
        private MenuManage _menuManager = new MenuManage();
        private DockManage _dockManage = new DockManage();

        public void Initialize()
        {
            PluginManager.SetupPlugin();
            InitializeFrame();
            ConfigureFrame();
        }

        private void ConfigureFrame()
        {
            foreach (var plugin in _pluginTree.Plugins)
            {
                string curpath = plugin.PluginEntity.Path;
                //如果插件为MenuItem
                if (curpath.Contains(PluginConfig.MENUITEM))
                {
                    List<string> pathList = StringToolkit.PathParse(curpath);
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

        private void InitializeFrame()
        {
            WorkBenchUtil.AddControl(DockPanelInstance.Instance);
            WorkBenchUtil.AddControl(Menu.Instance.MainMenu);
        }
    }
}
