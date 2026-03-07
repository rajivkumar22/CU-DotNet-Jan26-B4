namespace DelegatesDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> values = new List<int>
            {
                12,14,15,16,17
            };
            values.Where(x => x > 50);
           
        }
    }
}
