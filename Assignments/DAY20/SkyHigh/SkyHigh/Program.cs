namespace SkyHigh
{
    class  Flight:IComparable<Flight>
    {
        public string FlightNumber { get; set; }
        public decimal Price { get; set; }
        public TimeSpan Duration { get; set; } 
        public DateTime DepartureTime { get; set; }

        public int CompareTo(Flight? other)
        {

            return this.Price.CompareTo(other?.Price);
        }
        public override string ToString()
        {
            return $"FlightNumber:{FlightNumber} Price:{Price} Duration:{Duration} DepartureTime:{DepartureTime}";
        }
    }
    class DurationComparer:IComparer<Flight> { 
        public int Compare(Flight ?f1,Flight? f2)
        {
           
            
            return f1.Duration.CompareTo(f2.Duration);
        }
    
    }
    class DepartureComparer : IComparer<Flight>
    {
        public int Compare(Flight ?f1, Flight ?f2)
        {
            if (f1 == null || f2 == null) return -1;
            return f1.DepartureTime.CompareTo(f2.DepartureTime);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            List<Flight> fl = new List<Flight>
            {
                new Flight()
                {
                    FlightNumber="102",
                    Price=10000,
                    Duration=new TimeSpan(3,5,22),
                    DepartureTime=new DateTime(2026,03,1)
                },
                 new Flight()
                {
                    FlightNumber="104",
                    Price=12000,
                    Duration=new TimeSpan(1,10,21),
                    DepartureTime=new DateTime(2026,10,11)
                },
                  new Flight()
                {
                    FlightNumber="103",
                    Price=60000,
                    Duration=new TimeSpan(2,1,50),
                    DepartureTime=new DateTime(2026,05,2)
                },
                  new Flight()

            };
            Console.WriteLine("sort by price");
            fl.Sort();
           printflightsinfo(fl );
            //foreach (var f in fl)
            //{
            //    Console.WriteLine(f);
            //}
            Console.WriteLine("sort by departure");
            fl.Sort(new DepartureComparer());
            printflightsinfo(fl);
            //foreach (var f in fl)
            //{
            //    Console.WriteLine(f);
            //}
            Console.WriteLine("sort by duration");
            fl.Sort(new DurationComparer());
            printflightsinfo(fl);
            //foreach (var f in fl)
            //{
            //    Console.WriteLine(f);
            //}

            static void printflightsinfo(List<Flight> flights)
            {
                foreach (var f in flights)
                {
                    Console.WriteLine(f);
                }
            }

        }
    }
}
