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
        public delegate void CallEventHandler(object sender, EventOfCallArgs e);
        public event CallEventHandler CallEvent;
        public delegate void AnswerEventHandler(object sender, EventofAnswerArgs e);
        public event AnswerEventHandler AnswerEvent;
        public Terminal(int number, Port port)
        {
            Number = number;
            TerminalPort = port;
        }
        protected virtual void SafeCallEvent(int targetNumber)
        {
            if (CallEvent != null)
                CallEvent(this, new EventOfCallArgs(Number, targetNumber));
        }

        protected virtual void SafeAnswerEvent(int incomingNumber, StateOfCall state)
        {
            if (AnswerEvent != null)
                AnswerEvent(this, new EventofAnswerArgs(incomingNumber, Number, state));
        }

        public void Call(int targetNumber)
        {
            SafeCallEvent(targetNumber);
        }

        public void TakeIncomingCall(object sender, EventOfCallArgs e)
        {
            Console.WriteLine("Have incoming Call at number: {0} to terminal {1}", e.Number, e.TargetNumber);
        }

        public void ConnectToATS()
        {
            TerminalPort.Connect(this);
        }

        public void AnswerToCall(int incomingNumber, StateOfCall state)
        {
            SafeAnswerEvent(incomingNumber, state);
        }

        public void RejectIncomingCall()
        {

        }

        public void TakeAnswer(object sender, EventofAnswerArgs e)
        {
            Console.WriteLine("He answered!!!");
            if (e.StateOfCall == StateOfCall.Answer)
            {
                Console.WriteLine("Terminal {0} have answered on call from terminal {1}", e.TargetNumber, e.Number);
            }
            else
            {
                Console.WriteLine("Terminal {0} have rejected call from terminal {1}", e.TargetNumber, e.Number);
            }
        }

    }
}