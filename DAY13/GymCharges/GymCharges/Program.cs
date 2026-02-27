using System;

namespace GymCharges
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool treadmill = true;
            bool weightLifting = false;
            bool zumba = true;

            decimal totalAmount = CalculateMembershipAmount(treadmill, weightLifting, zumba);
            Console.WriteLine($"Total Monthly Membership Amount: Rs. {totalAmount}");
        }

        static decimal CalculateMembershipAmount(bool treadmill, bool weightLifting, bool zumba)
        {
            const decimal fixedCharges = 1000;
            const decimal treadmillCharge = 300;
            const decimal weightLiftingCharge = 500;
            const decimal zumbaCharge = 250;
            const decimal gstRate = 0.05m;
            decimal amount = fixedCharges;

            if (!treadmill && !weightLifting && !zumba)
            {
                amount += 200;
            }
            else
            {
                if (treadmill) amount += treadmillCharge;
                if (weightLifting) amount += weightLiftingCharge;
                if (zumba) amount += zumbaCharge;
            }

            amount += amount * gstRate;

            return amount;
        }
    }
}