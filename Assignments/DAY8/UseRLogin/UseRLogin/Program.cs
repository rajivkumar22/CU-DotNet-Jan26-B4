namespace UseRLogin
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter UserName and Message: ");
            string input = Console.ReadLine();
            string[] parts = input.Split('|');
            string userName = parts[0];
            string rawMessage = parts[1];
            string cleanedMessage = rawMessage.Trim().ToLower();
            string standardmessage = "login successful";
            string status;
            if (!cleanedMessage.Contains("successful"))
            {
                status = "LOGIN FAILED";
            }
            else if (cleanedMessage.Equals(standardmessage))
            {
                status = "LOGIN SUCCESS";
            }
            else
            {
                status = "LOGIN SUCCESS (CUSTOM MESSAGE)";
            }
            Console.WriteLine($"User     :  {userName}");
            Console.WriteLine($"Message  :{ cleanedMessage}");
            Console.WriteLine($"Status   :{ status}");
        }
    }
}
