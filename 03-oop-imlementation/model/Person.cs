namespace Model;

class Person : Animal
{
    public Person(string FirstName, string LastName)
    {
        this.FirstName = FirstName;
        this.LastName = LastName;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string GetFullName()
    {
        return $"{FirstName} {LastName}";
    }

    string? _nickName;
    public string Nickname
    {
        get
        {
            if (_nickName is null)
            {
                return "";
            }
            return _nickName;
        }
        set { _nickName = value; }
    }

    public override void Eat()
    {
        Console.WriteLine("I'm Eating Meat and Vegetable");
    }

    public override void Reproduce()
    {
        Console.WriteLine("Pregnancy");
    }
}
