using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS
{
    class Program
    {
        static void Main(string[] args)
        {
            //Simple Test
            ATS ats = new ATS();
            Contract c1 = new Contract("Bush", 43, States.TypeOfTariff.Mini, ats);
            Contract c2 = new Contract("Obama", 44, States.TypeOfTariff.Mini, ats);
            Contract c3 = new Contract("Trump", 45, States.TypeOfTariff.Mini, ats);
            Terminal t1 = c1.ToSignContract();
            Terminal t2 = c2.ToSignContract();
            Terminal t3 = c3.ToSignContract();
            t1.ConnectToATS();
            t2.ConnectToATS();
            t3.ConnectToATS();
            t1.Call(t2.Number);
            t2.AnswerToCall(t1.Number, States.StateOfCall.Reject);
            t2.Call(t3.Number);
            t3.AnswerToCall(t2.Number, States.StateOfCall.Answer);
            t2.Call(t2.Number);
            t2.Call(43);
            Console.ReadKey();
        }
    }
}