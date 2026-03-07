namespace MyLibraryDemo
{
    public class MyMath
    {
        public int GetSum(params int[] values)
        {
            int sum = 0;
            foreach(int value in values)
            {
                sum += value;
            }
            return sum;
        }
        public int GetMultiply(int n1,int n2)
        {
           
            return n1*n2;
        }

    }
}
