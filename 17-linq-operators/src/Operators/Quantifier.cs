namespace Operators;

using TCPData;

public static class Quantifier
{
    public static void All()
    {
        List<Market> markets = new List<Market>
        {
            new Market { Name = "Emily's", Items = new string[] { "kiwi", "cheery", "banana" } },
            new Market { Name = "Kim's", Items = new string[] { "melon", "mango", "olive" } },
            new Market { Name = "Adam's", Items = new string[] { "kiwi", "apple", "orange" } },
        };

        var names =
            from market in markets
            where market.Items.All(item => item.Length == 5)
            select market.Name;

        foreach (var name in names)
        {
            Console.WriteLine(name);
        }
    }

    public static void Any()
    {
        List<Market> markets = new List<Market>
        {
            new Market { Name = "Emily's", Items = new string[] { "kiwi", "cheery", "banana" } },
            new Market { Name = "Kim's", Items = new string[] { "melon", "mango", "olive" } },
            new Market { Name = "Adam's", Items = new string[] { "kiwi", "apple", "orange" } },
        };

        var names =
            from market in markets
            where market.Items.Any(item => item.Length == 5)
            select market.Name;

        foreach (var name in names)
        {
            Console.Write(name + " ");
        }
        Console.WriteLine();
    }

    public static void Contains()
    {
        List<Market> markets = new List<Market>
        {
            new Market { Name = "Emily's", Items = new string[] { "kiwi", "cheery", "banana" } },
            new Market { Name = "Kim's", Items = new string[] { "melon", "mango", "olive" } },
            new Market { Name = "Adam's", Items = new string[] { "kiwi", "apple", "orange" } },
        };

        var names = from market in markets where market.Items.Contains("kiwi") select market.Name;

        foreach (var name in names)
        {
            Console.Write(name + " ");
        }
        Console.WriteLine();
    }
}
