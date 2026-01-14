

namespace CsharpLearning
{
    internal class SmartAcessProcessor
    {
        static void Main()
        {
            Console.WriteLine("Please Enter the Information:");
            string input = Console.ReadLine();
            string[] inputs = input.Split('|');
            string GateCode = inputs[0];
             char  UserInitial = char.Parse(inputs[1]);

            byte  AccessLevel = byte.Parse(inputs[2]);
            bool IsActive = bool.Parse(inputs[3]);
            byte Attempts = byte.Parse(inputs[4]);
            if (GateCode.Length != 2 ||
                !char.IsUpper(UserInitial) || 
                !char.IsDigit(GateCode[1])||!char.IsLetter(GateCode[0])||
                AccessLevel<1||AccessLevel>7||Attempts>200){
                Console.WriteLine("Invalid Access Log");
                return;
            }
            string status;
            if (!IsActive)
            {
                status= "ACCESS DENIED – INACTIVE USER";

            }
            else if (Attempts > 100)
                {
                    status = "ACCESS DENIED – TOO MANY ATTEMPTS";
                }
            else if (AccessLevel >= 5)
            {
                status= "ACCESS GRANTED – HIGH SECURITY";
            }
            else
                status = "ACCESS GRANTED – STANDARD";


            Console.WriteLine($"{"Gate"}: {GateCode}");
            Console.WriteLine($"{"User"}: {UserInitial}");
            Console.WriteLine($"{"Level"}: {AccessLevel}");
            Console.WriteLine($"{"Attempts"}: {Attempts}");
            Console.WriteLine($"{"Status"}: {status}");




        }
    }
}
