using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS_Task3.BillingSystem
{
    public class Subscriber
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Account { get; private set; }

        public Subscriber(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Account = 100;
        }

        public void PutMoney(int sum)
        {
            Account += sum;
        }

        public void WithdrawMoney(int sum)
        {
            Account -= sum;
        }
    }
}
