using MWinNet.Frame.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWinNet.Frame
{
    public class MenuItemContainer
    {
        private List<List<MenuItem>> _menuContainer = new List<List<MenuItem>>();

        /// <summary>
        /// 菜单容器
        /// </summary>
        public List<List<MenuItem>> MenuContainer
        {
            get { return _menuContainer; }
        }

        public void AddItem(MenuItem item, string path, int index)
        {
            item.Tag = path;
            _menuContainer[index].Add(item);
        }

        public MenuItem CheckItem(string path, int index)
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

    }
}
