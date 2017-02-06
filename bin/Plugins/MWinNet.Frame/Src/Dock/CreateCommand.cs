using MWinNet.Core;

namespace MWinNet.Frame
{
    public class CreateCommand : Command
    {
        public override bool Enable()
        {
            return true;
        }

        public override void Run()
        {
            System.Windows.Forms.MessageBox.Show("Create!");
        }
    }
}
