using MWinNet.Dock;

namespace MWinNet.Frame
{
    public class DockPanelSingleton
    {
        private static DockPanel _singleton;
        public static DockPanel MainDockPanel
        {
            get
            {
                if (_singleton == null)
                {
                    _singleton = CreateDockPanel();
                }
                return _singleton;
            }
        }

        private static DockPanel CreateDockPanel()
        {
            DockPanel dockPanel = new DockPanel();
            dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            dockPanel.Location = new System.Drawing.Point(0, 65);
            dockPanel.Name = "dockPanel";
            dockPanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dockPanel.DocumentStyle = DocumentStyle.DockingMdi;
            return dockPanel;
        }
    }
}
