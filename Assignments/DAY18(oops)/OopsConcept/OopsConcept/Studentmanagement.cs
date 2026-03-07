
using OopsConcept;

namespace OopsConcept
{
    class Student {
        public int Id { get; set; }
        public string Name{ get; set; }
        public int Marks { get; set; }

        public override string ToString()
        {
            return $"ID-{Id} Name:{Name} Marks:{Marks}";
        }
    }
    class StudentManager
    {
        Dictionary<int, Student> studentdata = new Dictionary<int, Student>();
        public bool AddStudent(Student student) { 


           int id = student.Id;
            if (!studentdata.ContainsKey(id))
            {
                studentdata.Add(id, student);
                return true;
            }
            return false;
            
        }
        public bool UpdateStudent(int id,int marks)
        {
            Student foundstudent = SearchStudentId(id);
            if (foundstudent != null)
            {
                foundstudent.Marks = marks;
                return true;
            }
            return false;
        }
        public bool DeleteStudent(int id)
        {
            Student foundstudent = SearchStudentId(id);
            if (foundstudent != null)
            {
                studentdata.Remove(id);
                return true;

            }
            return false;
        }
        public Student SearchStudentId(int id)
        {
            Student student = null;
            bool found = studentdata.TryGetValue(id, out student);
            //if (studentdata.ContainsKey(id))
            //{
            //    return Id;
            //}
            return student;
        }
        
        public void DisplayAllStudents()
        {
            foreach(var student in studentdata)
            {
                Console.WriteLine(student.Value);
            }

        }
        

        }
    }
    internal class Studentmanagement
    {
        static void Main(string[] args)
        {
        StudentManager manager = new StudentManager();
        manager.AddStudent(
            new Student()
            {
                Id = 111,
                Name = "Rajiv",
                Marks = 80,

            });
        manager.AddStudent(
             new Student()
             {
                 Id = 112,
                 Name = "kunal",
                 Marks = 90,

             });
        manager.DisplayAllStudents();
        Console.WriteLine("---------------------------------");
        int searchid = 111;
       
        Student foundstudent = manager.SearchStudentId(searchid);
        if (foundstudent == null)
        {
            Console.WriteLine($"student {searchid}  not found");
        }
        else
            Console.WriteLine($"student found with id :{foundstudent}");
        Console.WriteLine("---------------------------------");

        bool updated=  manager.UpdateStudent(111, 95);
        if (updated)
        {
            Console.WriteLine($"Updated student information:{manager.SearchStudentId(111)}");
        }
        else
            Console.WriteLine("student data not updated");
        Console.WriteLine("---------------------------------");

        bool deleted = manager.DeleteStudent(searchid);
        if (deleted) {
            Console.WriteLine($"student with searchId {searchid} data deleted");
        }
        else
        {
            Console.WriteLine($"student with searchId {searchid} is not  deleted");

        }
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Available Data of students in the database");
        
        manager.DisplayAllStudents();

    }
}
