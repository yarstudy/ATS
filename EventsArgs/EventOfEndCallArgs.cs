using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS_Task3.EventsArgs
{
    public class EventOfEndCallArgs : ICallEventArgs
    {
        public Guid Id { get; private set; }
        public int Number { get; private set; }
        public int TargetNumber { get; private set; }

        public EventOfEndCallArgs(Guid id, int number)
        {
            Id = id;
            Number = number;
        }
    }
}
