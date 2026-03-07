using System;
using System.Collections.Generic;

namespace DictionaryInsurance
{
    class Policy
    {
        public string HolderName { get; set; }
        public decimal Premium { get; set; }
        public int RiskScore { get; set; }
        public DateTime RenewalDate { get; set; }
    }

    class PolicyTracker
    {
        public Dictionary<string, Policy> dict = new Dictionary<string, Policy>();

        public bool AddPolicy(string Id, Policy policy)
        {
            if (dict.ContainsKey(Id)) return false;
            dict.Add(Id, policy);
            return true;
        }

        public void BulkAdjustment()
        {
            foreach (var item in dict.Values)
            {
                if (item.RiskScore > 75)
                    item.Premium += (item.Premium * 0.05M);
            }
        }

        public void CleanUp()
        {
            foreach (var item in dict)
            {
                DateTime temp = item.Value.RenewalDate;
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            PolicyTracker tracker = new PolicyTracker();

            Policy p1 = new Policy
            {
                HolderName = "Rahul",
                Premium = 10000,
                RiskScore = 80,
                RenewalDate = new DateTime(2026, 5, 10)
            };

            Policy p2 = new Policy
            {
                HolderName = "Aman",
                Premium = 15000,
                RiskScore = 60,
                RenewalDate = new DateTime(2026, 7, 15)
            };

            Policy p3 = new Policy
            {
                HolderName = "Priya",
                Premium = 20000,
                RiskScore = 90,
                RenewalDate = new DateTime(2026, 8, 20)
            };

            tracker.AddPolicy("P101", p1);
            tracker.AddPolicy("P102", p2);
            tracker.AddPolicy("P103", p3);

            tracker.BulkAdjustment();

            Console.WriteLine("Policy Details:\n");

            foreach (var item in tracker.dict)
            {
                Console.WriteLine("Policy ID: " + item.Key);
                Console.WriteLine("Holder Name: " + item.Value.HolderName);
                Console.WriteLine("Premium: " + item.Value.Premium);
                Console.WriteLine("Risk Score: " + item.Value.RiskScore);
                Console.WriteLine("Renewal Date: " + item.Value.RenewalDate.ToShortDateString());
                Console.WriteLine("-----------------------------");
            }
        }
    }
}