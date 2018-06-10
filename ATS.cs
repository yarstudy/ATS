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

        public Terminal NewTerminal()
        {
            var number = random.Next(1, 9);
            numbers.Add(number);
            var newPort = new Port(this);
            ports.Add(newPort);
            var newTerminal = new Terminal(number, newPort);
            return newTerminal;
        }

        public void Calling(object sender, EventOfCall e)
        {
            if (numbers.Contains(e.TargetNumber))
            {
                int index = numbers.IndexOf(e.TargetNumber);
                if (ports[index].State == States.StateOfPort.Connect)
                {
                    ports[index].IncomingCall(e.Number);
                }
            }
        }

        public void Answer(object sender, EventofAnswer e)
        {
            if (numbers.Contains(e.Number))
            {
                var index = numbers.IndexOf(e.Number);
                if (ports[index].State == States.StateOfPort.Connect)
                {
                    ports[index].AnswerCall(e.Number, e.StateInCall);
                }
            }
        }
    }
}