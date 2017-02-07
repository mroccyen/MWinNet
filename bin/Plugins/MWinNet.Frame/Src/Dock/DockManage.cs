using MWinNet.Core;
using MWinNet.Dock;
using System;

namespace MWinNet.Frame
{
    public class DockManage
    {
        public DockState GetDockState(string stateString)
        {
            DockState state = DockState.Document;
            switch (stateString)
            {
                case "Float":
                    state = DockState.Float;
                    break;
                case "DockTopAutoHide":
                    state = DockState.DockTopAutoHide;
                    break;
                case "DockLeftAutoHide":
                    state = DockState.DockLeftAutoHide;
                    break;
                case "DockBottomAutoHide":
                    state = DockState.DockBottomAutoHide;
                    break;
                case "DockRightAutoHide":
                    state = DockState.DockRightAutoHide;
                    break;
                case "Document":
                    state = DockState.Document;
                    break;
                case "DockTop":
                    state = DockState.DockTop;
                    break;
                case "DockLeft":
                    state = DockState.DockLeft;
                    break;
                case "DockBottom":
                    state = DockState.DockBottom;
                    break;
                case "DockRight":
                    state = DockState.DockRight;
                    break;
                default:
                    throw new Exception("参数不正确，找不到合适的DockState！");
            }
            return state;
        }

        public void SetupDockBar(Plugin plugin)
        {
            DockBarPlugin dockPlugin = plugin.PluginEntity as DockBarPlugin;
            if (dockPlugin == null)
            {
                throw new NullReferenceException();
            }
            DockState state = GetDockState(dockPlugin.DockType);
            string assemblyPath = AssemblyInstance.GetDll(plugin.PluginEntity.AssemblyName);
            ToolWindow window = AssemblyInstance.ActivateObject<ToolWindow>(assemblyPath, dockPlugin.DockWindowClass);
            window.Show(DockPanelInstance.Instance, state);
        }
    }
}
