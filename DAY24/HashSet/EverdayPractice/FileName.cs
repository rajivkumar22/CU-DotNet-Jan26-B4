using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace EverdayPractice
{
    interface IDevice
    {
        void Print();
        void display();
    }
    class Printer : IDevice
    {
        public void Print()
        {
            Console.WriteLine("Printing");
        }
        public void display()
        {
            Console.WriteLine("new printer");
        }
    }
    class InkjetPrinter : IDevice
    {
        public void Print()
        {
            Console.WriteLine("InjketPrinter");
        }
        public void display()
        {
            Console.WriteLine("new printer");
        }
    }
    class Computer
    {
        private IDevice device;

        //private Printer p = new Printer();
        public Computer(IDevice d)
        {
            device = d;
        }

        public void StartPrinting()
        {
            device.Print();
            device.display();
            //p.Print();
        }
    }
    internal class FileName
    {
        static void Main(string[] args)
        {
            IDevice device = new InkjetPrinter();
            IDevice device1 = new Printer();
            Computer c = new Computer(device);
            Computer c1 = new Computer(device1);
            //Computer c = new Computer();
            c.StartPrinting();
            c1.StartPrinting();
        }
    }
}