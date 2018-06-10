using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS_Task3.AutomaticTelephoneSystem
{
    public class CallInfo
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public int TargetNumber { get; set; }
        public DateTime Date { get; set; }
        public int Cost { get; set; }

        public CallInfo()
        {
            Id = Guid.NewGuid();
        }

        public CallInfo(Guid id)
        {
            Id = id;
        }
    }
}
