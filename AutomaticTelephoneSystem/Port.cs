using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS_Task3.States;
using ATS_Task3.EventsArgs;

namespace ATS_Task3.AutomaticTelephoneSystem
{

    public class Port
    {
        public StateOfPort State { get; set; }
        private bool stateOfPort;

        //public delegate void PortEventHandler(object sender, EventOfCallArgs e);
        //public event PortEventHandler PortCallEvent;
        //public delegate void PortAnswerEventHandler(object sender, EventOfAnswerArgs e);
        //public event PortAnswerEventHandler PortAnswerEvent;
        //public delegate void CallEventHandler(object sender, EventOfCallArgs e);
        //public event CallEventHandler CallEvent;
        //public delegate void AnswerEventHandler(object sender, EventOfAnswerArgs e);
        //public event AnswerEventHandler AnswerEvent;
        //public delegate void EndOfCallEventHandler(object sender, EventOfEndCallArgs e);
        //public event EndOfCallEventHandler EndCallEvent;
        public event EventHandler<EventOfCallArgs> PortCallEvent;
        public event EventHandler<EventOfAnswerArgs> PortAnswerEvent;
        public event EventHandler<EventOfCallArgs> CallEvent;
        public event EventHandler<EventOfAnswerArgs> AnswerEvent;
        public event EventHandler<EventOfEndCallArgs> EndCallEvent;

        public Port()
        {
            State = StateOfPort.Disconnect;
        }

        public bool Connect(Terminal terminal)
        {
            if (State == StateOfPort.Disconnect)
            {
                State = StateOfPort.Connect;
                terminal.EventOfCall += CallingTo;
                terminal.EventOfAnswer += AnswerTo;
                terminal.EventOfEndCall += EndCall;
                stateOfPort = true;
            }
            return stateOfPort;
        }

        public bool Disconnect(Terminal terminal)
        {
            if (State == StateOfPort.Connect)
            {
                State = StateOfPort.Disconnect;
                terminal.EventOfCall -= CallingTo;
                terminal.EventOfAnswer -= AnswerTo;
                terminal.EventOfEndCall -= EndCall;
                stateOfPort = false;
            }
            return false;
        }


        private void SafeIncomingCallEvent(int number, int target)
        {
            if (PortCallEvent != null)
                PortCallEvent(this, new EventOfCallArgs(number, target));
        }
        private void SafeIncomingCallEvent(int number, int target, Guid id)
        {
            if (PortCallEvent != null)
                PortCallEvent(this, new EventOfCallArgs(number, target));
        }
        public void IncomingCall(int number, int target)
        {
            SafeIncomingCallEvent(number, target);
        }
        public void IncomingCall(int number, int target, Guid id)
        {
            SafeIncomingCallEvent(number, target, id);
        }


        private void SafeAnswerCallEvent(int number, int target, StateOfCall state)
        {
            if (PortAnswerEvent != null)
                PortAnswerEvent(this, new EventOfAnswerArgs(number, target, state));
        }
        private void SafeAnswerCallEvent(int number, int target, StateOfCall state, Guid id)
        {
            if (PortAnswerEvent != null)
                PortAnswerEvent(this, new EventOfAnswerArgs(number, target, state));
        }
        public void AnswerCall(int number, int target, StateOfCall state)
        {
            SafeAnswerCallEvent(number, target, state);
        }
        public void AnswerCall(int number, int target, StateOfCall state, Guid id)
        {
            SafeAnswerCallEvent(number, target, state, id);
        }


        protected virtual void SafeCallingToEvent(int number, int targetNumber)
        {
            if (CallEvent != null)
            {
                CallEvent(this, new EventOfCallArgs(number, targetNumber));
            }
        }
        private void CallingTo(object sender, EventOfCallArgs e)
        {
            SafeCallingToEvent(e.Number, e.TargetNumber);
        }


        protected virtual void SafeAnswerToEvent(EventOfAnswerArgs eventArgs)
        {
            if (AnswerEvent != null)
            {
                AnswerEvent(this, new EventOfAnswerArgs(eventArgs.Number, eventArgs.TargetNumber, eventArgs.StateOfCall, eventArgs.Id));
            }
        }
        private void AnswerTo(object sender, EventOfAnswerArgs e)
        {
            SafeAnswerToEvent(e);
        }


        protected virtual void SafeEndCallEvent(Guid id, int number)
        {
            if (EndCallEvent != null)
            {
                EndCallEvent(this, new EventOfEndCallArgs(id, number));
            }
        }
        private void EndCall(object sender, EventOfEndCallArgs e)
        {
            SafeEndCallEvent(e.Id, e.Number);
        }
    }
}