namespace Program;

using Model;

public class MyProgram
{
    static void Main(string[] args)
    {
        Person Lebron = new Person("Lebron", "James");
        Lebron.Nickname = "LeJames";

        Lebron.Eat();
        Lebron.Reproduce();

        Console.WriteLine(Lebron.Nickname);
        Console.WriteLine(Lebron.GetFullName());
    }
}
