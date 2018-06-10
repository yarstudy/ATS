using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.States;

namespace ATS
{
    public class Terminal
    {
        public int Number { get; private set; }
        private Port TerminalPort { get; set; }
        public delegate void CallEventHandler(object sender, EventOfCall e);
        public event CallEventHandler CallEvent;
        public delegate void AnswerEventHandler(object sender, EventofAnswer e);
        public event AnswerEventHandler AnswerEvent;
        public Terminal(int number, Port port)
        {
            Number = number;
            TerminalPort = port;
        }
        protected virtual void SafeCallEvent(int number)
        {
            if (CallEvent != null)
                CallEvent(this, new EventOfCall(Number, number));
        }

        protected virtual void RaiseAnswerEvent(int number, StateOfCall state)
        {
            if (AnswerEvent != null)
                AnswerEvent(this, new EventofAnswer(Number, number, state));
        }

        public void Call(int number)
        {
            SafeCallEvent(number);
        }

        public void TakeIncomingCall(object sender, EventOfCall e)
        {
            Console.WriteLine("He is calling!");
            AnswerToCall(e.Number, StateOfCall.Answer);
        }

        public void ConnectToPort()
        {
            TerminalPort.Connect(this);
        }

        public void AnswerToCall(int number, StateOfCall state)
        {
            RaiseAnswerEvent(number, state);
        }

        public void RejectIncomingCall()
        {

        }

        public void TakeAnswer(object sender, EventofAnswer e)
        {
            Console.WriteLine("He answered!!!");
        }

    }
}