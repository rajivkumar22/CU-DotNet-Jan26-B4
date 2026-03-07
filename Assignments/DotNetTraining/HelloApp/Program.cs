using System;
class Program
{
    static void Main()
    {
        /*
         * Exercise 1: Student Attendance & Eligibility System
         * A college tracks attendance for each subject. Attendance is captured daily as integers.
         * At the end of the semester, attendance percentage is calculated as a double.
         * University rules state that eligibility must be displayed as an integer percentage.
         * 
         * Explanation:
         * Attendance count is stored as int because days are whole numbers.
         * Percentage needs decimal precision so double is used.
         * For eligibility display, double is converted to int using rounding or truncation.
         * Rounding gives nearest value.
         * Truncation removes decimal part and may reduce percentage.
         */
        Console.WriteLine("--- Exercise 1: Student Attendance & Eligibility System ---");
        int totalDays = 100;
        int presentDays = 82;
        double percentage = presentDays * 100.0 / totalDays;
        int eligibility = (int)Math.Round(percentage);
        Console.WriteLine("Total Days: " + totalDays);
        Console.WriteLine("Present Days: " + presentDays);
        Console.WriteLine("Eligibility (int): " + eligibility);
        Console.WriteLine();

        /*
         * Exercise 2: Online Examination Result Processing
         * An online exam system stores marks per subject as int.
         * The final average must be shown with two decimal places.
         * Later, scholarship eligibility requires converting the average into an int.
         * 
         * Explanation:
         * Marks are integers but average needs decimal precision so double is used.
         * Converting double to int removes decimal part.
         * This causes loss of precision which affects scholarship decision.
         */
        Console.WriteLine("--- Exercise 2: Online Examination Result Processing ---");
        int s1 = 75;
        int s2 = 82;
        int s3 = 90;
        double avg = (s1 + s2 + s3) / 3.0;
        int check = (int)avg;
        Console.WriteLine("Subject 1: " + s1);
        Console.WriteLine("Subject 2: " + s2);
        Console.WriteLine("Subject 3: " + s3);
        Console.WriteLine("Average (double): " + avg);
        Console.WriteLine("Scholarship Check (int): " + check);
        Console.WriteLine();

        /*
         * Exercise 3: Library Fine Calculation System
         * Fine per day is configured as decimal.
         * Days overdue are stored as int.
         * Total fine must be displayed as decimal but logged as double for analytics.
         * 
         * Explanation:
         * Decimal is used for money to avoid rounding errors.
         * Days are whole numbers so int is used.
         * Double is used only for analytical calculations.
         */
        Console.WriteLine("--- Exercise 3: Library Fine Calculation System ---");
        decimal fine = 3.5m;
        int days = 6;
        decimal totalFine = fine * days;
        double logFine = (double)totalFine;
        Console.WriteLine("Fine per Day (decimal): " + fine);
        Console.WriteLine("Days Overdue (int): " + days);
        Console.WriteLine("Total Fine (decimal): " + totalFine);
        Console.WriteLine("Analytics Log (double): " + logFine);
        Console.WriteLine();

        /*
         * Exercise 4: Banking Interest Calculation Module
         * Account balance is decimal.
         * Interest rate is float from an external API.
         * Monthly interest is calculated and added to balance.
         * 
         * Explanation:
         * Balance uses decimal for accuracy in financial values.
         * Interest rate comes as float so explicit conversion is required.
         * Implicit conversion fails between float and decimal.
         */
        Console.WriteLine("--- Exercise 4: Banking Interest Calculation Module ---");
        decimal balance = 20000m;
        float rate = 6.5f;
        decimal interest = balance * (decimal)rate / 100;
        balance = balance + interest;
        Console.WriteLine("Initial Balance (decimal): 20000");
        Console.WriteLine("Interest Rate (float): " + rate + "%");
        Console.WriteLine("Interest Earned: " + interest);
        Console.WriteLine("New Balance (decimal): " + balance);
       

        /*
         * Exercise 5: E-Commerce Order Pricing Engine
         * Cart total is accumulated using double.
         * Tax and discount rules require decimal.
         * Final payable amount is stored as decimal.
         * 
         * Explanation:
         * Cart total comes from calculations so double is used.
         * Tax and discount need high precision so decimal is used.
         * Final amount is converted to decimal to avoid precision loss.
         */
        Console.WriteLine("--- Exercise 5: E-Commerce Order Pricing Engine ---");
        double cartTotal = 1500.75;
        decimal tax = 0.12m;
        decimal discount = 200m;
        decimal finalAmount = (decimal)cartTotal;
        finalAmount += finalAmount * tax;
        finalAmount -= discount;
        Console.WriteLine("Cart Total (double): " + cartTotal);
        Console.WriteLine("Tax Rate (decimal): " + tax);
        Console.WriteLine("Discount (decimal): " + discount);
        Console.WriteLine("Final Amount (decimal): " + finalAmount);
    

        /*
         * Exercise 6: Weather Monitoring & Reporting
         * Temperature sensors send readings as short.
         * Values must be converted to Celsius and stored as double.
         * Daily average is converted to int for dashboard display.
         * 
         * Explanation:
         * Sensor data is small so short is used.
         * Double is used for temperature calculation.
         * Casting to int may cause overflow if values are not checked.
         */
        Console.WriteLine("--- Exercise 6: Weather Monitoring & Reporting ---");
        short r1 = 310;
        short r2 = 330;
        double avgTemp = (r1 + r2) / 2.0;
        int displayTemp = (int)Math.Round(avgTemp);
        Console.WriteLine("Reading 1 (short): " + r1);
        Console.WriteLine("Reading 2 (short): " + r2);
        Console.WriteLine("Average Temperature (double): " + avgTemp);
        Console.WriteLine("Dashboard Display (int): " + displayTemp);
        Console.WriteLine();

        /*
         * Exercise 7: University Grading Engine
         * Final score is calculated as double.
         * Grades are stored as byte values.
         * Design logic to convert score to grade safely.
         * 
         * Explanation:
         * Score needs decimal precision so double is used.
         * Grades are small fixed values so byte is enough.
         * Conditional checks ensure safe conversion.
         */
        Console.WriteLine("--- Exercise 7: University Grading Engine ---");
        double score = 88.5;
        byte grade;
        if (score >= 90) grade = 10;
        else if (score >= 80) grade = 9;
        else if (score >= 70) grade = 8;
        else grade = 7;
        Console.WriteLine("Final Score (double): " + score);
        Console.WriteLine("Grade Value (byte): " + grade);
        Console.WriteLine();

        /*
         * Exercise 8: Mobile Data Usage Tracker
         * Usage is tracked in bytes as long.
         * Displayed in MB and GB as double.
         * Monthly summary rounds values to nearest integer.
         * 
         * Explanation:
         * Bytes can be very large so long is used.
         * MB and GB need division so double is used.
         * Rounding gives correct usage summary.
         */
        Console.WriteLine("--- Exercise 8: Mobile Data Usage Tracker ---");
        long data = 7340032;
        double mb = data / (1024.0 * 1024);
        int summary = (int)Math.Round(mb);
        Console.WriteLine("Data Usage (long bytes): " + data);
        Console.WriteLine("Usage in MB (double): " + mb);
        Console.WriteLine("Monthly Summary (int): " + summary + " MB");
        Console.WriteLine();

        /*
         * Exercise 9: Warehouse Inventory Capacity Control
         * Item count stored as int.
         * Maximum capacity stored as ushort.
         * Conversion required during comparison and reporting.
         * 
         * Explanation:
         * Item count can be negative so int is used.
         * Capacity is always positive so ushort is used.
         * Comparison must avoid signed and unsigned mismatch.
         */
        Console.WriteLine("--- Exercise 9: Warehouse Inventory Capacity Control ---");
        int items = 650;
        ushort capacity = 800;
        bool status = items <= capacity;
        Console.WriteLine("Current Items (int): " + items);
        Console.WriteLine("Max Capacity (ushort): " + capacity);
        Console.WriteLine("Within Capacity: " + status);
        Console.WriteLine();

        /*
         * Exercise 10: Payroll Salary Computation
         * Basic salary is int.
         * Allowances and deductions are double.
         * Net salary stored as decimal.
         * 
         * Explanation:
         * Basic salary is whole value so int is used.
         * Allowances and deductions may have decimals.
         * Decimal is used for final salary accuracy.
         */
        Console.WriteLine("--- Exercise 10: Payroll Salary Computation ---");
        int basic = 28000;
        double allowance = 4500.25;
        double deduction = 1350.75;
        decimal netSalary = basic + (decimal)allowance - (decimal)deduction;
        Console.WriteLine("Basic Salary (int): " + basic);
        Console.WriteLine("Allowance (double): " + allowance);
        Console.WriteLine("Deduction (double): " + deduction);
        Console.WriteLine("Net Salary (decimal): " + netSalary);
        
    }
}
