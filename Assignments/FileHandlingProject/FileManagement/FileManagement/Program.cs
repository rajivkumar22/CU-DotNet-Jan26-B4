namespace FileManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string directory = @"..\..\..\";
            if (!Directory.Exists(directory))
            {
                Console.WriteLine("directory does not exist");
                return;
            }
            
            string file1 = "data.txt";
            string path = file1 + directory;
            if (!File.Exists(file1))
            {
                Console.WriteLine("file does not exists");

            }
            //FileStream fs = new FileStream(file1,FileMode.Create);
            StreamReader sr = new StreamReader(path);
            do
            {
                {
                    string reader = sr.ReadLine();
                    if (reader == null)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine(reader);
                    }
                }
            } while (true);

            StreamWriter sw = new StreamWriter(path,true);
            do
            {
                Console.WriteLine("enter csv file");
                string data = Console.ReadLine();
                if (data == "stop")
                {
                    break;

                }
                else
                {
                    sw.WriteLine(data);
                }

            } while (true);
        }
    }
}
