

using System.Threading.Channels;

namespace OopsConcept
{
    internal class ArrayListt1
    {
        static void Main(string[] args)
        {
            //  int[] arr = new int[26];
            //  string sentence = "This is a Sentence.";
            ////  sentence = sentence.ToLower();
            //   for(int i = 0; i < sentence.Length; i++)
            //  {
            //      if (char.IsLetter(sentence[i]))
            //      {
            //          char ch = char.ToLower(sentence[i]);
            //          arr[(ch - 'a')]++;
            //      }
            //  }
            //  for(int j = 0; j < arr.Length; j++)
            //  {

            //      Console.WriteLine($" {(char)('a'+j)}:{arr[j]}");
            //  }

            //   country.Add("INDIA", "DELHI");Unhandled exception. System.ArgumentException: An item with the same key has already been added. Key: INDIA
            //  Dictionary<string,int> count = new Dictionary<string, int>();
            Dictionary<string, string> country = new Dictionary<string, string>();
            country.Add("INDIA", "DELHI");
            country.Add("england", "london");
            country.Add("america", "dc");
            //  country.Add("INDIA", "DELHI");
            country["INDIA"] = "PATNA";


            if (!country.ContainsKey("INDIA"))
            {
                country.Add("india", "DELHI");
            }
            else
            {
                Console.WriteLine("key already exist");
            }
            foreach (var item in country)
            {
                Console.WriteLine($"{item.Key}:{item.Value}");
            }
            Console.WriteLine("displaying country key");
            foreach(var c in country.Keys)
            {
                Console.WriteLine(c);
            }
            Console.WriteLine("enter country name");
            string ctr = Console.ReadLine();
            string cap = string.Empty;

            bool existing = country.TryGetValue(ctr, out cap);
            if (existing)
            {
                Console.WriteLine(cap);
            }
            else
            Console.WriteLine("country capital name does not exist in dict");
            string sentence = "This is a Sentence.";
            sentence = sentence.ToLower();
            Dictionary<char, int> countletter = new Dictionary<char, int>();
            int[] ar = new int[26];
            foreach(char ch in sentence)
            {
                if (ch>'a'&&ch<='z')
                {
                    if (!countletter.ContainsKey(ch))
                    {
                        countletter[ch] = 1;
                    }
                    else
                    {
                        countletter[ch]++;
                    }
                }
            }
              for(char c = 'a'; c <= 'z'; c++) {
                if (countletter.ContainsKey(c))
                {
                    Console.WriteLine($"{c}:{countletter[c]}");
                }
                else
                {
                    Console.WriteLine($"{c}:{0}");
                }

            }

            //foreach(var cl in countletter)
            //{
            //    Console.WriteLine($"{cl.Key}:{cl.Value}");
            //}
        }
        
    }
}
