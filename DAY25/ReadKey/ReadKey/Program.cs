using System;

namespace ReadKey
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter 4-digit PIN: ");

            string pin = "";

            while (pin.Length < 4)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (char.IsDigit(keyInfo.KeyChar))
                {
                    pin += keyInfo.KeyChar;
                    Console.Write("*");
                }
            }

            Console.WriteLine();
            Console.WriteLine("PIN Entered: " + pin);
        }
    }
}