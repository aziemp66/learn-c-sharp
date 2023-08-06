namespace Program;

public class Program
{
    static void Main(string[] args)
    {
        // See https://aka.ms/new-console-template for more information
        string? radius = Console.ReadLine();

        Console.WriteLine(Math.PI * Math.Pow(Convert.ToDouble(radius), 2));
    }
}
