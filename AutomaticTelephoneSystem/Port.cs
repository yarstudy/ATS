using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS_Task3.States;

namespace ATS_Task3.AutomaticTelephoneSystem
{

    public class Port
    {
        public StateOfPort State { get; private set; }
        private bool stateOfPort;
        public delegate void PortEventHandler(object sender, EventOfCallArgs e);
        public event PortEventHandler IncomingCallEvent;
        public delegate void PortAnswerEventHandler(object sender, EventofAnswerArgs e);
        public event PortAnswerEventHandler PortAnswerEvent;
        public delegate void CallEventHandler(object sender, EventOfCallArgs e);
        public event CallEventHandler CallEvent;
        public delegate void AnswerEventHandler(object sender, EventofAnswerArgs e);
        public event AnswerEventHandler AnswerEvent;

        public Port()
        {
            State = StateOfPort.Disconnect;
        }

        public bool Connect(Terminal terminal)
        {
            if (State == StateOfPort.Disconnect)
            {
                State = StateOfPort.Connect;
                terminal.CallEvent += CallingTo;
                terminal.AnswerEvent += AnswerTo;
                stateOfPort = true;
            }
            return stateOfPort;
        }

        public bool Disconnect(Terminal terminal)
        {
            if (State == StateOfPort.Connect)
            {
                State = StateOfPort.Disconnect;
                terminal.CallEvent -= CallingTo;
                terminal.AnswerEvent -= AnswerTo;
                stateOfPort = false;
            }
            return false;
        }
        protected virtual void SafeCallingToEvent(int number, int targetNumber)
        {
            if (CallEvent != null)
            {
                CallEvent(this, new EventOfCallArgs(number, targetNumber));
            }
        }
        protected virtual void SafeAnswerToEvent(int number, int targetNumber, StateOfCall state)
        {
            if (AnswerEvent != null)
            {
                AnswerEvent(this, new EventofAnswerArgs(number, targetNumber, state));
            }
        }


        private void CallingTo(object sender, EventOfCallArgs e)
        {
            SafeCallingToEvent(e.Number, e.TargetNumber);
        }
        private void AnswerTo(object sender, EventofAnswerArgs e)
        {
            SafeAnswerToEvent(e.Number, e.TargetNumber, e.StateOfCall);
        }


        private void SafeIncomingCallEvent(int number, int incomingNumber)
        {
            if (IncomingCallEvent != null)
                IncomingCallEvent(this, new EventOfCallArgs(number, incomingNumber));
        }
        private void SafeIncomingCallEvent(int number, int incomingNumber, Guid id)
        {
            if (IncomingCallEvent != null)
                IncomingCallEvent(this, new EventOfCallArgs(number, incomingNumber));
        }
        public void IncomingCall(int number, int incomingNumber)
        {
            SafeIncomingCallEvent(number, incomingNumber);
        }
        public void IncomingCall(int number, int incomingNumber, Guid id)
        {
            SafeIncomingCallEvent(number, incomingNumber, id);
        }



        private void SafeAnswerCallEvent(int number, int outgoingNumber, StateOfCall state)
        {
            if (PortAnswerEvent != null)
                PortAnswerEvent(this, new EventofAnswerArgs(number, outgoingNumber, state));
        }
        private void SafeAnswerCallEvent(int number, int outgoingNumber, StateOfCall state, Guid id)
        {
            if (PortAnswerEvent != null)
                PortAnswerEvent(this, new EventofAnswerArgs(number, outgoingNumber, state));
        }
        public void AnswerCall(int number, int outgoingNumber, StateOfCall state)
        {
            SafeAnswerCallEvent(number, outgoingNumber, state);
        }
        public void AnswerCall(int number, int targetNumber, StateOfCall state, Guid id)
        {
            SafeAnswerCallEvent(number, targetNumber, state, id);
        }
    }
}