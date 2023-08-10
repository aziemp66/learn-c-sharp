namespace Lambda
{
    class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>
            {
                new Person("John", 34),
                new Person("Tony", 22),
                new Person("Andy", 55)
            };

            var sortedByAge = people.OrderBy(p => p.Age);
        }
    }
}
