using System;

namespace GymCharges
{
    internal class LineMethod
    {
        static void Main(string[] args)
        {
            DisplayLine();
            DisplayLine('+');
            DisplayLine('$', 60);
        }

        static void DisplayLine()
        {
            for (int i = 0; i < 40; i++)
            {
                Console.Write('-');
            }
            Console.WriteLine();
        }

        static void DisplayLine(char c)
        {
            for (int i = 0; i < 40; i++)
            {
                Console.Write(c);
            }
            Console.WriteLine();
        }

        static void DisplayLine(char c, int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.Write(c);
            }
            Console.WriteLine();
        }
    }
}