



namespace OopsConcept
{

    class Personname
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Salary { get;set; }

        public string FullName
        {
            get { return $"{FirstName}{LastName}"; }

        }
        public Personname()
        {
            PersonId = 10;
            FirstName = "Rajiv";
            LastName = "Kumar";
            Salary = 20000;

        }
        public override string ToString()
        {
            return $"Id-{PersonId} name-{FullName} Salary-{Salary}";
        }
        public override bool Equals(object? obj)
        {
            Personname e2 = obj as Personname;//(Personname)obj;

            return (this.FullName.Equals(e2.FullName));
           // return base.Equals(obj);
        }
        public override int GetHashCode()
        {
           // Console.WriteLine(this.GetHashCode());
            return this.GetHashCode();
        }
    }

    class oopsDay2
    {
        static void Main(string[] args)
        {
            Personname p1 = new Personname();


           // Console.WriteLine(p1);
            Personname p2 = new Personname() {
                PersonId = 22,
                Salary = 30000,
                 FirstName = "sanjeev",
                LastName = "Kumar"
            };
            Personname p3 = new Personname()
            {
                PersonId = 23,
                Salary = 40000
            };
            Console.WriteLine(p2);
            Console.WriteLine(p3);
            Console.WriteLine(p2.Equals(p3));





        }
    }
}
