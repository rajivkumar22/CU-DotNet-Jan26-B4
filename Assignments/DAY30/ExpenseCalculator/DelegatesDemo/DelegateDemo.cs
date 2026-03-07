using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace ExpenseCalculator
{
    delegate void MyDelegate();
    internal class DelegateDemo
    {
        
        static void MyMethod()
        {
            Console.WriteLine("this is a method");
        }
        static void MyMethod1()
        {
            Console.WriteLine("this is  a method1");
        }
        static void Main(string[] args)
        {
            //MyDelegate del1 = MyMethod;
            //del1 += MyMethod1;
            //del1();
            //Console.WriteLine("----------------------");
            //del1 -= MyMethod;
            //del1();

            MyDelegate del1 = delegate ()
            {
                Console.WriteLine("Anonymous ");
            };

            del1();
            MyDelegate del2 = () => Console.WriteLine("Lambda Working");
            Action act1 = () => Console.WriteLine("Action Working");
            del2();
            act1();
            Action<int> act2 = (x) => Console.WriteLine(x);//ingoing
            act2(10);
            Action<int, string> act3 = (num, name) => Console.WriteLine($"{num},{name}");
            act3(12, "Rajiv");
            Action<int, string> act4 = (num, name) =>
            {
                Console.WriteLine();
                Console.WriteLine();
            };
            List<int> ar = new List<int>{ 2, 7, 1, 6, 3, 2 };
            var abovefive = ar.Where(x => x > 5).OrderByDescending(x => x);
            Console.WriteLine(string.Join(",",abovefive));
            List<int>abovefivelist=ar.Where(x => x > 5).OrderByDescending(x => x).ToList();
            Func<int, int> GetDouble = (x) => x * 2;
            Console.WriteLine( GetDouble(2));

        }
    }
}
