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
        public DateTime StartOfCall { get; set; }
        public DateTime EndOfCall { get; set; }
        public int CostOfCall { get; set; }

        public CallInfo(int number, int targetNumber, DateTime startOfCall)
        {
            Id = Guid.NewGuid();
            Number = number;
            TargetNumber = targetNumber;
            StartOfCall = startOfCall;
        }
    }
}
