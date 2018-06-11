using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS_Task3.EventsArgs;

namespace ATS_Task3
{
    public class EventOfCallArgs : EventArgs, ICallEventArgs
    {
        public int TargetNumber { get; private set; }
        public int Number { get; private set; }
        public Guid Id { get; private set; }
        public EventOfCallArgs(int number, int target)
        {
            Number = number;
            TargetNumber = target;
        }
        public EventOfCallArgs(int number, int target, Guid id)
        {
            Number = number;
            TargetNumber = target;
            Id = id;
        }
    }
}
