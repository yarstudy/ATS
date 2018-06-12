using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS_Task3.States;
using ATS_Task3.EventsArgs;

namespace ATS_Task3.AutomaticTelephoneSystem
{
    public class Terminal
    {
        public int Number { get; private set; }
        private Port TerminalPort { get; set; }
        private Guid Id { get; set; }
        public event EventHandler<EventOfCallArgs> EventOfCall;
        public event EventHandler<EventOfAnswerArgs> EventOfAnswer;
        public event EventHandler<EventOfEndCallArgs> EventOfEndCall;
        public Terminal(int number, Port port)
        {
            Number = number;
            TerminalPort = port;
        }
        public void ConnectToATS()
        {
            if (TerminalPort.Connect(this))
            {
                TerminalPort.PortCallEvent += TakeIncomingCall;
                TerminalPort.PortAnswerEvent += TakeAnswer;
            }
        }
        public void DisConnectToATS()
        {
            if (TerminalPort.Connect(this))
            {
                TerminalPort.PortCallEvent -= TakeIncomingCall;
                TerminalPort.PortAnswerEvent -= TakeAnswer;
            }
        }


        protected virtual void SafeEventOfCall(int targetNumber)
        {
            if (EventOfCall != null)
                EventOfCall(this, new EventOfCallArgs(Number, targetNumber));
        }
        public void Call(int targetNumber)
        {
            SafeEventOfCall(targetNumber);
        }


        protected virtual void SafeEventOfAnswer(int targetNumber, StateOfCall state, Guid id)
        {
            if (EventOfAnswer != null)
            {
                EventOfAnswer(this, new EventOfAnswerArgs(Number, targetNumber, state, id));
            }
        }
        public void Answer(int target, StateOfCall state, Guid id)
        {
            SafeEventOfAnswer(target, state, id);
        }


        protected virtual void SafeEventOfEndCall(Guid id)
        {
            if (EventOfEndCall != null)
                EventOfEndCall(this, new EventOfEndCallArgs(id, Number));
        }
        public void EndCall()
        {
            SafeEventOfEndCall(Id);
        }


        public void TakeIncomingCall(object sender, EventOfCallArgs e)
        {
            bool flag = true;
            Id = e.Id;
            Console.WriteLine("Have incoming Call at number: {0} to terminal {1}", e.Number, e.TargetNumber);
            while (flag == true)
            {
                Console.WriteLine("Answer? Y/N");
                char k = Console.ReadKey().KeyChar;
                if (k == 'Y' || k == 'y')
                {
                    flag = false;
                    Console.WriteLine();
                    AnswerToCall(e.Number, StateOfCall.Answer, e.Id);
                }
                else if (k == 'N' || k == 'n')
                {
                    flag = false;
                    Console.WriteLine();
                    EndCall();
                }
                else
                {
                    flag = true;
                    Console.WriteLine();
                }
            }
        }
        public void TakeAnswer(object sender, EventOfAnswerArgs e)
        {
            Id = e.Id;
            if (e.StateOfCall == StateOfCall.Answer)
            {
                Console.WriteLine("Terminal with number: {0}, have answer on call a number: {1}", e.Number, e.TargetNumber);
            }
            else
            {
                Console.WriteLine("Terminal with number: {0}, have rejected call", e.Number);
            }
        }
        public void AnswerToCall(int target, StateOfCall state, Guid id)
        {
            SafeEventOfAnswer(target, state, id);
        }
    }
}