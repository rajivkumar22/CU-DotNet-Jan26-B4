
using System.Text;

namespace CsharpLearning
{
    internal class DemoOutputformatting
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{num}x{i,3}={num * i,4}");
            }
            string name = "Rajiv Kumar";
            int number = 12345;
            Console.WriteLine($"|{name,15}|{number,-10}|");
            Console.WriteLine($"{10 / 3.0:F2}");
            Console.OutputEncoding = Encoding.UTF8;
            int salary = 35000;
            Console.WriteLine($"{salary:C}");



        }
    }
}
