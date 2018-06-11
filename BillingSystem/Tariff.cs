using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS_Task3.States;

namespace ATS_Task3.BillingSystem
{
    public class Tariff
    {
        public int SubscriptionFee { get; private set; }
        public int PricePerMinute { get; private set; }
        public int LimitСallsPerMonth { get; private set; }
        public TypeOfTariff TariffType { get; private set; }
        public Tariff(TypeOfTariff type)
        {
            TariffType = type;
            switch (TariffType)
            {
                case TypeOfTariff.Mini:
                    {
                        SubscriptionFee = 10;
                        PricePerMinute = 1;
                        LimitСallsPerMonth = 3;
                        break;
                    }
                case TypeOfTariff.Maxi:
                    {
                        SubscriptionFee = 20;
                        PricePerMinute = 2;
                        LimitСallsPerMonth = 8;
                        break;
                    }
                default:
                    {
                        SubscriptionFee = 0;
                        PricePerMinute = 0;
                        LimitСallsPerMonth = 0;
                        break;
                    }
            }
        }
    }
}
