using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverdayPractice
{
    static class Mystring {
       public static int  GetWordCount(this string str)
        {
            int count = str.Split().Count();
            return count;
        }
    
    }

    internal class HashSet
    {
        static void Main(string[] args)
        {
            String sen = "This is a sentence";
            int c = sen.GetWordCount();
            Console.WriteLine(c);
            ArrayList al = new ArrayList();
           // Console.WriteLine(al.Capacity);
            
           // Console.WriteLine(al.Capacity);
            al.Add("rajiv");
            al.Add(false);
            al.Add(5.4);
            al.Add(143);
            al.Add(12);
            //  Console.WriteLine(al.Capacity);
            //  Console.WriteLine("count :"+al.Count);
           
            foreach(object item in al)             
            {
               // Type type = item.GetType();

                if (item is int)
                    Console.WriteLine(item);
                Console.WriteLine(item.GetType());
                //if (item.GetType().Name == "INT32")
                //{
                //    Console.WriteLine(item);
                //}
            }
            int[] aray = { 11, 2, 2, 3, 2, 1, 32 };
            var result1 = aray.Where(x => x % 2 == 1)
                 .OrderBy(x=>x)
                .ToArray<int>();
            Console.WriteLine(string.Join(",",result1));

            //HashSet<int> hs = new HashSet<int>();

            //hs.Add(12212);
            //Console.WriteLine(hs.Add(12212));
            //hs.Add(12212);
            //Console.WriteLine(hs.Add(12212));
            Stack<int> s = new Stack<int>();
            s.Push(12);
            s.Push(13);
            Console.WriteLine( s.Pop());
            s.Push(12);

            Queue<int> myQueue = new Queue<int>();
            myQueue.Enqueue(21);
            myQueue.Enqueue(32);
            Console.WriteLine(myQueue.Dequeue());
        }
    }
}
