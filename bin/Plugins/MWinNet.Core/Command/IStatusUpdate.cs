using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWinNet.Core
{
    public interface IStatusUpdate
    {
        void UpdateStatus();
        void UpdateText();
    }
}
