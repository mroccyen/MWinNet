using System.Collections.Generic;
using MWinNet.Core;

namespace MWinNet.Frame
{
    public class ApplicationSetup
    {
        private PluginTree _pluginTree = PluginTree.Singleton;
        private MenuManage _menuManager = new MenuManage();
        private DockManager _dockManage = new DockManager();
        private ToolBarButtonSetup _toolbarButtonSetup = new ToolBarButtonSetup();
        private ToolBarSeparatorSetup _toolBarSeparatorSetup = new ToolBarSeparatorSetup();

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
                string curpath = plugin.PluginBase.Path;
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
                //如果插件为ToolBar
                if (curpath.Contains(PluginConfig.TOOLBAR))
                {
                    InitializeToolBar(plugin);
                }
                //如果插件为StatusBar
                if (curpath.Contains(PluginConfig.STATUSBAR))
                {
                    InitializeStatusBar(plugin);
                }
            }
            //初始化菜单
            _menuManager.SetupMenuItem();
        }

        private void InitializeStatusBar(Plugin plugin)
        {
            string path = plugin.PluginBase.Path;
            if (path.Contains(PluginConfig.STATUSBARPROGRESSBAR))
            {

            }
        }

        private void InitializeToolBar(Plugin plugin)
        {
            string path = plugin.PluginBase.Path;
            if (path.Contains(PluginConfig.TOOLBARBUTTON))
            {
                _toolbarButtonSetup.Setup(plugin);
            }
            if (path.Contains(PluginConfig.TOOLBARSEPARASTOR))
            {
                _toolBarSeparatorSetup.Setup(plugin);
            }
            if (path.Contains(PluginConfig.TOOLBARCOMBOBOX))
            {

            }
        }

        private void ConfigureFrame()
        {
            WorkBenchSingleton.Singleton.AddControl(DockPanelSingleton.MainDockPanel);
            WorkBenchSingleton.Singleton.AddControl(ToolBarSingleton.MainToolbar);
            WorkBenchSingleton.Singleton.AddControl(Menu.Singleton.MainMenu);
        }
    }
}
