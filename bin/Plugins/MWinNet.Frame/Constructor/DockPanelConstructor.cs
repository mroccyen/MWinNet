using MWinNet.Dock;

namespace MWinNet.Frame
{
    public class DockPanelConstructor
    {
        public DockPanel CreateDockPanel()
        {
            DockPanel dockPanel = new DockPanel();
            // 
            // dockPanel
            // 
            dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            dockPanel.Location = new System.Drawing.Point(0, 65);
            dockPanel.Name = "dockPanel";
            dockPanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;

            return dockPanel;
        }

    }
}
