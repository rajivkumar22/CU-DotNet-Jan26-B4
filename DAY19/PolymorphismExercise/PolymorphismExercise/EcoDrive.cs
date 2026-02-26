using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorphismExercise
{
    abstract class Vehicle
    {
        public string ModelName { get; set; }
        public Vehicle(string modelname)
        {
            ModelName = modelname;
        }
        public abstract void Move();
        public virtual string GetFuelStatus()
        {
            return "Fuel level is stable";
        }
    }
    class ElectricCar : Vehicle
    {

        public ElectricCar(string modelname) : base(modelname) { }
        public override void Move()
        {
            Console.WriteLine($"{ModelName} is gliding silently on battery power");
        }
        public override string GetFuelStatus()
        {
            return $"{ModelName} battery is at 80 %.";

        }


    }

    class HeavyTruck : Vehicle
    {
        public HeavyTruck(string modelname) : base(modelname) { }
        public override void Move()
        {
            Console.WriteLine($"{ModelName} is hauling cargo with high-torque diesel power.");
        }

    }

    class CargoPlane : Vehicle
    {
        public CargoPlane(string modelname) : base(modelname) { }
        public override void Move()
        {
            Console.WriteLine($"{ModelName} is ascending to 30,000 feet.");
        }



        public override string GetFuelStatus()
        {
            return $"{base.GetFuelStatus()} : Checking jet fuel reserves...";

        }
    }
    internal class EcoDrive
    {
        static void Main(string[] args)
        {
            Vehicle[] vehicle = new Vehicle[3]
       {
             new ElectricCar("Volvo"),
            new  HeavyTruck("Tmax"),
            new CargoPlane("Wkot")
         };
            foreach (var ch in vehicle)
            {
                ch.Move();
                Console.WriteLine(ch.GetFuelStatus());
            }


        }
    }
}
