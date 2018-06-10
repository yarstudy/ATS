using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.States;

namespace ATS
{
    public class Contract
    {
        public string Name { get; private set; }
        public int Number { get; private set; }
        public Tariff Tariff { get; set; }
        public ATS Ats;

        public Contract(string name, int number, TypeOfTariff tariffType, ATS ats)
        {
            Name = name;
            Number = number;
            Tariff = new Tariff(tariffType);
            Ats = ats;
        }

        public Terminal ToSignContract()
        {
            return Ats.NewTerminal(Number);
        }
    }
}
