using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWinNet.Frame
{
    public class WorkBenchInstance
    {
        private static WorkBench _instance;
        public static WorkBench Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new WorkBench();
                }
                return _instance;
            }
        }
    }
}
