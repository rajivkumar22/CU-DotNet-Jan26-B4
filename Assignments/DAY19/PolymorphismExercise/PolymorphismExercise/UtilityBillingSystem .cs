

using PolymorphismExercise;

namespace PolymorphismExercise
{
    abstract class UtilityBill
    {
        public int ConsumerId { get; set; }
        public string? ConsumerName { get; set; }
        public decimal UnitsConsumed { get; set; }

        public decimal RatePerUnit { get; set; }
        public abstract decimal CalculateBillAmount();
        public UtilityBill(int id, string name, decimal units, decimal rate)
        {
            ConsumerId = id;
            ConsumerName = name;
            UnitsConsumed = units;
            RatePerUnit = rate;
        }
        public virtual decimal CalculateTax(decimal billAmount)
        {
            return 0.05m * billAmount;

        }

        public void PrintBill()
        {
            decimal billAmount = CalculateBillAmount();
            decimal tax = CalculateTax(billAmount);
            decimal finalAmount = billAmount + tax;

            Console.WriteLine("==================================");
            Console.WriteLine($"Consumer ID :   {ConsumerId}");
            Console.WriteLine($"Consumer Name : {ConsumerName}");
            Console.WriteLine($"Units Consumed: {UnitsConsumed}");
            Console.WriteLine($"Base Amount   : {billAmount}");
            Console.WriteLine($"Tax Amount    : {tax}");
            Console.WriteLine($"Final Amount  : {finalAmount}");
            Console.WriteLine("==================================\n");
        }

    }

    class ElectricityBill : UtilityBill
    {
        public ElectricityBill(int id, string name, decimal units, decimal rate)
            : base(id, name, units, rate) { }

        public override decimal CalculateBillAmount()
        {
            decimal amount = UnitsConsumed * RatePerUnit;

            if (UnitsConsumed > 300)
            {
                amount += amount * 0.10m;
            }

            return amount;
        }


    }


    class WaterBill : UtilityBill
    {
        public WaterBill(int id, string name, decimal units, decimal rate)
            : base(id, name, units, rate) { }

        public override decimal CalculateBillAmount()
        {
            return UnitsConsumed * RatePerUnit;
        }

        public override decimal CalculateTax(decimal billAmount)
        {
            return billAmount * 0.02m;
        }
    }


    class GasBill : UtilityBill
    {
        public GasBill(int id, string name, decimal units, decimal rate)
            : base(id, name, units, rate) { }

        public override decimal CalculateBillAmount()
        {
            decimal amount = UnitsConsumed * RatePerUnit;
            return amount + 150m;
        }

        public override decimal CalculateTax(decimal billAmount)
        {
            return 0m;
        }
    }





    internal class UtilityBillingSystem
    {


        static void Main(string[] args)
        {
            List<UtilityBill> bills = new List<UtilityBill>
            {
                new ElectricityBill(1, "Rahul", 350, 6),
                new WaterBill(2, "Sneha", 200, 3),
                new GasBill(3, "Amit", 100, 5)
            };

            foreach (var bill in bills)
            {
                bill.PrintBill();
            }

        }
    }
}

