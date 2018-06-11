using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS_Task3.BillingSystem
{
    public class Report
    {
        public IList<RecordOfReport> Records { get; private set; }
        public Report()
        {
            Records = new List<RecordOfReport>();
        }
        public void AddRecordOfReport(RecordOfReport record)
        {
            Records.Add(record);
        }
        public IList<RecordOfReport> GetRecords()
        {
            return Records;
        }
    }
}
