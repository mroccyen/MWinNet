using MWinNet.Core;
using MWinNet.Frame;

namespace MWinNet.MainFrame
{
    public class CreateCommand : Command
    {
        public override bool Enable()
        {
            return true;
        }

        public override void Run()
        {
            //System.Windows.Forms.MessageBox.Show("Create!");
            System.Windows.Forms.MessageBox.Show(FrameApplication.ActiveApplication.ActiveMidWindow.Name);
            //FrameApplication.ActiveApplication.ActiveMidWindowChanged += ActiveApplication_ActiveMidWindowChanged;
        }

        private void ActiveApplication_ActiveMidWindowChanged(object sender, System.EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Changed!");
        }
    }
}
