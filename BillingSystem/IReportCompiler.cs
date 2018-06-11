using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS_Task3.States;

namespace ATS_Task3.BillingSystem
{
    public interface IReportCompiler
    {
        void Compiler(Report report);
        IEnumerable<RecordOfReport> SortCalls(Report report, TypeOfSort typeOfSort);
    }
}
