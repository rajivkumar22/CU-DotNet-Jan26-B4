namespace MemorialBillingEngine
{
    internal class Program
    {
        class Patient
        {
            public string Name { get; set; }
            public decimal BaseFare { get; set; }


            public virtual decimal CalculateFinalBill()
            {
                return BaseFare;
            }
        }
        class Inpatient : Patient
        {
            public int DaysStayed { get; set; }
            public decimal DailyRate { get; set; }
            public override decimal CalculateFinalBill()
            {
                return BaseFare + (DaysStayed * DailyRate);
            }

        }
        class Outpatient : Patient
        {
            public decimal ProcedureFee { get; set; }
            public override decimal CalculateFinalBill()
            {
                return BaseFare + ProcedureFee;
            }
        }
        class EmergencyPatient : Patient {
            public int SeverityLevel { get; set; }
            public override decimal CalculateFinalBill()
            {
                return BaseFare * SeverityLevel;
            }
        }
        class HospitalBilling
        {
            List<Patient> patients = new List<Patient>();
            public void AddPatient(Patient p)
            {
                patients.Add(p);
            }
            public void GenerateDailyReport()
            {
                foreach (var patient in patients)
                {
                    Console.WriteLine($"Name of the patient:{patient.Name} bill:{patient.CalculateFinalBill():C2}");
                }
            }
            public decimal CalculateTotalRevenue()
            {
                decimal totalbill = 0m;
                foreach (var patient in patients)
                {
                    totalbill += patient.CalculateFinalBill();
                }
                return totalbill;
            }

            public int GetInpatientCount()
            {
                int count = 0;
                foreach (var p in patients)
                {
                    if (p is Inpatient)
                    {
                        count++;
                    }
                }
                return count;

            }
        }

            



            static void Main(string[] args)
            {
                HospitalBilling HB = new HospitalBilling();
                HB.AddPatient(
                    new Patient()
                    {
                        BaseFare = 1000,
                        Name = "MATIL"
                    });
                HB.AddPatient(
                   new Patient()
                   {
                       BaseFare = 500,
                       Name = "kiran"
                   });
                HB.AddPatient(
                   new Inpatient()
                   {
                       Name = "Monik",
                       BaseFare = 900,
                       DailyRate = 100,
                       DaysStayed = 5
                   });
            HB.AddPatient(
                 new Inpatient()
                 {
                     Name = "ashish",
                     BaseFare = 1000,
                     DailyRate = 500,
                     DaysStayed = 5
                 });
            HB.AddPatient(
                  new Outpatient()
                  {
                      Name = "ounik",
                      BaseFare = 1200,
                      ProcedureFee = 130

                  });
                HB.AddPatient(
                new EmergencyPatient()
                {
                    Name = "rishikesh",
                    BaseFare = 1200,
                    SeverityLevel = 2

                });
                HB.GenerateDailyReport();
            decimal Revenue = HB.CalculateTotalRevenue();
            Console.WriteLine($"Total Revenue is:{ Revenue:C2}");
            Console.WriteLine($"Total number of Inpatient in hospital is:  {HB.GetInpatientCount()}");

            }
        }
        
    }

