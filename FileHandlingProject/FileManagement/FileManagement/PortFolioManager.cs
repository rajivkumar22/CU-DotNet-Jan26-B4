using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagement
{
    public class Loan {
        public string ClientName { get; set; }
        public double Principal { get; set; }
        public double InterestRate { get; set; }



    }

    internal class PortFolioManager
    {
        static void Main(string[] args)
        {
            string filepath = @"..\..\..\loan.csv";
            bool fileexist = File.Exists(filepath);
            using (StreamWriter sw = new StreamWriter(filepath, true))
            {
                if (!fileexist)
                {
                    sw.WriteLine("ClientName,Principal,InterestRate");
                }

                    Console.WriteLine("enter client name");
                    string name = Console.ReadLine();
                    Console.WriteLine("enter Principal");
                    string pinput = Console.ReadLine();
                    Console.WriteLine("enter interest Rate");
                    string rinput = Console.ReadLine();
                    sw.WriteLine($"{name}, {pinput}, {rinput}");
                

            }
            
            List<Loan> loans = new List<Loan>();
            using (StreamReader sr = new StreamReader(filepath))
            {
                string line;
                sr.ReadLine();
               
                while ((line = sr.ReadLine()) != null)
                {
                    string[] str = line.Split(',');
                    if (str.Length == 3 && double.TryParse(str[1], out double principal)&& double.TryParse(str[2], out double interestRate))
                    {
                        Loan add = new Loan();
                        add.ClientName = str[0];
                        add.Principal = principal;
                        add.InterestRate = interestRate;
                        loans.Add(add);
                        
                    }
                }
            }

          Console.WriteLine("CLIENT |PRINCIPAL |INTEREST | RISKLEVEL");
            Console.WriteLine("--------------------------------------");
            string risk;
            foreach(Loan loan in loans)
            {
                double interestvalue = (loan.Principal * loan.InterestRate / 100);
                if (loan.InterestRate > 10)
                {
                    risk = "High Risk";
                }
                else if (loan.InterestRate >= 5 && loan.InterestRate <= 10)
                {
                    risk = "Medium Risk";
                }
                else
                    risk = "LowRisk";
                Console.WriteLine($"{loan.ClientName} | {loan.Principal} | {interestvalue} | {risk}");
            }




            }
        }
    }

