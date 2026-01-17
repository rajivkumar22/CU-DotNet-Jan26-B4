using System;

namespace Assessment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the information of insurance premium summary system");
            string[] policyHolderNames = new string[5];
            decimal[] annualPremiums = new decimal[5];
            decimal totalPremiumAmount = 0M;
            decimal highestPremium = decimal.MinValue;
            decimal lowestPremium = decimal.MaxValue;
            decimal averagePremium;
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Enter policy holder name{i+1}:");
                policyHolderNames[i] = Console.ReadLine();

                while (string.IsNullOrEmpty(policyHolderNames[i]))
                {
                    Console.Write("Name cannot be empty-please enter again");
                    policyHolderNames[i] = Console.ReadLine();
                }
                Console.Write($"Enter annual premium of the person{i+1}:");
                annualPremiums[i] = decimal.Parse(Console.ReadLine());

                while (annualPremiums[i] < 0)
                {
                    Console.Write("Premium must be greater than 0,Enter again: ");
                    annualPremiums[i] = decimal.Parse(Console.ReadLine());
                }
                totalPremiumAmount += annualPremiums[i];
                if (annualPremiums[i] > highestPremium)
                    highestPremium = annualPremiums[i];

                if (annualPremiums[i] < lowestPremium)
                    lowestPremium = annualPremiums[i];
            }
            averagePremium = totalPremiumAmount / 5;
            Console.WriteLine("Insurance Premium Summary");
            Console.WriteLine($"{"NAME",-10} {"PREMIUM",10} {"CATEGORY",-10}");
            for (int i = 0; i < 5; i++)
            {
                string category;
                if (annualPremiums[i] < 10000)
                    category = "LOW";
                else if (annualPremiums[i] >= 10000 && annualPremiums[i] <= 25000)
                    category = "MEDIUM";
                else
                    category = "HIGH";
                Console.WriteLine($"{policyHolderNames[i].ToUpper(),-10} {annualPremiums[i],10:F2} {category,-10}");  
            }
            Console.WriteLine($"Total Premium   : {totalPremiumAmount:F2}");
            Console.WriteLine($"Average Premium : {averagePremium:F2}");
            Console.WriteLine($"Highest Premium : {highestPremium:F2}");
            Console.WriteLine($"Lowest Premium  : {lowestPremium:F2}");
        }
    }
}
