namespace HackerLandCricketLeague
{
    class Player
    {
        public string Name { get; set; }
        public int RunsScored { get; set; }
        public int BallsFaced { get; set; }

        public bool IsOut { get; set; }
        public double StrikeRate { get; set; }
        public double Average { get; set; }

        public void CalculateStats()
        {
            if (BallsFaced == 0)
            {
                StrikeRate = 0;
            }
            else
                StrikeRate = ((double)RunsScored / BallsFaced) * 100;

            if (!IsOut)
            {
                Average = RunsScored;
            }
            else
                Average = RunsScored;
        }


    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Player Information:");

            string Path = @"..\..\..\Player.csv";
            Console.WriteLine("Enter the number of players stats you want");
            int range = int.Parse(Console.ReadLine());
            using (StreamWriter sw = new StreamWriter(Path, true))
            {
                for (int i = 0; i < range; i++)
                {
                    Console.WriteLine($"Enter player {i + 1} information:");
                    string input = Console.ReadLine();
                    sw.WriteLine(input);
                }


            }
            List<Player> players = new List<Player>();
            try
            {
                if (!File.Exists(Path))
                {
                    throw new FileNotFoundException();

                }
                using (StreamReader sr = new StreamReader(Path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {

                        string[] parts = line.Split(',');
                        if (parts.Length != 4)
                        {
                            Console.WriteLine("Invalid line format in file.");
                            continue;
                        }
                        try
                        {
                            string name = parts[0].Trim();
                            int runsscored = int.Parse(parts[1].Trim());
                            int ballfaced = int.Parse(parts[2].Trim());
                            bool isout = bool.Parse(parts[3].Trim());

                            Player player = new Player
                            {

                                Name = name,
                                RunsScored = runsscored,
                                BallsFaced = ballfaced,
                                IsOut = isout


                            };
                            player.CalculateStats();

                            if (player.BallsFaced >= 10)
                            {
                                players.Add(player);
                            }



                        }

                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid data format found in User input");
                        }
                        catch (DivideByZeroException)
                        {
                            Console.WriteLine("Division by zero error in strike rate calculation.");
                        }
                    }
                }

                players = players
                   .OrderByDescending(p => p.StrikeRate)
                   .ToList();

                Console.WriteLine("\nName            Runs    SR      Avg");
                Console.WriteLine("----------------------------------------");

                foreach (var player in players)
                {
                    Console.WriteLine($"{player.Name,-15} {player.RunsScored,-7} {player.StrikeRate,-7:F2} {player.Average,-7:F2}");
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("CSV file is Mising");
            }







        }
    }
}
