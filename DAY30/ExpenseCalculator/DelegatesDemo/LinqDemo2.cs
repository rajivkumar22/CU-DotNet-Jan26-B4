using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesDemo
{
    class Student
    {
        public int Id;
        public string Name;
        public string Class;
        public int Marks;
        public override string ToString()
        {
            return ($"{Name} {Marks}");
        }
    }

    class Employee
    {
        public int Id;
        public string Name;
        public string Dept;
        public double Salary;
        public DateTime JoinDate;
      
    }
    class Product
    {
        public int Id; 
        public string Name; 
        public string Category; 
        public double Price;
        public override string ToString()
        {
            return ($"{Name} ");
        }
    }
    class Sale 
    { public int ProductId;
        public int Qty; 
    }





    internal class LinqDemo2
    {
        //static void studentshow()
        //{
        //    var students = new List<Student>()
        //{
        //    new Student{Id=1, Name="Amit", Class="10A", Marks=85},
        //    new Student{Id=2, Name="Neha", Class="10A", Marks=72},
        //    new Student{Id=3, Name="Rahul", Class="10B", Marks=90},
        //    new Student{Id=4, Name="Pooja", Class="10B", Marks=60},
        //    new Student{Id=5, Name="Kiran", Class="10A", Marks=95}
        //};



        //    var morethan80 = students.Where(s => s.Marks > 80).ToList();
        //    foreach (var student in morethan80)
        //    {
        //        Console.WriteLine(student);
        //    }
        //    var selectedproperties = students.Select(s => new { s.Name, s.Marks });
        //    foreach (var s in selectedproperties)
        //    {
        //        Console.WriteLine($"{s.Name}-{s.Marks}");

        //    }
        //    var totalmarksum = students.Sum(f => f.Marks);
        //    Console.WriteLine(totalmarksum);

        //    var studentclasses = students.GroupBy(f => f.Class);
        //    foreach (var group in studentclasses)
        //    {
        //        Console.WriteLine(group.Key + " " + group.Count());
        //        Console.WriteLine("   ");
        //        foreach (var ch in group)
        //        {
        //            Console.WriteLine($"{ch.Name} {ch.Marks}");
        //        }
        //        Console.WriteLine("--------------");

        //    }
        //    var namewithH = students.Where(s => s.Name.Contains("h"));
        //    foreach (var ch in namewithH)
        //    {
        //        Console.WriteLine($"{ch.Name}");
        //    }
        //    // Console.WriteLine("Name with h:"+namewithH);//object
        //    var TopThree = students.OrderByDescending(o => o.Marks).Take(3);
        //    foreach (var ch in TopThree)
        //    {
        //        Console.WriteLine($"{ch.Name} {ch.Marks}");
        //    }
        //    var averageinclasss = students.GroupBy(g => g.Class)
        //        .Select(g =>
        //    new {
        //        Class = g.Key,
        //        Avg = g.Average(s => s.Marks)
        //    }
        //    );
        //    foreach (var avg in averageinclasss)
        //    {
        //        Console.WriteLine(avg);
        //    }
        //    var belowavg = students.GroupBy(g => g.Class).Select(x => new { Class = x.Key, stud = x.Where(z => z.Marks < x.Average(a => a.Marks)) });


        //    foreach (var ch in belowavg)
        //    {
        //        Console.WriteLine(ch.Class);
        //        foreach (var s in ch.stud)
        //        {
        //            Console.WriteLine($"{s.Name} {s.Marks}");

        //        }
        //    }

        //    var belowavegmarks = students.Where(s => s.Marks < (students.Where(x => x.Class == s.Class).Average(a => a.Marks)));
        //    Console.WriteLine("student below average marks");
        //    foreach(var ch in belowavegmarks)
        //    {
        //        Console.WriteLine(ch.Name);
        //    }
        //    var orderbyclass = students.OrderByDescending(s => s.Class).ThenByDescending(s => s.Marks);
        //    foreach(var order in orderbyclass)
        //    {
        //        Console.WriteLine(order);
        //    }
        //}

//        static void ProductInventory()
//        {
           
        

//        var products = new List<Product>
//{
//    new Product{Id=1, Name="Laptop", Category="Electronics", Price=50000},
//    new Product{Id=2, Name="Phone", Category="Electronics", Price=20000},
//    new Product{Id=3, Name="Table", Category="Furniture", Price=5000}
//};

//        var sales = new List<Sale>
//{
//    new Sale{ProductId=1, Qty=10},
//    new Sale{ProductId=2, Qty=20}
//}; 




   // }
        static void Employee()
        {
            var employees = new List<Employee>
{
    new Employee{Id=1, Name="Ravi", Dept="IT", Salary=80000, JoinDate=new DateTime(2019,1,10)},
    new Employee{Id=2, Name="Anita", Dept="HR", Salary=60000, JoinDate=new DateTime(2021,3,5)},
    new Employee{Id=3, Name="Suresh", Dept="IT", Salary=120000, JoinDate=new DateTime(2018,7,15)},
    new Employee{Id=4, Name="Meena", Dept="Finance", Salary=90000, JoinDate=new DateTime(2022,9,1)}
};
            var salarystats = employees.GroupBy(e => e.Dept).Select(g => new
            {
                Dept = g.Key,
                MaxSalary=g.Max(e=>e.Salary),
                MinSalary=g.Min(e=>e.Salary)

            });
            foreach(var salary in salarystats)
            {
                Console.WriteLine($"MaxSalary :{salary.MaxSalary} Department:{salary.Dept}");
            }
            Console.WriteLine("====================================");
            foreach(var ch in salarystats)
            {
                Console.WriteLine($"MinSalary :{ch.MinSalary} Department:{ch.Dept}");
            }

            var empCount = employees.GroupBy(e => e.Dept).Select(g => new
                                 {
                                    Dept = g.Key,
                                    Count = g.Count()
                                     });
            Console.WriteLine("====================================");
            foreach (var emp in empCount)
            {
                Console.WriteLine($"{emp.Dept} {emp.Count}");
            }
            Console.WriteLine("====================================");

            var joinedAfter2020 = employees .Where(e => e.JoinDate.Year > 2020);
             foreach(var join in joinedAfter2020)
            {
                Console.WriteLine(join.Name);
            }

            var annualSalary = employees .Select(e => new
                                       {
                                             e.Name,
                                   AnnualSalary = e.Salary * 12
                                          });
            Console.WriteLine("====================================");

            foreach(var sal in annualSalary)
            {
                Console.WriteLine(sal.AnnualSalary);
            }





        }



        static void Main(string[] args)
        {
            //  studentshow();
            //  ProductInventory();
            Employee();

        }
    }
}

