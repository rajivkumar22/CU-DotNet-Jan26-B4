

//namespace OopsConcept
//{
//    class Person1
//    {
//        public Person1()
//        {
//            AadharId = 0;
//            Name = string.Empty;
//            Console.WriteLine("Default constructor is called");
//        }
//        public Person1(int Id,string name)
//        {
//            AadharId=Id;
//            Name =name;
//            Console.WriteLine("parametrized constructor is called");

//        }

//        public string Name{ get; set; }
//        public int AadharId { get; set; }
//        public override string ToString()
//        {
//            return $"Name:{Name} Aadhar card id:{AadharId}";
//        }
//    }

//    class Student:Person1
//    {

//        public string Degree { get; set; }
//        public string College { get; set; }
//        public Student()
//        {
//           Degree = string.Empty;
//            College = string.Empty;

//        }
//        public Student(int Id, string Name,string college,string degree):base (Id,Name)
//        {
//            Degree = degree;
//            College = college;

//        }
//        public override string ToString()
//        {
//            return  base.ToString()+$" Degree:{Degree} College:{College}";
//        }
//    }



//    internal class Inheritance
//    {
//        static void Main(string[] args)
//        {
//            Student s1 = new Student() { 
//               AadharId= 122,
//                Name="rajiv",
//                Degree="cse",
//                College="Chandigarh University"
//            };

//            Console.WriteLine(s1);
//            Student s2 = new Student(122, "rajiv", "CU", "cse");
//            Console.WriteLine(s2);


//        }
//    }
//}
