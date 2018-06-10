﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.States;

namespace ATS
{

    public class Port
    {
        public StateOfPort State;
        private ATS ats;
        private bool stateOfPort;
        public delegate void PortEventHandler(object sender, EventOfCallArgs e);
        public event PortEventHandler IncomingCallEvent;
        public delegate void PortAnswerEventHandler(object sender, EventofAnswerArgs e);
        public event PortAnswerEventHandler PortAnswerEvent;

        public Port(ATS ats)
        {
            State = StateOfPort.Disconnect;
            this.ats = ats;
        }
        public Port()
        {
            State = StateOfPort.Disconnect;
        }

        public bool Connect(Terminal terminal)
        {
            if (State == StateOfPort.Disconnect)
            {
                State = StateOfPort.Connect;
                terminal.CallEvent += ats.Calling;
                IncomingCallEvent += terminal.TakeIncomingCall;
                terminal.AnswerEvent += ats.Answer;
                PortAnswerEvent += terminal.TakeAnswer;
                stateOfPort = true;
            }
            return stateOfPort;
        }

        public bool Disconnect(Terminal terminal)
        {
            if (State == StateOfPort.Connect)
            {
                State = StateOfPort.Disconnect;
                terminal.CallEvent -= ats.Calling;
                IncomingCallEvent -= terminal.TakeIncomingCall;
                stateOfPort = false;
            }
            return false;
        }

        private void SafeIncomingCallEvent(int number, int incomingNumber)
        {
            if (IncomingCallEvent != null)
            IncomingCallEvent(this, new EventOfCallArgs(number, incomingNumber)); 
        }
        private void SafeAnswerCallEvent(int number, int outgoingNumber, StateOfCall state)
        {
            if (PortAnswerEvent != null)
                PortAnswerEvent(this, new EventofAnswerArgs(number, outgoingNumber, state));
        }

        public void IncomingCall(int number, int incomingNumber)
        {
            SafeIncomingCallEvent(number, incomingNumber);
        }

        public void AnswerCall(int number, int outgoingNumber, StateOfCall state)
        {
            SafeAnswerCallEvent(number, outgoingNumber, state);
        }
    }
}