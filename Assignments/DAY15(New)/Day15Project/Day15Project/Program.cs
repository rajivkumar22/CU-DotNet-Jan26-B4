namespace Day15Project
{

    class Height {
        public int Feet { get; set; }
        public decimal Inches{ get; set; }

      public  Height()
        {
            Feet = 0;
            Inches =0.0M;
        }
        public Height(int Feet,decimal Inches)
        {
            this.Feet = Feet;
            this.Inches = Inches;
        }
        public static Height operator+(Height h1,Height h2)
        {
            int totalfeet = h1.Feet + h2.Feet;
            decimal totalinches = h1.Inches + h2.Inches;
            if (totalinches >=12)
            {
                totalfeet += (int)totalinches / 12;
                totalinches = totalinches % 12;
            }
            Height newheight = new Height(totalfeet, totalinches);
            return newheight;
        }
        public override string ToString()
        {
            return $"Height - {Feet} feet {Inches} inches";
        }

    }
          
    internal class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello, World!");
            Height Person1 = new Height(5, 6.8M);
            Height Person2 = new Height(6, 9.8M);
            Height totalheight = Person1 + Person2;
            Console.WriteLine(Person1);
            Console.WriteLine(Person2);
            Console.WriteLine(totalheight);
        }
    }
}
