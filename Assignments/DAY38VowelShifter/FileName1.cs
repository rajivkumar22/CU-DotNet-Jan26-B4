using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOconsole
{
    internal class FileName1
    {  
        public static string vowelshifter(string str)
        {
            string result = "";
            foreach(var ch in str)
            {
                if (ch == 'a')
                {

                    result += 'e';

                }
                else if (ch == 'e')
                {

                    result += 'i';

                }
                else if (ch == 'i')
                {

                    result += 'o';

                }
                else if (ch == 'o')
                {

                    result += 'u';

                }
                else if (ch == 'u')
                {

                    result += 'a';

                }
                else if (ch == 'z') result += 'b';
                else if (ch == 'd' || ch == 'h' || ch == 'n' || ch == 't')
                {
                    result += (char)(ch + 2);
                }
                else
                {
                    result += (char)(ch + 1);
                }

            }
            return result;
        }
        static void Main(string[] args)
        {
            string s = " abcdu hello dfhj aeiou apple crypt";
            string[] arr = s.Split(' ');
            foreach (var ch in arr)
            {
                Console.WriteLine(vowelshifter(ch));
            }
            
        }
    }
}
