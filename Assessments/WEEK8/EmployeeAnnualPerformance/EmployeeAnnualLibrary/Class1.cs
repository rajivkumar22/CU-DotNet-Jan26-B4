namespace EmployeeAnnualLibrary
{
    public class Class1
    {
        public decimal BaseSalary { get; set; }
        public int PerformanceRating { get; set; }
        public int YearsOfExperience { get; set; }
        public decimal DepartmentMultiplier { get; set; }
        public double AttendencePercentage { get; set; }

        public decimal NetAnnualBonus
        {
            get
            {
                if (BaseSalary <= 0)
                {
                    return 0m;
                }
                decimal bonus = 0m;
                switch (PerformanceRating)
                {
                    case 1:

                        bonus = BaseSalary * 0m;
                        break;
                    case 2:

                        bonus = BaseSalary * 0.05m;
                        break;
                    case 3:

                        bonus = BaseSalary * .12m;
                        break;
                    case 4:

                        bonus = BaseSalary * 0.18m;
                        break;
                    case 5:

                        bonus = BaseSalary * 0.25m;
                        break;

                    default:
                        throw new InvalidOperationException("Rating must be between:(1-5)");

                }
                if (YearsOfExperience > 10)
                    bonus += BaseSalary * 0.05m;
                else if (YearsOfExperience > 5)
                    bonus += BaseSalary * 0.03m;

                if (AttendencePercentage < 85)
                {
                    bonus *= 0.8m;

                }
                bonus = bonus * DepartmentMultiplier;
                decimal totalbonus = BaseSalary * 0.4m;
                if (bonus > totalbonus)
                {
                    bonus = totalbonus;
                }
                decimal taxrate;
                if (bonus <= 150000m)
                    taxrate = 0.10m;
                else if (bonus <= 300000m)
                    taxrate = 0.20m;
                else
                    taxrate = 0.30m;

                decimal taxamount = bonus * taxrate;
                decimal finalbonus = bonus - taxamount;
                return Math.Round(finalbonus, 2);




            }

        }
    }
}
