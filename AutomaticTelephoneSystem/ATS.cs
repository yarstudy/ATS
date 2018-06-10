using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS_Task3.BillingSystem;
using ATS_Task3.States;
using ATS_Task3.EventsArgs;

namespace ATS_Task3.AutomaticTelephoneSystem
{
    public class ATS
    {
        Random random;
        private IList<CallInfo> Calls { get; set; }
        private IDictionary<int, Tuple<Port, Contract>> Subscribers { get; set; }

        public ATS()
        {
            Calls = new List<CallInfo>();
            Subscribers = new Dictionary<int, Tuple<Port, Contract>>();
            random = new Random();
        }

        public Terminal NewTerminal(Contract contract)
        {
            var newPort = new Port();
            newPort.AnswerEvent += Calling;
            newPort.CallEvent += Calling;
            Subscribers.Add(contract.Number, new Tuple<Port, Contract>(newPort, contract));
            var newTerminal = new Terminal(contract.Number, newPort);
            return newTerminal;
        }

        public Contract SignContract(Subscriber subscriber, TypeOfTariff type)
        {
            Contract contract = new Contract(subscriber, type);
            return contract;
        }

        public void Calling(object sender, IEventArgs e)
        {
            if (Subscribers.ContainsKey(e.TargetNumber) && e.TargetNumber != e.Number)
            {
                var targetPort = Subscribers[(e.TargetNumber)].Item1;
                var port = Subscribers[(e.Number)].Item1;
                if (targetPort.State == StateOfPort.Connect && port.State == StateOfPort.Connect)
                {
                    var tuple = Subscribers[(e.Number)];
                    var targetTuple = Subscribers[(e.TargetNumber)];

                    if (e is EventofAnswerArgs)
                    {

                        var answerArgs = (EventofAnswerArgs)e;
                        CallInfo inf = null;
                        if (answerArgs.Id == null)
                        {
                            inf = new CallInfo();
                            Calls.Add(inf);
                        }

                        if (answerArgs.Id != null && Calls.Any(x => x.Id == answerArgs.Id))
                        {
                            inf = Calls.First(x => x.Id == answerArgs.Id);
                        }
                        if (answerArgs.StateOfCall == StateOfCall.Answer)
                        {
                            targetTuple.Item2.Subscriber.WithdrawMoney(tuple.Item2.Tariff.PricePerCall);
                        }
                        if (inf != null)
                        {
                            targetPort.AnswerCall(answerArgs.Number, answerArgs.TargetNumber, answerArgs.StateOfCall, inf.Id);
                        }
                        else
                        {
                            targetPort.AnswerCall(answerArgs.Number, answerArgs.TargetNumber, answerArgs.StateOfCall);
                        }
                    }
                    if (e is EventOfCallArgs)
                    {
                        if (tuple.Item2.Subscriber.Account > tuple.Item2.Tariff.PricePerCall)
                        {
                            var callArgs = (EventOfCallArgs)e;
                            CallInfo inf = null;
                            if (callArgs.Id == null)
                            {
                                inf = new CallInfo();
                                Calls.Add(inf);
                            }

                            if (callArgs.Id != null && Calls.Any(x => x.Id == callArgs.Id))
                            {
                                inf = Calls.First(x => x.Id == callArgs.Id);
                            }
                            if (inf != null)
                            {
                                targetPort.IncomingCall(callArgs.Number, callArgs.TargetNumber, inf.Id);
                            }
                            else
                            {
                                targetPort.IncomingCall(callArgs.Number, callArgs.TargetNumber);
                            }
                        }
                        else
                        {
                            Console.WriteLine("There is not enough money on the terminal {0}!", e.Number);
                        }
                    }
                }
            }
            else if (!Subscribers.ContainsKey(e.TargetNumber))
            {
                Console.WriteLine("Trying to call a non-existent number".ToUpper());
            }
            else
            {
                Console.WriteLine("Trying to call your own number".ToUpper());
            }
        }
    }
}