using MWinNet.Core;
using System.Linq;

namespace MWinNet.Frame
{
    public class MenuItemFactory
    {
        public MenuItem GetMenuItem(MenuPlugin menuEntity)
        {
            MenuItem item = null;
            if (menuEntity.AssemblyName != string.Empty && menuEntity.AssemblyName != null
                && menuEntity.ClassName != string.Empty && menuEntity.ClassName != null)
            {
                string assemblyPath = AssemblyInstance.GetDll(menuEntity.AssemblyName);
                Command cmd = AssemblyInstance.ActivateObject<Command>(assemblyPath, menuEntity.ClassName);
                item = new MenuItem(cmd);
            }
            else
            {
                item = new MenuItem(null);
            }
            if (menuEntity.Image != string.Empty && menuEntity.Image != null)
            {
                string imagePath = CommonToolkit.GetResourceDirectory(menuEntity.Image);
                item.Image = CommonToolkit.GetResourceImage(imagePath);
            }
            item.Text = (menuEntity.Caption.Equals(string.Empty) || menuEntity.Caption.Equals(null)) ? CommonToolkit.GetLastString(menuEntity.Path) : menuEntity.Caption;
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
