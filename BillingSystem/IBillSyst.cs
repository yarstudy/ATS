using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS_Task3.BillingSystem
{
    public interface IBillSyst
    {
        Report GetReport(int Number);
    }
}
