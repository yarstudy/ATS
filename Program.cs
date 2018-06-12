using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            IATS ats = new ATS();
            IReportCompiler compiler = new ReportCompiler();
            IBillSyst bs = new BillSyst(ats);

            IContract c1 = ats.SignContract(new Subscriber("George", "Bush"), TypeOfTariff.Mini);
            IContract c2 = ats.SignContract(new Subscriber("Barack", "Obama"), TypeOfTariff.Maxi);
            IContract c3 = ats.SignContract(new Subscriber("Donald", "Trump"), TypeOfTariff.Mini);

            c1.Subscriber.PutMoney(5000);
            c1.Subscriber.WithdrawMoney(30);
            Terminal t1 = ats.NewTerminal(c1);
            Terminal t2 = ats.NewTerminal(c2);
            Terminal t3 = ats.NewTerminal(c3);
            t1.ConnectToATS();
            t2.ConnectToATS();
            t3.ConnectToATS();
            t1.Call(t2.Number);
            Thread.Sleep(1111);
            t2.EndCall();
            t3.Call(t1.Number);
            Thread.Sleep(2222);
            t3.EndCall();
            t2.Call(t1.Number);
            Thread.Sleep(3333);
            t1.EndCall();

            Console.WriteLine("\nLog:\n");
            foreach (var item in compiler.SortCalls(bs.GetReport(t1.Number), TypeOfSort.SortByTypeOfCall))
            {
                Console.WriteLine("Calls:\n Type {0} |\n Date of Call: {1} |\n Duration: {2} | Cost of Call: {3} | Telephone number: {4}",
                    item.TypeOfCall, item.Date, item.Time.ToString("mm:ss"), item.Amount, item.Number);
            }

            Console.ReadKey();
        }
    }
}