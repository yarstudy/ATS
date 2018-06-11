using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS_Task3.States;
using ATS_Task3.AutomaticTelephoneSystem;


namespace ATS_Task3.BillingSystem
{
    public class BillSyst : IBillSyst
    {
        private IMemory<CallInfo> Memory { get; set; }
        public BillSyst(IMemory<CallInfo> memory)
        {
            Memory = memory;
        }
        public Report GetReport(int telephoneNumber)
        {
            var calls = Memory.GetInformationList().
                Where(x => x.Number == telephoneNumber || x.TargetNumber == telephoneNumber).ToList();
            Report report = new Report();
            foreach (var call in calls)
            {
                TypeOfCall callType;
                int number;
                if (call.Number == telephoneNumber)
                {
                    callType = TypeOfCall.OutgoingCall;
                    number = call.TargetNumber;
                }
                else
                {
                    callType = TypeOfCall.IncomingCall;
                    number = call.Number;
                }
                var record = new RecordOfReport(callType, number, call.StartOfCall, new DateTime((call.EndOfCall - call.StartOfCall).Ticks), call.CostOfCall); // TimeSpan.FromTicks((call.EndCall - call.BeginCall).Ticks) .TotalMinutes  
                report.AddRecordOfReport(record);
            }
            return report;
        }

    }
}
