using System.Collections.Generic;
using MWinNet.Core;
using MWinNet.Frame.UI;

namespace MWinNet.Frame
{
    public class FrameConstructor
    {
        private PluginTree _pluginTree = PluginTree.Instance;
        private MenuConstructor _menuCreator = new MenuConstructor();
        private DockPanelConstructor _dockConstructor = new DockPanelConstructor();

        public void Initialize()
        {
            var dockPanel = _dockConstructor.CreateDockPanel();
            WorkBenchUtil.AddControl(dockPanel);
            DockWindowLeft form1 = new DockWindowLeft();
            form1.Show(dockPanel);

            PluginManager.SetupPlugin();
            ConfigureFrame();
            InitializeFrame();
        }

        private void ConfigureFrame()
        {
            foreach (var plugin in PluginTree.Instance.Plugins)
            {
                string curpath = plugin.PluginEntity.Path;
                //如果插件为MenuItem
                if (curpath.Contains(PluginConfig.MENUITEM))
                {
                    List<string> pathList = StringToolkit.PathParse(curpath);
                    _menuCreator.ConfigureMenuItem(pathList, plugin);
                }
            }
        }

        private void InitializeFrame()
        {
            _menuCreator.SetupMenuItem();
            WorkBenchUtil.AddControl(Menu.Instance.MainMenu);
            //WorkBenchUtil.AddControl(_dockConstructor.CreateDockPanel());
        }
    }
}
