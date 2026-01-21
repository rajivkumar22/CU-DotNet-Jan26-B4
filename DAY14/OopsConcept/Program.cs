using System.Windows.Markup;

namespace OopsConcept
{
    class Person
    {



        ////data memebers
        //string name = string.Empty;
        ////method 
        //public void setName(string name)
        //{
        //    this.name = name;
        //}
        //public void getName()
        //{
        //    Console.WriteLine(name);
        //}
        ////properties
        //private int age;

        //public int Age
        //{
        //    get { return age; }
        //    set
        //    {
        //        if (value > 0 && value <= 100)
        //        { age = value; }
        //    }
        //}
        //private string city;
        //public string City
        //{
        //    get { return city; }
        //    set { city = value; }
        //}
        //public string  Mobile { get; set; }



    }

    class Employee
    {
        private int id;
        public void setId(int id)
        {
            this.id = id;
        }
        public void getName()
        {
            Console.WriteLine(id);
        }
        public string name { get; set; }

        private string department;
        public string Departments
        {
            get { return department; }
            set
            {
                if (value == "Sales" || value == "Accounts" || value == "IT")
                {
                    department = value;
                }
            }
        }
        private int salary;
        public int Salary
        {
            get { return salary; }
            set
            {
                if (value >= 500000 && value <= 900000)
                {
                    salary = value;
                }
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                // Console.WriteLine("Hello, World!");
                //  Person p1 = new Person();
                //p1.setName("person1");
                //p1.getName();
                //p1.Age = -22;
                //p1.City = "chd";
                //p1.Mobile = "32433554545";
                //Console.WriteLine(p1.Age);
                //Console.WriteLine(p1.City);
                //Console.WriteLine(p1.Mobile);
                Employee emp = new Employee();
                emp.setId(44);
                emp.getName();
                emp.name = "Rajiv";
                emp.Departments = "IT";
                emp.salary = 400000;
                Console.WriteLine($" Name of Employee is:{emp.name}");
                Console.WriteLine($"department name is:{emp.Departments}");
                Console.WriteLine($"Employee salary is:{emp.salary}");




            }
        }
    }
}
