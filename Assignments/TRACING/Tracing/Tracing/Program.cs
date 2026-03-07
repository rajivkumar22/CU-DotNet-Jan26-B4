using System.Diagnostics;

namespace Tracing
{
    internal class Program
    {
        static int GetSum(params int[]arr)
        {
            if (arr.Length == 0)
            {

                Trace.TraceInformation("No value passed");
                Trace.TraceError("No value is passed");
            }
            else
                Trace.TraceInformation($"{arr.Length} number passed");
            int sum = 0;
            for(int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            return sum;

        }
        static void Show()
        {
            Trace.WriteLine("Show Method called");
            Console.WriteLine("Display called");
        }
        
        static void Main(string[] args)
        {
           
            string tracefile = @"..\..\..\trace.log";
            var listner=new TextWriterTraceListener(tracefile);
            Trace.Listeners.Add(listner);
            
            Trace.AutoFlush = true;
            Trace.WriteLine(DateTime.Now);
            Trace.WriteLine("Main started...");
            Show();
          //  int[] arr1 = { 1, 2, 3, 4, 5 };
           int result= GetSum(1,3,4,5,7,8,8,0);
            Console.WriteLine(result);
            int result1 = GetSum();
            Console.WriteLine(result1);
            Console.WriteLine(".....................");
            Trace.Listeners.Remove(listner);
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
            Trace.WriteLine("Main completed");
            
        }
    }
}
