using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS
{
    public class EventOfCallArgs : EventArgs
    {
        public int TargetNumber { get; private set; }
        public int Number { get; private set; }
        public EventOfCallArgs(int number, int target)
        {
            Number = number;
            TargetNumber = target;
        }
    }
}
