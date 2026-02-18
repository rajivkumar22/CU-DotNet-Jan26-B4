using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagement
{
    internal class DailyLogger
    {
        static void Main(string[] args)
        {
            

            string path = @"..\..\..\Journal.txt";
            Console.WriteLine("enter daily reflection");
            string input = Console.ReadLine();
            using StreamWriter sw = new StreamWriter(path, true);
            {
                sw.WriteLine(input);
            }
            // Console.WriteLine(Directory.GetCurrentDirectory());
            string newpath = @"..\..\..\song.txt";
            using (StreamWriter writer = new StreamWriter(newpath))
            {
                for (int i = 0; i < 5; i++)
                {
                    writer.WriteLine("MY EYE");
                }
            }
            using (StreamReader sr = new StreamReader(newpath))
            {
                sr.ReadLine();
            }
            FileStream fs = new FileStream("DATA.TXT", FileMode.Create);


        }
    }
}
