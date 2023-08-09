class Program
{
    static void Login(string user)
    {
        if (!user.Equals("Azie"))
        {
            throw new HttpException.UnauthorizedException("You Are Not Authorized");
        }

        System.Console.WriteLine("You are Authorized");
    }

    static void Main(string[] args)
    {
        string? user = Console.ReadLine();

        if (user == null)
        {
            Console.WriteLine("You are not Logged In");
            return;
        }

        try
        {
            Login(user);
        }
        catch (HttpException.UnauthorizedException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
