using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadDemo
{
    class BankAccount
    {
         object locker = new object();
        public double Balance { get; set; }
        public BankAccount(int initialbalance)
        {
           
            Balance = initialbalance;
        }
        public void Withdrawl(int amount,string s)
        {
            lock (locker)
            {

                if (Balance >= amount)
                {
                    Console.WriteLine(s);
                    Console.WriteLine("you can withdraw");
                    Balance -= amount;
                    //  Thread.Sleep(2000);
                  

                }
                else
                {
                    Console.WriteLine("you can not withdraw :Low Balance");
                }
            }
        }

    }
    internal class BankTransactionDemo
    {
        static void Main(string[] args)
        {
            BankAccount account1 = new BankAccount(1000);
            //ParameterizedThreadStart s1 = new ParameterizedThreadStart();
            //Thread tr1 = new Thread()
            //account1.Withdrawl(750);
            //account1.Withdrawl(750);
            //Console.WriteLine(account1.Balance);
            Thread trans1 = new Thread(() => account1.Withdrawl(750,"thread1 access the lock"));
            Thread trans2 = new Thread(() => account1.Withdrawl(750,"thread2 access the lock"));
            trans1.Start();
            trans2.Start();
           
            trans1.Join();
            trans2.Join();
            Console.WriteLine(account1.Balance);



        }
    }
       

}
