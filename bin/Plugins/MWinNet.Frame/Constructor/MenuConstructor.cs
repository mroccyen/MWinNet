using MWinNet.Core;
using MWinNet.Frame.UI;
using System.Collections.Generic;

namespace MWinNet.Frame
{
    public class MenuConstructor
    {
        /// <summary>
        /// 菜单容器
        /// </summary>
        private List<List<MenuItem>> _menuContainer = new List<List<MenuItem>>();

        public void ConfigureMenuItem(List<string> paths, Plugin plugin)
        {
            paths.Remove(PluginConfig.MENUITEM);
            MenuItem curItem = null;

            for (int i = 0; i < paths.Count; i++)
            {
                MenuItem existTopItem = CheckItem(paths[i], i);
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
                    AddItemToContainer(curItem, paths[i], i);
                }
                else
                {
                    curItem = existTopItem;
                }
                if (i != 0)
                {
                    MenuItem parentTopItem = CheckItem(paths[i - 1], i - 1);
                    parentTopItem.AddMenuItemRange(new System.Windows.Forms.ToolStripItem[] { curItem });
                }
            }
        }

        public void SetupMenuItem()
        {
            Menu.Instance.AddItemRange(_menuContainer[0].ToArray());
        }

        private MenuItem CheckItem(string path, int index)
        {
            MenuItem checkItem = null;
            if (index > _menuContainer.Count - 1)
            {
                _menuContainer.Add(new List<MenuItem>());
            }
            foreach (var item in _menuContainer[index])
            {
                if ((item.Tag as string).Equals(path))
                {
                    checkItem = item;
                    break;
                }
            }
            return checkItem;
        }

        /// <summary>
        /// 添加菜单到菜单容器
        /// </summary>
        /// <param name="topPath"></param>
        private void AddItemToContainer(MenuItem item, string path, int index)
        {
            item.Tag = path;
            _menuContainer[index].Add(item);
        }
    }
}
