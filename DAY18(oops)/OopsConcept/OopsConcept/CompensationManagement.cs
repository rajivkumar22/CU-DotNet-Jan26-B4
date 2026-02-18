

namespace OopsConcept
{
    class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public decimal BasicSalary { get; set; }
        public int ExperienceInYears { get; set; }
       
        //public Employee()
        //{

        //}

        public Employee(int employeeid, string employeename, decimal basicsalary, int experienceinyear)
        {
            EmployeeId = employeeid;
            EmployeeName = employeename;
            BasicSalary = basicsalary;
            ExperienceInYears = experienceinyear;
        }


        public decimal CalculateAnnualSalary()
        {
            decimal AnnualSalary = BasicSalary * 12;
            return AnnualSalary;

        }
        public void DisplayEmployeeDetails()
        {
            Console.WriteLine($" EmployeeId = {EmployeeId} EmployeeName = {EmployeeName}  BasicSalary ={BasicSalary}  ExperienceInYears ={ExperienceInYears}");

        }
    }

     class PermanentEmployee: Employee
    {
        public PermanentEmployee(int employeeId, string employeeName, decimal basicSalary, int experienceInYears)
                    : base(employeeId, employeeName, basicSalary, experienceInYears)
        {
        }
        public new decimal CalculateAnnualSalary()
        {
            decimal hra = BasicSalary * 0.20m;
            decimal loyaltyBonus = 0;
            decimal specialAllowance = BasicSalary * 0.10m;
            if (ExperienceInYears >= 5)
            {
                 loyaltyBonus = 50000;
            }
    
            return (BasicSalary + hra + specialAllowance) * 12 + loyaltyBonus;
        }
    }
    class ContractEmployee : Employee
    {
        public int ContractDurationInMonths { get; set; }
        public ContractEmployee(int employeeId, string employeeName,decimal basicSalary, int experienceInYears,int contractDurationInMonths)
                    :base(employeeId, employeeName, basicSalary, experienceInYears)
        {
            ContractDurationInMonths = contractDurationInMonths;
        }

        decimal bonus = 0;
        public new decimal CalculateAnnualSalary()
        {
            if (ContractDurationInMonths >= 12)
            {
                bonus = 30000;
            }
            return (BasicSalary * 12) + bonus;
        }
    }
    class InternEmployee : Employee
    {
        public InternEmployee(int employeeId, string employeeName,decimal basicSalary, int experienceInYears)
                      : base(employeeId, employeeName, basicSalary, experienceInYears)
        {
        }
        public new decimal CalculateAnnualSalary()
        {
            return BasicSalary * 12;
        }
    }





        internal class CompensationManagement
    {
        static void Main(string[] args)
        {
            Employee emp1 = new PermanentEmployee(1, "Rajiv", 50000, 6);
            PermanentEmployee pe = new PermanentEmployee(2, "Amit", 50000, 6);
            ContractEmployee ce = new ContractEmployee(3, "Neha", 40000, 4, 14);
            InternEmployee ie = new InternEmployee(1, "sanjiv", 10000, 6);
            Console.WriteLine(emp1.CalculateAnnualSalary());
            Console.WriteLine(pe.CalculateAnnualSalary());



        }
    }
}
