



namespace Day15Project
{
    class ApplicationConfig
    {
        public static string ApplicationName { get; set; }
        public static string Environment { get; set; }
       public static int AccessCount { get; set; }
        public static bool IsInitialized { get; set; }
        static ApplicationConfig()
        {
            ApplicationName = "MyApp";
           Environment = "Development";
            AccessCount = 0;
            IsInitialized = false;
            Console.WriteLine("Static constructor executed");

        }
        public static void Initialize(string appName, string environment)
        {
            ApplicationName = appName;
            Environment = environment;
            IsInitialized = true;
            AccessCount++;
        }
        //public override string ToString()
        //{
        //    AccessCount++;
        //    return $"ApplicationName:{ApplicationName} Environment:{Environment} Accesscount:{AccessCount}";
        //}
        public static string GetConfigurationSummary()
        {
            AccessCount++;
            return $"ApplicationName:{ApplicationName} Environment:{Environment} Accesscount:{AccessCount}";
        }
        public static void ResetConfiguration()
        {
            ApplicationName = "MyApp";
            Environment = "Development";
            AccessCount = 0;
            IsInitialized = false;
        }

    } 
    internal class Tracker
    {
        public static void Main(string[] args)
        {
           // ApplicationConfig obj1 = new ApplicationConfig();
            Console.WriteLine(ApplicationConfig.ApplicationName);
            ApplicationConfig.Initialize("APP1","DEV");
            
            Console.WriteLine(ApplicationConfig.GetConfigurationSummary());
            ApplicationConfig.ResetConfiguration();
            Console.WriteLine(ApplicationConfig.GetConfigurationSummary());



        }

    }
}
