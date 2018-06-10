using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.States;

namespace ATS
{
    public class EventofAnswer : EventArgs
    {

        public int TargetNumber { get; private set; }
        public int Number { get; private set; }
        public StateOfCall StateInCall {get; private set;}
        public EventofAnswer(int number, int target, StateOfCall state)
        {
            Number = number;
            TargetNumber = target;
            StateInCall = state;
        }
    }
}
