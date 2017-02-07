using System.Drawing;

namespace MWinNet.Core
{
    public partial class CommonToolkit
    {
        public static Image GetResourceImage(string imgPath)
        {
            return Image.FromFile(imgPath);
        }
    }
}
