using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS_Task3.States;
using ATS_Task3.EventsArgs;

namespace ATS_Task3
{
    public class EventOfAnswerArgs : ICallEventArgs
    {

        public int TargetNumber { get; private set; }
        public int Number { get; private set; }
        public StateOfCall StateOfCall {get; private set;}
        public Guid Id { get; private set; }

        public EventOfAnswerArgs(int number, int target, StateOfCall state, Guid id)
        {
            Number = number;
            TargetNumber = target;
            StateOfCall = state;
            Id = id;
        }
    }
}
