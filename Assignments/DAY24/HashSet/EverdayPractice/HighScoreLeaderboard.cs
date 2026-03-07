using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverdayPractice
{
    internal class HighScoreLeaderboard
    {
        static void Main(string[] args)
        {
            SortedDictionary<double, string> dict = new SortedDictionary<double, string>();
            dict.Add(55.42, "SwiftRacer");
            dict.Add(52.10, "SpeedDemon");
            dict.Add(58.91, "SteadyEddie");
            dict.Add(51.05, "TurboTom");
           
              foreach(var v in dict)
            {
                Console.WriteLine($"PlayerName{v.Value,-15}|TimeTaken:{v.Key:F2}");
            }
            Console.WriteLine(dict.First());
            string name = "SteadyEddie";
            double removekey = 0;
             foreach (var item in dict)
            {
                if (item.Value == name)
                {
                    // dict.Remove(item.Key);
                    removekey = item.Key;
                    
                }
            }
            dict.Remove(removekey);
            dict.Add(54, name);

            foreach (var v in dict)
            {
                Console.WriteLine($"PlayerName:{v.Value,-15}|TimeTaken:{v.Key:F2}");

            }
            }


        }
    }

