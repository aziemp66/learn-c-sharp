public class Program
{
    delegate void LogDel(string text);

    static void Main(string[] args)
    {
        Log log = new Log();
        LogDel logFile = new LogDel(log.LogTextToFile);
        LogDel logScreen = new LogDel(log.LogTextToScreen);

        LogDel MultiLogDel = logFile + logScreen;

        System.Console.WriteLine("Please Enter Your Name:");
        var name = Console.ReadLine();

        if (name == null)
        {
            Console.WriteLine("Cant be Empty");
            return;
        }

        LogText(MultiLogDel, name);

        Console.ReadLine();
    }

    static void LogText(LogDel logDel, string text)
    {
        logDel(text);
    }
}

class Log
{
    public void LogTextToScreen(string text)
    {
        Console.WriteLine($"{DateTime.Now}: {text}");
    }

    public void LogTextToFile(string text)
    {
        using (
            StreamWriter sw = new StreamWriter(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.txt"),
                true
            )
        )
        {
            sw.WriteLine($"{DateTime.Now}: {text}");
        }
    }
}
