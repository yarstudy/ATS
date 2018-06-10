using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.States;

namespace ATS
{
    public class Tariff
    {
        public int SubscriptionFee { get; private set; }
        public int PerMinuteFee { get; private set; }
        public TypeOfTariff TariffType { get; private set; }
        public Tariff(TypeOfTariff type)
        {
            TariffType = type;
            switch (TariffType)
            {
                case TypeOfTariff.Mini:
                    {
                        SubscriptionFee = 10;
                        PerMinuteFee = 1;
                        break;
                    }
                case TypeOfTariff.Maxi:
                    {
                        SubscriptionFee = 20;
                        PerMinuteFee = 2;
                        break;
                    }
             }
        }
    }
}
