

using System.Collections;

namespace EverdayPractice
{
   
    internal class LegacyEmployeeDirectory
    {
        static void Main(string[] args)
        {
            Hashtable employeeTable = new Hashtable();
            employeeTable.Add(101, "ALICE");
            employeeTable.Add(102, "Bob");
            employeeTable.Add(103, "Charlie");
            employeeTable.Add(104, "Diana");
            if (employeeTable.ContainsKey(105))
            {
                Console.WriteLine("ID already exists");
            }
            else
            {
                employeeTable.Add(105, "Edward");
            }
            if (employeeTable.ContainsKey(102))
            {
                string name = (string)( employeeTable[102]);
                Console.WriteLine(name);
            }
            

            foreach( DictionaryEntry item  in employeeTable)
            {
                Console.WriteLine($"Key:{item.Key} Value:{item.Value}");

            }
            
           
                if (employeeTable.ContainsKey(103))
                {
                    employeeTable.Remove(103);
                }
                



            Console.WriteLine($"Total employees :{employeeTable.Count}");
           


        }
    }
}
