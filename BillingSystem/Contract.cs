﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS_Task3.States;
using ATS_Task3.AutomaticTelephoneSystem;

namespace ATS_Task3.BillingSystem
{
    public class Contract : IContract
    {
        public Subscriber Subscriber { get; private set; }
        public int Number { get; private set; }
        public Tariff Tariff { get; set; }
        private DateTime TariffEffectiveDate { get; set; }
        static Random rnd = new Random();

        public Contract(Subscriber subscriber, TypeOfTariff typeOfTariff)
        {
            TariffEffectiveDate = DateTime.Now;
            Subscriber = subscriber;
            Number = rnd.Next(1000,9999);
            Tariff = new Tariff(typeOfTariff);
         }
        public void ChangeTariff(TypeOfTariff typeOfTariff)
        {
            if (DateTime.Now.AddMonths(-1) >= TariffEffectiveDate)
            {
                TariffEffectiveDate = DateTime.Now;
                Tariff = new Tariff(typeOfTariff);
                Console.WriteLine("Tariff has been changed".ToUpper());
            }
            else
            {
                Console.WriteLine("To change the tariff, wait until the end of the month".ToUpper());
            }
        }
    }
}
