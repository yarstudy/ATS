using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.States;

namespace ATS
{
    public class EventofAnswerArgs : EventArgs
    {

        public int TargetNumber { get; private set; }
        public int Number { get; private set; }
        public StateOfCall StateOfCall {get; private set;}
        public EventofAnswerArgs(int number, int target, StateOfCall state)
        {
            Number = number;
            TargetNumber = target;
            StateOfCall = state;
        }
    }
}
