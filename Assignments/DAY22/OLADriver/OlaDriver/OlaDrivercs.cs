

using System.Globalization;
using System.Xml.Linq;

namespace SatPractice
{
    class OlaDriver {
        public int DriverId{ get; set; }
        public string Name { get; set; }
        public string VehicleNumber { get; set; }
        public int Rides { get; set; }
        public List<Ride> rides = new List<Ride>();
        public void AddRides(int rideid, String from, string to, decimal fare)
        {
            Ride ride = new Ride(rideid, from, to, fare);
            rides.Add(ride);

        }
      

    }
    class Ride
        {
        public int RideId { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public decimal Fare { get; set; }


        public  Ride(int rideid,String from,string to,decimal fare)
        {
            RideId = rideid;
            From = from;
            To = to;
            Fare = fare;
        }
        public override string ToString()
        {
            return $"RideId:{RideId} from {From} To {To} Fare {Fare} ";
        }

    }

    internal class OlaDrivercs
    {
        static void Main(string[] args)
        {
            OlaDriver driver1 = new OlaDriver()
            {
                DriverId = 101,
                Name = "pramod",
                VehicleNumber = "A1B",
                Rides = 2

            };
            driver1.AddRides(101, "mohali", "kharar", 650);
            List<OlaDriver> drivers = new List<OlaDriver>();
            drivers.Add(driver1);
           // driver.Add(driver1);

            foreach(var driver in drivers)
            {
                Console.WriteLine($"Driver name {driver.Name} ");
            }
           
            

        }
    }
}
