using MWinNet.Dock;

namespace MWinNet.Frame.UI
{
    public class DockPanelInstance
    {
        private static DockPanel _instance;
        public static DockPanel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = CreateDockPanel();
                }
                return _instance;
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
