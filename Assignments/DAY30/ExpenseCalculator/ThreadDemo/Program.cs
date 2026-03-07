namespace ThreadDemo
{
    internal class Program
    {
        static void display1()
        {

            for (int i = 0; i < 10; i++)
            {
                Console.Write(i*2);
                Thread.Sleep(1000);
            }
        }
        static void display2()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.Write(i * 3);
                Thread.Sleep(500);
            }
        }
        static void Main(string[] args)
        {
            Thread t1 = new Thread(display1);
            Thread t2 = new Thread(display2);
            //display1();
            //display2();
            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

        }
    }
}
