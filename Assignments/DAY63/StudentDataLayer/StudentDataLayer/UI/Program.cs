using StudentDataLayer.Models;
using StudentDataLayer.Repositories;
using StudentDataLayer.Services;

namespace StudentDataLayer.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Adaptive Student Data Layer ===\n");
            Console.WriteLine("Choose storage method:");
            Console.WriteLine("1. In-Memory (List - data lost on exit)");
            Console.WriteLine("2. JSON File (data persists across runs)");
            Console.Write("Enter choice (1 or 2): ");

            string choice = Console.ReadLine()?.Trim() ?? "1";
            IStudentRepository repository = choice == "2"
                ? new JsonStudentRepository()
                : new ListStudentRepository();

            var service = new StudentService(repository);

            Console.WriteLine($"\nUsing {(choice == "2" ? "JSON" : "In-Memory")} storage.\n");

            bool running = true;
            while (running)
            {
                Console.WriteLine("\n=== MENU ===");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. List All Students");
                Console.WriteLine("3. Update Student");
                Console.WriteLine("4. Delete Student");
                Console.WriteLine("5. Exit");
                Console.Write("Choose option: ");

                string? option = Console.ReadLine()?.Trim();

                try
                {
                    switch (option)
                    {
                        case "1":
                            AddStudent(service);
                            break;
                        case "2":
                            ListStudents(service);
                            break;
                        case "3":
                            UpdateStudent(service);
                            break;
                        case "4":
                            DeleteStudent(service);
                            break;
                        case "5":
                            running = false;
                            Console.WriteLine("Goodbye!");
                            break;
                        default:
                            Console.WriteLine("Invalid option!");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR: {ex.Message}");
                }
            }
        }

        private static void AddStudent(StudentService service)
        {
            Console.WriteLine("Enter ID");
            int Id = int.Parse(Console.ReadLine());
            Console.Write("Enter Name: ");
            string name = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Enter Grade (0-100): ");
            if (!double.TryParse(Console.ReadLine(), out double grade))
            {
                Console.WriteLine("Invalid grade!");
                return;
            }

            var student = new Student {Id=Id, Name = name, Grade = grade };
            service.AddStudent(student);
            Console.WriteLine($"✅ Student added successfully! ID = {student.Id}");
        }

        private static void ListStudents(StudentService service)
        {
            var students = service.GetAllStudents().ToList();
            if (!students.Any())
            {
                Console.WriteLine("No students found.");
                return;
            }

            foreach (var s in students)
            {
                Console.WriteLine($"ID: {s.Id} | Name: {s.Name} | Grade: {s.Grade}");
            }
        }

        private static void UpdateStudent(StudentService service)
        {
            Console.Write("Enter Student ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID!");
                return;
            }

            var existing = service.GetStudentById(id);
            if (existing == null)
            {
                Console.WriteLine("Student not found!");
                return;
            }

            Console.Write($"New Name (current: {existing.Name}): ");
            string name = Console.ReadLine()?.Trim() ?? existing.Name;

            Console.Write($"New Grade (current: {existing.Grade}): ");
            if (!double.TryParse(Console.ReadLine(), out double grade))
                grade = existing.Grade;

            var updated = new Student { Id = id, Name = name, Grade = grade };
            service.UpdateStudent(updated);
            Console.WriteLine("✅ Student updated successfully!");
        }

        private static void DeleteStudent(StudentService service)
        {
            Console.Write("Enter Student ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID!");
                return;
            }

            service.DeleteStudent(id);
            Console.WriteLine("✅ Student deleted (if it existed).");
        }
    }
    }

