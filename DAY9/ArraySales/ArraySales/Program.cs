using System;

namespace ArraySales
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal[] dailySales = new decimal[7];
            string[] salesCategory = new string[7];

            for (int i = 0; i < dailySales.Length; i++)
            {
                decimal sales;
                while (true)
                {
                    Console.Write($"Enter sales for Day {i + 1}: ");
                    string input = Console.ReadLine();

                    if (decimal.TryParse(input, out sales) && sales >= 0)
                    {
                        dailySales[i] = sales;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input! Sales must be a number >= 0. Try again.");
                    }
                }
            }

            decimal totalSales = 0;
            decimal highestSale = dailySales[0];
            int highestDay = 1;
            decimal lowestSale = dailySales[0];
            int lowestDay = 1;
            int daysAboveAverage = 0;

            for (int i = 0; i < dailySales.Length; i++)
            {
                totalSales += dailySales[i];

                if (dailySales[i] > highestSale)
                {
                    highestSale = dailySales[i];
                    highestDay = i + 1;
                }

                if (dailySales[i] < lowestSale)
                {
                    lowestSale = dailySales[i];
                    lowestDay = i + 1;
                }

                if (dailySales[i] < 5000)
                {
                    salesCategory[i] = "Low";
                }
                else if (dailySales[i] <= 15000)
                {
                    salesCategory[i] = "Medium";
                }
                else
                {
                    salesCategory[i] = "High";
                }
            }

            decimal averageSales = totalSales / dailySales.Length;

            for (int i = 0; i < dailySales.Length; i++)
            {
                if (dailySales[i] > averageSales)
                {
                    daysAboveAverage++;
                }
            }

            Console.WriteLine("Weekly Sales Report");
            Console.WriteLine("-------------------");
            Console.WriteLine($"Total Sales        : {totalSales:F2}");
            Console.WriteLine($"Average Daily Sales : {averageSales:F2}\n");
            Console.WriteLine($"Highest Sales      : {highestSale:F2} (Day {highestDay})");
            Console.WriteLine($"Lowest Sales        : {lowestSale:F2}  (Day {lowestDay})\n");
            Console.WriteLine($"Days Above Average : {daysAboveAverage}\n");
            Console.WriteLine("Day-wise Sales Category:");
            for (int i = 0; i < salesCategory.Length; i++)
            {
                Console.WriteLine($"Day {i + 1} : {salesCategory[i]}");
            }

            
        }
    }
}