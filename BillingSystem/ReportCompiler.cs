using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS_Task3.States;

namespace ATS_Task3.BillingSystem
{
    public class ReportCompiler
    {
        public ReportCompiler()
        {
        }
        public void Compiler(Report report)
        {
            foreach (RecordOfReport record in report.GetRecords())
            {
                Console.WriteLine("Calls:\n Type of Call {0} | Number: {1} |\n Date of Call: {2} |\n Duration of Call: {3} | CostOfCall: {4} ",
                    record.TypeOfCall, record.Number, record.Date, record.Time.ToString("mm:ss"), record.Amount);
            }
        }
        public IEnumerable<RecordOfReport> SortCalls(Report report, TypeOfSort typeOfSort)
        {
            var tempReport = report.GetRecords();
            switch (typeOfSort)
            {
                case TypeOfSort.SortByTypeOfCall:
                    return tempReport = tempReport.OrderBy(x => x.TypeOfCall).ToList();

                case TypeOfSort.SortByDate:
                    return tempReport = tempReport.OrderBy(x => x.Date).ToList();

                case TypeOfSort.SortByAmount:
                    return tempReport = tempReport.OrderBy(x => x.Amount).ToList();

                case TypeOfSort.SortByNumber:
                    return tempReport = tempReport.OrderBy(x => x.Number).ToList();

                default:
                    return tempReport;
            }
        }
    }
}
