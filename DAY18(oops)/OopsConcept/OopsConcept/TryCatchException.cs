using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsConcept
{
    class InvalidStudentAgeException : Exception { 
       
    }


    internal class TryCatchException
    {
        static void Main(string[] args)
        {
           
            try
            {
                Console.WriteLine("Enter Two Number");
                int x = int.Parse(Console.ReadLine());
                int y = int.Parse(Console.ReadLine());
                int result = x / y;

                
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("exception caught:Can not divide a number by zero");
            }
            catch (FormatException)
            {
                Console.WriteLine("Please Enter the integer value only ");
            }
            
            try
            {
                int[] arr = { 1, 2, 3, 4 };
                int num = arr[5];
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("IndexOutofRangeException");
            }
            finally
            {
                Console.WriteLine("Operation Completed");

            }



        }
    }
}
