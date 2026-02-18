

namespace OopsConcept
{
    class Loan
    {
       public Loan()
        {
            LoanNumber = string.Empty;
            CustomerName = string.Empty;
            PrincipalAmount = 10000;
            TenureInYears = 2;

        }
        public string LoanNumber { get; set; }
        public string CustomerName { get; set; }
        public  decimal PrincipalAmount  { get; set; }
        public int TenureInYears{ get; set; }
        public Loan(string loannumber,string customername,decimal principalamount,int tenureinyear)
        {
            LoanNumber = loannumber;
            CustomerName = customername;
            PrincipalAmount = principalamount;
            TenureInYears = tenureinyear;
        }
        
        public decimal CalculateEMI()
        {
            return (PrincipalAmount *10* TenureInYears) / 100;
        }
    }
    class HomeLoan : Loan {
        
        public new decimal CalculateEMI()
        {
            return (PrincipalAmount * 8 * TenureInYears) / 100;


        }
    }
    class CarLoan : Loan {
        public new decimal CalculateEMI()
        {
            return (PrincipalAmount * 9 * TenureInYears) / 100;


        }
    }


    internal class LoanCalculation
    {
        static void Main(string[] args)
        {
           // Loan l1 = new Loan("ib1", "r1", 10000, 2);
            Loan[] loan = new Loan[4] { 
                new HomeLoan(),
                new HomeLoan(),
                new CarLoan(),
                new CarLoan()
            };
            for(int i = 0; i < loan.Length; i++)
            {
                Console.WriteLine( loan[i].CalculateEMI());
            }



        }
    }
}
