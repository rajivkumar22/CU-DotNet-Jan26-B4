using MyClassLibrary;

namespace libraryproject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // int result= GreetingHelper.GetDouble(5);
            Console.WriteLine("Enter the name:");
            string name = Console.ReadLine()??"";
            string result = GreetingHelper.GetGreeting(name);
            Console.WriteLine(result);
           // Console.WriteLine("Hello, World!");
        }
    }
}
