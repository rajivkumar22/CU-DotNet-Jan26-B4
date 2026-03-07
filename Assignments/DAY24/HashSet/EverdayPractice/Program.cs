using System.Threading.Channels;

namespace EverdayPractice
{
    class Check {
        public static int[] FillArray()
        {
           // int n = int.Parse(Console.ReadLine());
            int[,] arr = new int[5 ,5]
             {
            { 1, 2, 3, 4, 5 },
            { 6, 7, 8, 9, 10 },
            { 11, 12, 13, 14, 15 },
            { 16, 17, 18, 19, 20 },
            { 21, 22, 23, 24, 25 }
            };
            int size = arr.GetLength(0) + arr.GetLength(1);
            int[] arr1 = new int[size];
            int k = 0;
            for(int i=0;i< arr.GetLength(0); i++)
            {
                for (int j= 0; j < arr.GetLength(1); j++)
                {
                    arr1[k] = arr[i,j];
                    Console.Write(arr1[k] +",");
                }

            }

            List<int> ar = new List<int>();

        
            foreach(var i in arr){
                ar.Add(i);


            }
            return ar.ToArray();
           
            

        }
        
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
           int[] newarr= Check.FillArray();
            foreach(var i in newarr)
            {
                Console.Write(i+" ");
            }
            

        }
    }
}
