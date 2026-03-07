using System;

namespace MethodsOrder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal[] dailySales = new decimal[7];

            string[] salesCategory = new string[7];

            ReadWeeklySales(dailySales);

            decimal total = CalculateTotal(dailySales);

            decimal average = CalculateAverage(total, dailySales.Length);

            int highestDay;

            decimal highestSale = FindHighestSale(dailySales, out highestDay);

            int lowestDay;

            decimal lowestSale = FindLowestSale(dailySales, out lowestDay);

            decimal discount = CalculateDiscount(total);

            bool isFestivalWeek = true;

            decimal festivalDiscount = CalculateDiscount(total, isFestivalWeek);

            decimal discountedAmount = total - discount;

            decimal tax = CalculateTax(discountedAmount);

            decimal finalAmount = CalculateFinalAmount(total, discount, tax);

            GenerateSalesCategory(dailySales, salesCategory);

            Console.WriteLine("\nWeekly Sales Summary");

            Console.WriteLine("--------------------");

            Console.WriteLine("Total Sales        : " + total);

            Console.WriteLine("Average Daily Sale : " + average);

            Console.WriteLine();
            Console.WriteLine("Highest Sale       : " + highestSale + " (Day " + highestDay + ")");

            Console.WriteLine("Lowest Sale        : " + lowestSale + " (Day " + lowestDay + ")");

            Console.WriteLine();
            Console.WriteLine("Discount Applied   : " + discount);

            Console.WriteLine("Tax Amount         : " + tax);

            Console.WriteLine("Final Payable      : " + finalAmount);

            Console.WriteLine();

            Console.WriteLine("Day-wise Category:");

            for (int i = 0; i < salesCategory.Length; i++)
            {
                Console.WriteLine("Day " + (i + 1) + " : " + salesCategory[i]);
            }

        }

        static void ReadWeeklySales(decimal[] sales)
        {
            for (int i = 0; i < sales.Length; i++)
            {
                decimal value = -1;

                while (value < 0)
                {
                    Console.Write("Enter sales for Day " + (i + 1) + ": ");

                    string input = Console.ReadLine();

                    bool success = decimal.TryParse(input, out value);
                    if (!success || value < 0)
                    {
                        Console.WriteLine("Invalid input! Enter a number >= 0.");
                        value = -1;
                    }
                }
                sales[i] = value;
            }
        }

        static decimal CalculateTotal(decimal[] sales)
        {
            decimal total = 0;
            for (int i = 0; i < sales.Length; i++)
            {
                total += sales[i];
            }
            return total;
        }

        static decimal CalculateAverage(decimal total, int days)
        {
            return total / days;
        }

        static decimal FindHighestSale(decimal[] sales, out int day)
        {
            decimal highest = sales[0];
            day = 1;
            for (int i = 1; i < sales.Length; i++)
            {
                if (sales[i] > highest)
                {
                    highest = sales[i];
                    day = i + 1;
                }
            }
            return highest;
        }

        static decimal FindLowestSale(decimal[] sales, out int day)
        {
            decimal lowest = sales[0];
            day = 1;
            for (int i = 1; i < sales.Length; i++)
            {
                if (sales[i] < lowest)
                {
                    lowest = sales[i];
                    day = i + 1;
                }
            }
            return lowest;
        }

        static decimal CalculateDiscount(decimal total)
        {
            if (total >= 50000)
                return total * 0.10m;
            else
                return total * 0.05m;
        }

        static decimal CalculateDiscount(decimal total, bool isFestivalWeek)
        {
            decimal baseDiscount = CalculateDiscount(total);
            if (isFestivalWeek)
                baseDiscount += total * 0.05m;
            return baseDiscount;
        }

        static decimal CalculateTax(decimal amount)
        {
            return amount * 0.18m;
        }

        static decimal CalculateFinalAmount(decimal total, decimal discount, decimal tax)
        {
            return total - discount + tax;
        }

        static void GenerateSalesCategory(decimal[] sales, string[] categories)
        {
            for (int i = 0; i < sales.Length; i++)
            {
                if (sales[i] < 5000)
                    categories[i] = "Low";
                else if (sales[i] <= 15000)
                    categories[i] = "Medium";
                else
                    categories[i] = "High";
            }
        }
    }
}