using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace KitchenAppliance
{


    public abstract class KitchenElecAppl
    {
        public double Electricwattage { get; set; }
        public string ModelName { get; set; }
        public double price { get; set; }
        public abstract void Cook();
        public bool Ison { get; set; }
        public virtual void preheat(int temp)
        {

           // Console.WriteLine("preheating");
        }


    }
    class ElectricOven : KitchenElecAppl, Itimer, ISmart
    {

        public override void Cook()
        {
            Console.WriteLine("Cooking on ElectricOven has Started");
        }
        public void ConnectWifi(string password)
        {
            if (password == "1234")
            {
                Console.WriteLine("wifi is connected success");
            }
            else
            {
                Console.WriteLine("wifi is not connected");
            }

        }
        public override void preheat(int temp)
        {
            Console.WriteLine($"Preheating of ElectricOven at temperature:{temp}degree");
        }

        public void SetTimer(int time)
        {
            Console.WriteLine($"Time set for :{time} minute");
        }

    }
    class MicroWave : KitchenElecAppl, Itimer
    {
        public override void Cook()
        {
            Console.WriteLine("Cooking on MicroWave has started");
        }
        public void SetTimer(int time)
        {
            Console.WriteLine($"Timer set for:{time} minutes");
        }

    }
    class AirFryer : KitchenElecAppl
    {
        public override void Cook()
        {
            Console.WriteLine("Cooking on AirFryer has started");
        }
    }
    public interface Itimer
    {
        public void SetTimer(int time);
    }
    public interface ISmart
    {

        public void ConnectWifi(string password);
    }



    internal class Program
    {
        static void Main(string[] args)
        {
            List<KitchenElecAppl> kitchens = new List<KitchenElecAppl>()
            {
                new ElectricOven
                {
                    ModelName = "USA"
                },
                new MicroWave
                {
                    ModelName = "philips"
                },
                new AirFryer
                {
                    ModelName = "zks"
                }
            };
            foreach (var kitchen in kitchens)
            {
                
                kitchen.Cook();
                kitchen.preheat(180);
                if (kitchen is MicroWave)
                {
                    var obj = (MicroWave)kitchen;
                    
                    obj.SetTimer(5);
                    
                }
                if(kitchen is ISmart)
                {
                    var obj = (ElectricOven)kitchen;
                    obj.SetTimer(8);
                    obj.ConnectWifi("12345");
                }
            }


        }
    }
}
