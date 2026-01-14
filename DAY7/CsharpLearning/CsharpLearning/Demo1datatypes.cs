

namespace CsharpLearning
{
    internal class Demo1datatypes
    {
        static void Main()
        {
            int num = 10;
            object box = num;
            int unbox = (int)box;
            Console.WriteLine("Enter the name and age of the person(seperate by ,)");
            string input = Console.ReadLine();
            string[] inputs = input.Split(',');
            string name = inputs[0];
            int age = int.Parse(inputs[1]);
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine($"Name of the person:{name} and age is:{age}");
            if (age < 18)
            {
                Console.WriteLine("NOT Eligible");
            }
            else
            {
                Console.WriteLine("Eligible");
            }
            int i = 1;
            while (i <= age)
            {
                if (i % 2 == 1)
                {
                    Console.Write($"{i} ");
                }
                i++;

            }
            Console.WriteLine();
            for (int j = 1; j <= age; j += 2)
            {


                Console.Write(j + " ");

            }





        }
    }
}
