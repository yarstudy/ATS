using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS
{
    public class ATS
    {
        private IList<Port> ports;
        private IList<int> numbers;
        Random random;
        public ATS()
        {
            ports = new List<Port>();
            numbers = new List<int>();
            random = new Random();
        }

        public Terminal NewTerminal(int number)
        {
            numbers.Add(number);
            var newPort = new Port(this);
            ports.Add(newPort);
            var newTerminal = new Terminal(number, newPort);
            return newTerminal;
        }

        public void Calling(object sender, EventOfCallArgs e)
        {
            if (numbers.Contains(e.TargetNumber) && (e.TargetNumber != e.Number))
            {
                int index = numbers.IndexOf(e.TargetNumber);
                if (ports[index].State == States.StateOfPort.Connect)
                {
                    ports[index].IncomingCall(e.Number, e.TargetNumber);
                }
            }
            else if (!numbers.Contains(e.TargetNumber))
            {
                Console.WriteLine("Trying to call a non-existent number".ToUpper());
            }
            else
            {
                Console.WriteLine("Trying to call your own number".ToUpper());
            }
        }

        public void Answer(object sender, EventofAnswerArgs e)
        {
            if (numbers.Contains(e.Number))
            {
                int index = numbers.IndexOf(e.Number);
                if (ports[index].State == States.StateOfPort.Connect)
                {
                    ports[index].AnswerCall(e.TargetNumber,e.Number, e.StateOfCall);
                }
            }
        }
    }
}