using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseCalculator
{

    internal class TripExpense
    {
        static List<string> SettleExpenses(Dictionary<string, double> expenses)
        {
            List<string> report = new List<string>();
            Queue<KeyValuePair<string, double>> receivers = new Queue<KeyValuePair<string, double>>();
            Queue<KeyValuePair<string, double>> payers = new Queue<KeyValuePair<string, double>>();
            var totalexpenses = expenses.Values.Sum();
            var persons = expenses.Count;
            var share = totalexpenses / persons;
            foreach (var person in expenses)
            {
                if (person.Value > share)
                {
                    receivers.Enqueue(
                        new KeyValuePair<string, double>(person.Key, person.Value - share)


                        );
                }
                else if (person.Value < share)
                {
                    payers.Enqueue(
                        new KeyValuePair<string, double>(person.Key, Math.Abs(person.Value - share))


                        );
                }
            }
            while (payers.Count > 0 && receivers.Count > 0)
            {
                var payer = payers.Dequeue();
                var receiver = receivers.Dequeue();
                var amount = Math.Min(payer.Value, receiver.Value);
                report.Add($"{payer.Key} has to give  {receiver.Key} {amount} rupee ");
                if (payer.Value > amount)
                {
                    payers.Enqueue(new KeyValuePair<string, double>(payer.Key, payer.Value - amount));

                }
                if (receiver.Value > amount) { 
                    receivers.Enqueue(new KeyValuePair<string, double>(receiver.Key,receiver.Value - amount));
                

                }

            }
            
                return report;
            
        }

            static void Main(string[] args)
            {
                Dictionary<string, double> expenses = new Dictionary<string, double>()
            {

                { "rajiv", 1200 },
                {"sanjiv",1300 },
                {"mayank",200},
                {"kunal",500},
               






            };
                List<string> settlement;
                settlement = SettleExpenses(expenses);
                foreach (var ch in settlement)
                {
                Console.WriteLine(ch);
                }
            }
        }
    }

