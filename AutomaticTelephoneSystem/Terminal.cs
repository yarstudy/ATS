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
        public void DisConnectFromATS()
        {
            if (!TerminalPort.Connect(this))
            {
                TerminalPort.PortCallEvent -= TakeIncomingCall;
                TerminalPort.PortAnswerEvent -= TakeAnswer;
            }
        }
        public void Call(int targetNumber)
        {
            if (EventOfCall != null)
            {
                EventOfCall(this, new EventOfCallArgs(Number, targetNumber, Id));
            }
        }
        public void AnswerToCall(int target, StateOfCall state, Guid id)
        {
            if (EventOfAnswer != null)
            {
                EventOfAnswer(this, new EventOfAnswerArgs(Number, target, state, id));
            }
        }
        public void EndCall()
        {
            if (EventOfEndCall != null)
            {
                EventOfEndCall(this, new EventOfEndCallArgs(Id, Number));
            }
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
    }
}