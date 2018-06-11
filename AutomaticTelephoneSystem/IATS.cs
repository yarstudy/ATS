using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS_Task3.BillingSystem;
using ATS_Task3.States;
using ATS_Task3.EventsArgs;

namespace ATS_Task3.AutomaticTelephoneSystem
{
    public interface IATS : IMemory<CallInfo>
    {
        Terminal NewTerminal(IContract contract);
        IContract SignContract(Subscriber subscriber, TypeOfTariff typeOfTariff);
        void Calling(object sender, ICallEventArgs e);
    }
}
