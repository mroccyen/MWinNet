using System.ComponentModel;

namespace MWinNet.Dock
{
    public abstract class ThemeBase : Component, ITheme
    {
        public DockPanelSkin Skin { get; protected set; }

        public abstract void Apply(DockPanel dockPanel);
    }
}
