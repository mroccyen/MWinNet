using MWinNet.Core;
using System.Collections.Generic;

namespace MWinNet.Frame
{
    public class MenuManage
    {
        private MenuItemContainer _container = new MenuItemContainer();
        private MenuItemFactory _menuFactory = new MenuItemFactory();

        public void ConfigureMenuItem(List<string> paths, Plugin plugin)
        {
            paths.Remove(PluginConfig.MENUITEM);
            MenuItem curItem = null;

            for (int i = 0; i < paths.Count; i++)
            {
                MenuItem existItem = _container.CheckItem(paths[i], i);
                if (existItem == null)
                {
                    if (i == paths.Count - 1)
                    {
                        curItem = _menuFactory.GetMenuItem(plugin.PluginEntity as MenuPlugin);
                    }
                    else
                    {
                        curItem = _menuFactory.GetMenuItem(CommonToolkit.GetLastString(paths[i]));
                    }
                    _container.AddItem(curItem, paths[i], i);
                }
                else
                {
                    curItem = existItem;
                }
                if (i != 0)
                {
                    MenuItem parentTopItem = _container.CheckItem(paths[i - 1], i - 1);
                    parentTopItem.AddMenuItemRange(new System.Windows.Forms.ToolStripItem[] { curItem });
                }
            }
        }

        public void SetupMenuItem()
        {
            Menu.Instance.AddItemRange(_container.MenuContainer[0].ToArray());
        }
    }
}
