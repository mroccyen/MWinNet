using MWinNet.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWinNet.Frame
{
    public class ToolBarButtonSetup
    {
        public void Setup(Plugin plugin)
        {
            ToolBarButton toolButton = null;
            ToolBarButtonPlugin toolPlugin = plugin.PluginBase as ToolBarButtonPlugin;
            if (toolPlugin.AssemblyName != string.Empty
                && toolPlugin.AssemblyName != null
                && toolPlugin.ClassName != string.Empty
                && toolPlugin.ClassName != null)
            {
                string assemblyPath = AssemblyToolkit.GetDll(toolPlugin.AssemblyName);
                Command cmd = AssemblyToolkit.ActivateObject<Command>(assemblyPath, toolPlugin.ClassName);
                toolButton = new ToolBarButton(cmd);
            }
            else
            {
                toolButton = new ToolBarButton(null);
            }
            if (toolPlugin.Image != string.Empty && toolPlugin.Image != null)
            {
                string imagePath = CommonToolkit.GetResourceDirectory(toolPlugin.Image);
                toolButton.Image = CommonToolkit.GetResourceImage(imagePath);
            }
            toolButton.DisplayStyle = ToolBarToolkit.GetDisplayStyle(toolPlugin.DisplayStyle);
            toolButton.Text = (toolPlugin.Label.Equals(string.Empty) || toolPlugin.Label.Equals(null)) ? "无" : toolPlugin.Label;

            ToolBarSingleton.MainToolbar.Add(toolButton);
        }
    }
}
