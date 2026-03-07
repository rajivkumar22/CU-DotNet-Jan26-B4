
namespace OopsConcept
{
    class Laptop :IComparable<Laptop>{
        public string LaptopId { get;set; }
        public  string ModelName { get; set; }
        public int Price{ get; set; }

        public int CompareTo(Laptop? other)
        {
            return this.LaptopId.CompareTo(other?.LaptopId);
        }

        //public int CompareTo(object? obj)
        //{
        //    Laptop Other = (Laptop)obj;
        //   return this.LaptopId.CompareTo(Other.LaptopId);
        //}
        public override string ToString()
        {
            return $"LaptopId:{LaptopId} ModelName:{ModelName} Price:{Price}";
        }
    }
    class LaptopPriceSorter:IComparer<Laptop>
    {
        public int Compare(Laptop x, Laptop y)
        {
            
            return x.Price.CompareTo(y.Price);
        }
    }
    class Laptopmodelnamesorter : IComparer<Laptop> {

        public int Compare(Laptop x, Laptop y)
        {
           
            return x.ModelName.CompareTo(y.ModelName);
        }

    }


    internal class Demo2
    {

        static void Main(string[] args)
        {
            List<Laptop> laptops = new List<Laptop>
            {

            
            // Laptop[] laptops=new Laptop[]{
             new Laptop() //object initializer
            {
                LaptopId = "102",
                ModelName="HP1",
                Price=90000



            },
              new Laptop() 
            {
                LaptopId = "103",
                ModelName="razor8",
                Price=50000}
            };
           // laptops.Sort();
            //  Array.Sort(laptops);


            laptops.Sort(new LaptopPriceSorter());
            Laptop laptop = new Laptop();//named
            laptop.LaptopId = "101";
            laptop.ModelName = "lenovo";
            laptop.Price = 600000;
            var obj1 = new
            {

                LaptopId = "120",
                ModelName = "HP",
                Price = 50000
            };
            foreach(var l in laptops)
            {
                Console.WriteLine(l);
            }
            Console.WriteLine("done");






        }
    }
}
