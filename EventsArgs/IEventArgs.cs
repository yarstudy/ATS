using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS_Task3.EventsArgs
{
    public interface IEventArgs
    {
        int Number { get; }
        int TargetNumber { get; }
        Guid Id { get; }
    }
}
