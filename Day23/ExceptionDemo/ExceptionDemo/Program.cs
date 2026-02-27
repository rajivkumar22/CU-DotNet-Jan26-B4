namespace ExceptionDemo
{
    internal class Program
    {
        class InvalidStudentAgeException : Exception
        {
            public InvalidStudentAgeException(string message) :base(message) { }
        }
        class InvalidStudentNameException : Exception
        {
            public InvalidStudentNameException(string message) : base(message) { }
        }
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter the two numbers");
                int a = int.Parse(Console.ReadLine());
                int b= int.Parse(Console.ReadLine());
                int dividetwonumber = a / b;
                

            }
            catch(DivideByZeroException)
            {
                Console.WriteLine("Cannot divide a number by zero");
            }
           
            finally
            {
                Console.WriteLine("Operation Completed");
            }

            // user input to integer

            try
            {
                Console.WriteLine("Enter a number");
                int input = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Please Enter valid integer value");
            }
            finally
            {
                Console.WriteLine("Operation completed");
            }
            try
            {
                Console.WriteLine("Enter an index to access element in an array");
                int[] arr = { 1, 2, 3, 4, 5 };
                int checkindex = int.Parse(Console.ReadLine());
                Console.WriteLine(arr[checkindex]);

            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("please enter a valid index");
            }
            finally
            {
                Console.WriteLine("Operation completed");
            }

            while (true)
            {
                try
                {
                    Console.WriteLine("Enter the student name");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter student Age");
                    int age = int.Parse(Console.ReadLine());
                    if (age < 18 || age > 60)
                    {
                        throw new InvalidStudentAgeException("Age must be between 18 and 60");
                    }
                    if (string.IsNullOrWhiteSpace(name))
                        throw new InvalidStudentNameException("Student name cannot be empty.");
                    Console.WriteLine("Student Registered Successfully!");
                    break;

                }
                catch (InvalidStudentAgeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(InvalidStudentNameException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            try
            {
                try
                {
                    int testAge = 10; 

                    if (testAge < 18 || testAge > 60)
                    {
                        throw new InvalidStudentAgeException("Age must be between 18 and 60.");
                    }
                }
                catch (InvalidStudentAgeException ex)
                {
                    
                    throw new Exception("Student Enrollment Failed.", ex);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Message: " + ex.Message);

                if (ex.InnerException != null)
                {
                    Console.WriteLine("Inner Exception Message: " + ex.InnerException.Message);
                }

                Console.WriteLine("StackTrace:");
                Console.WriteLine(ex.StackTrace);
            }







        }
    }
}
