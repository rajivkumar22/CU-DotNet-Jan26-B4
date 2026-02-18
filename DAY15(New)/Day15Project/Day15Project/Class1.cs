

namespace Day15Project
{

    class Employee
    {
        public static string Company { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        static int incr;
        public static void changecompany(string cname)
        {
            Company = cname;
        }
         static Employee()
        {
            incr = 1110;
            Company = "capegemini";
            Console.WriteLine("static constructor");
        }
        public Employee()
        {
            incr++;
            Id = incr;
            Console.WriteLine("default constructor");
        }
        public override string ToString()
        {
            return $"Id is:{Id} Name :{Name} Department:{Department} company:{Company}";
        }

    }
    internal class Class1
    {
        static void Main(string[] args)
        {
            //Employee.Company = "Capegemini";
            //Employee.changecompany("Newcapegemini");
            Employee e1 = new Employee()
            {
               // Id=1111,
                Name="Rajiv",
                Department="IT"
            };
            Console.WriteLine(e1);
            Employee e2 = new Employee()
            {
               // Id = 1111,
                Name = "Rajiv",
                Department = "IT"
            };
            Console.WriteLine(e2);

        }
    }
}
