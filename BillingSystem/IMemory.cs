using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS_Task3.AutomaticTelephoneSystem;

namespace ATS_Task3.BillingSystem
{
    public interface IMemory<T>
    {
        IList<T> GetInformationList();
    }
}
