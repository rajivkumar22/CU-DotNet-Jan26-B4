using MyLibraryDemo;
namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
           // Console.WriteLine("Hello, World!");
            MyMath math = new MyMath();
           int result= math.GetSum(5, 7);
            Console.WriteLine(result) ;

        }
    }
}
