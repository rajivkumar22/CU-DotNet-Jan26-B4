using System;
using System.Collections.Generic;
using System.Text;

namespace SaaSArchitect
{

    abstract class Subscriber : IComparable<Subscriber>
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public DateTime JoinDate { get; set; }

        public Subscriber(string name, DateTime joindate)
        {
            ID = Guid.NewGuid();
            Name = name;
            JoinDate = joindate;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Subscriber other)
            {
                return this.ID.Equals(other.ID);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        public int CompareTo(Subscriber other)
        {
            if (this.JoinDate < other.JoinDate)
                return -1;

            if (this.JoinDate > other.JoinDate)
                return 1;

            return this.Name.CompareTo(other.Name);
        }

        public abstract decimal CalculateMonthBill();
    }

    class BusinessSubscriber : Subscriber
    {
        public decimal FixedRate { get; set; }
        public decimal TaxRate { get; set; }

        public BusinessSubscriber(string name, DateTime datetime, decimal fixedrate, decimal taxrate)
            : base(name, datetime)
        {
            FixedRate = fixedrate;
            TaxRate = taxrate;
        }

        public override decimal CalculateMonthBill()
        {
            decimal total = FixedRate * (1 + TaxRate);
            return total;
        }
    }

    class ConsumerSubscriber : Subscriber
    {
        public decimal DataUsageRate { get; set; }
        public int PriceperGB { get; set; }

        public ConsumerSubscriber(decimal datausagerate, int pricepergb, string name, DateTime datetime)
            : base(name, datetime)
        {
            DataUsageRate = datausagerate;
            PriceperGB = pricepergb;
        }

        public override decimal CalculateMonthBill()
        {
            decimal total = DataUsageRate * PriceperGB;
            return total;
        }
    }

    class ReportGenerator
    {
        public static void PrintRevenueReport(List<Subscriber> list)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("----- Revenue Report -----");
            sb.AppendLine("Name\tType\tBill");

            foreach (Subscriber s in list)
            {
                string type = s.GetType().Name;
                decimal bill = s.CalculateMonthBill();

                sb.AppendLine(s.Name + "\t" + type + "\t" + bill);
            }

            Console.WriteLine(sb.ToString());
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Subscriber> subscribers = new Dictionary<string, Subscriber>();

            subscribers.Add("google@corp.com",
                new BusinessSubscriber("Google", new DateTime(2023, 1, 10), 1000, 0.18m));

            subscribers.Add("microsoft@corp.com",
                new BusinessSubscriber("Microsoft", new DateTime(2023, 2, 5), 1200, 0.18m));

             List<Subscriber> list = new List<Subscriber>();

            foreach (var item in subscribers)
            {
                list.Add(item.Value);
            }

            list.Sort((a, b) => b.CalculateMonthBill().CompareTo(a.CalculateMonthBill()));

            ReportGenerator.PrintRevenueReport(list);

            Console.ReadLine();
        }
    }
}