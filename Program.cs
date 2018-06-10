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
            ATS ats = new ATS();
            Terminal t1 = ats.NewTerminal();
            Terminal t2 = ats.NewTerminal();
            t1.ConnectToPort();
            t2.ConnectToPort();
            t1.Call(t2.Number);
        }
    }
}