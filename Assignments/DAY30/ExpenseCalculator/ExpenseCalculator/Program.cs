//namespace ExpenseCalculator
//{
//    class Friend {
//        public string Name { get; set; }
//        public  double Expense { get; set; }
//        public double Balance { get; set; }
//        public Friend(string name,double expense)
//        {
//            Name = name;
//            Expense = expense;
//        }


//    }
   


//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            List<Friend> ec = new List<Friend>() {
//             new Friend("Rajiv", 100),
//             new Friend("kunal",1300),
//             new Friend("piyush",1200),
//             new Friend("sanjiv",200)
//                };

//            double sum = 0;
//            foreach(var ch in ec)
//            {
//                sum += ch.Expense;

//            }
//            double average = sum / ec.Count;
            
//            foreach(var ch in ec)
//            {
//                ch.Balance = ch.Expense-average;
//            }
//           // Console.WriteLine(average);
//          for(int i = 0; i < ec.Count; i++)
//            {
//                if (ec[i].Balance < 0) {
//                    for (int j = 0; j < ec.Count; j++)
//                    {
//                        if (ec[j].Balance > 0) { 
//                        {
//                            Console.WriteLine($"{ec[i].Name} pays {Math.Abs(diff1)} to {ec[j].Name}");
//                            ec[i].Expense = diff1 + diff2;
//                        }
//                        else if (payfriend < 0 && (Math.Abs(diff1) > Math.Abs(diff2)))
//                        {
//                            Console.WriteLine($"{ec[i].Name} pays {Math.Abs(diff2)} to {ec[j].Name}");
//                            ec[i].Expense = diff1 + diff2;
//                        }
//                    }
//                }
//                else if (diff1 < 0 && diff2 > 0 && i != j && (Math.Abs(diff1) < Math.Abs(diff2)))
//                {
//                    Console.WriteLine($"{ec[i].Name} pays {Math.Abs(payfriend)} to {ec[j].Name}");
//                    ec[j].Expense = diff1 + diff2;
//                }
//                }
//            }
            

//        }
//    }
//}
