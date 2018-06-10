using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS_Task3.AutomaticTelephoneSystem;
using ATS_Task3.BillingSystem;
using ATS_Task3.States;

namespace ATS_Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Simple Test
            ATS ats = new ATS();
            Contract c1 = ats.SignContract(new Subscriber("George", "Bush"), TypeOfTariff.Mini);
            Contract c2 = ats.SignContract(new Subscriber("Barack", "Obama"), TypeOfTariff.Maxi);
            Contract c3 = ats.SignContract(new Subscriber("Donald", "Trump"), TypeOfTariff.Mini);
            Terminal t1 = ats.NewTerminal(c1);
            Terminal t2 = ats.NewTerminal(c2);
            Terminal t3 = ats.NewTerminal(c3);
            t1.ConnectToATS();
            t2.ConnectToATS();
            t3.ConnectToATS();
            t1.Call(t2.Number);
            t2.AnswerToCall(t1.Number, StateOfCall.Reject);
            t2.Call(t3.Number);
            t3.AnswerToCall(t2.Number, StateOfCall.Answer);
            t2.Call(t2.Number);
            t2.Call(43);
            Console.ReadKey();
        }
    }
}