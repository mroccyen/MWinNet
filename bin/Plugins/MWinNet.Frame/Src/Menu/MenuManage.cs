using MWinNet.Core;
using System.Collections.Generic;

namespace MWinNet.Frame
{
    public class MenuManage
    {
        private MenuItemContainer _container = new MenuItemContainer();

        public void ConfigureMenuItem(List<string> paths, Plugin plugin)
        {
            paths.Remove(PluginConfig.MENUITEM);
            MenuItem curItem = null;

            for (int i = 0; i < paths.Count; i++)
            {
                MenuItem existTopItem = _container.CheckItem(paths[i], i);
                if (existTopItem == null)
                {
                    if (i == paths.Count - 1)
                    {
                        if (plugin.PluginEntity.AssemblyName != null && plugin.PluginEntity.ClassName != null)
                        {
                            string assemblyPath = AssemblyUtil.GetDll(plugin.PluginEntity.AssemblyName);
                            Command cmd = AssemblyUtil.GetAssembly<Command>(assemblyPath, plugin.PluginEntity.ClassName);
                            curItem = new MenuItem(cmd, (plugin.PluginEntity as MenuPlugin).Caption);
                        }
                        else
                        {
                            curItem = new MenuItem(StringToolkit.GetLastString((plugin.PluginEntity as MenuPlugin).Caption));
                        }
                    }
                    else
                    {
                        curItem = new MenuItem(StringToolkit.GetLastString(paths[i]));
                    }
                    _container.AddItem(curItem, paths[i], i);
                }
                else
                {
                    curItem = existTopItem;
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
