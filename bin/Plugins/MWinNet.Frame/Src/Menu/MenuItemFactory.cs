using MWinNet.Core;
using System.Linq;

namespace MWinNet.Frame
{
    public class MenuItemFactory
    {
        public MenuItem GetMenuItem(MenuPlugin menuPlugin)
        {
            MenuItem item = null;
            if (menuPlugin.AssemblyName != string.Empty && menuPlugin.AssemblyName != null
                && menuPlugin.ClassName != string.Empty && menuPlugin.ClassName != null)
            {
                string assemblyPath = AssemblyInstance.GetDll(menuPlugin.AssemblyName);
                Command cmd = AssemblyInstance.ActivateObject<Command>(assemblyPath, menuPlugin.ClassName);
                item = new MenuItem(cmd);
            }
            else
            {
                item = new MenuItem(null);
            }
            if (menuPlugin.Image != string.Empty && menuPlugin.Image != null)
            {
                string imagePath = CommonToolkit.GetResourceDirectory(menuPlugin.Image);
                item.Image = CommonToolkit.GetResourceImage(imagePath);
            }
            item.Text = (menuPlugin.Caption.Equals(string.Empty) || menuPlugin.Caption.Equals(null)) ? CommonToolkit.GetLastString(menuPlugin.Path) : menuPlugin.Caption;
            return item;
        }

        public MenuItem GetMenuItem(string caption)
        {
            MenuItem item = new MenuItem(null);
            item.Text = caption;
            return item;
        }
    }
}
