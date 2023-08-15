namespace async_await;

using System;
using System.Diagnostics;
using System.Threading.Tasks;

class Program
{
    internal class Indomie { }

    internal class FriedEgg { }

    internal class Rice { }

    public static async Task PreparingMealAsync()
    {
        Console.WriteLine("Preparing Meal...");
        await Task.Delay(2000);
        Console.WriteLine("Meal Prepared.");
    }

    public static async Task<Indomie> CookIndomieAsync()
    {
        Console.WriteLine("Cooking Indomie...");
        await Task.Delay(3000);
        Console.WriteLine("Indomie Cooked.");
        return new Indomie();
    }

    public static async Task<FriedEgg> CookFriedEggAsync()
    {
        Console.WriteLine("Cooking Fried Egg...");
        await Task.Delay(1000);
        Console.WriteLine("Fried Egg Cooked.");
        return new FriedEgg();
    }

    public static async Task<Rice> CookRiceAsync()
    {
        Console.WriteLine("Cooking Rice...");
        await Task.Delay(5000);
        Console.WriteLine("Rice Cooked.");
        return new Rice();
    }

    static async Task Main(string[] args)
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();

        Task<Indomie> indomieTask = CookIndomieAsync();
        Task<FriedEgg> friedEggTask = CookFriedEggAsync();
        Task<Rice> riceTask = CookRiceAsync();
        // Each Task Will not block each other and run simulataneously
        await Task.WhenAll(indomieTask, friedEggTask, riceTask);

        // preparingMealTask will wait for all other task to complete before running
        Task preparingMealTask = PreparingMealAsync();
        await preparingMealTask;

        stopWatch.Stop();
        Console.WriteLine(
            $"Cooking Complete, Time Elapsed {stopWatch.ElapsedMilliseconds / 1000} Seconds"
        );
    }
}
