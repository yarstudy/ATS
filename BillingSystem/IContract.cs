using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS_Task3.States;

namespace ATS_Task3.BillingSystem
{
    public interface IContract
    {
        Subscriber Subscriber { get; }
        int Number { get; }
        Tariff Tariff { get; }
        void ChangeTariff(TypeOfTariff tariffType);
    }
}
