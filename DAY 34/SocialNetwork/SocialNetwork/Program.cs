namespace SocialNetwork
{

    class Person
    {
        public string Name{ get; set; }
         public  string Password { get; set; }
        public Person(string person,string password)
        {
            Name = person;
            Password = password;
        }
        public List<Person> Friends = new List<Person>();
        //public void AddFriend(Person friend)
        //{
        //    if (!Friends.Contains(friend))
        //    {
        //        Friends.Add(friend);
        //        friend.Friends.Add(this);
        //    }

        //}
    }
    class SocialNetwork {
        private List<Person> _persons = new List<Person>();
        public void AddPerson(Person person)
        {
            _persons.Add(person);
        }
        public void AddFriend(Person friend1,Person friend2)
        {
            if (!(_persons.Contains(friend1)) && _persons.Contains(friend2))
            {
                Console.WriteLine($"Any of Friends {friend1.Name} {friend2.Name} are not on newtwork");
            }
            else
            {
                if (!friend1.Friends.Contains(friend2))
                {
                    friend1.Friends.Add(friend2);
                    friend2.Friends.Add(friend1);
                }
            }
        }
        public void ShowNetwork()
        {
            foreach(var member in _persons)
            {
                Console.Write(member.Name+"->");
                List<string> friends = new List<string>();
               foreach(var friend in member.Friends)
                {
                     friends.Add(friend.Name);
                  //  Console.Write(friend.Name+",");
                }
               // Console.WriteLine();
                Console.WriteLine($"{string.Join(",",friends)}");
            }
        }
        //public void Register(Person person)
        //{
        //    if (person.Password == "1234")
        //    {
        //        Console.WriteLine("you can login");
        //    }
        //    else
        //    {
        //        Console.WriteLine("wrong password");
        //    }
        //}
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            SocialNetwork network = new SocialNetwork();
            Person aman = new Person("Aman","1234");
            Person  rajiv = new Person("Rajiv","12345");
            Person sanjiv = new Person("Sanjiv","12");
            Person kunal = new Person("Kunal","1");
            network.AddPerson(aman);
            network.AddPerson(rajiv);
            network.AddPerson(sanjiv);
            network.AddPerson(kunal);
            network.AddFriend(aman, rajiv);
            network.AddFriend(rajiv, kunal);
            network.AddFriend(kunal, rajiv);
            network.AddFriend(sanjiv, rajiv);
            network.AddFriend();




            //aman.AddFriend(rajiv);
            //aman.AddFriend(kunal);
            //rajiv.AddFriend(sanjiv);
            //rajiv.AddFriend(kunal);
            //kunal.AddFriend(rajiv);
            network.ShowNetwork();
           // network.Register(rajiv);

        }
    }
}
