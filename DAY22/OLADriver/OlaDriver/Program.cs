using System.Text.RegularExpressions;

namespace SatPractice
{
    internal class Program
    {

        static bool Pancheck(string s)
        {
            if (s.Length != 10)
                return false;

            for (int i = 0; i < 5; i++)
            {
                if (!char.IsUpper(s[i]))
                    return false;
            }

            for (int i = 5; i < 9; i++)
            {
                if (!char.IsDigit(s[i]))
                    return false;
            }

            if (!char.IsUpper(s[9]))
                return false;

            return true;
        }

        public static void Main()
        {
            string pan = "APFP1209F";
            Console.WriteLine(Pancheck(pan));
           
            string name = "Rajiv";
            bool validfirstname = Regex.IsMatch(name, @"^[A-Z]{1}[a-z]{2,5}$");
            Console.WriteLine(validfirstname);

        }
    }
        
    
}
