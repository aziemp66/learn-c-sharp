namespace CovarianceAndContravariance;

public abstract class Car
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Car(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public virtual string GetCarDetails()
    {
        return $"{Id} {Name}";
    }
}

public class ICECar : Car
{
    public ICECar(int id, string name)
        : base(id, name) { }

    public override string GetCarDetails()
    {
        return $"{base.GetCarDetails()} - Internal Combustion Engine";
    }
}

public class EVCar : Car
{
    public EVCar(int id, string name)
        : base(id, name) { }

    public override string GetCarDetails()
    {
        return $"{base.GetCarDetails()} - Electric";
    }
}

public static class CarFactory
{
    public static ICECar ReturnICECar(int id, string name)
    {
        return new ICECar(id, name);
    }

    public static EVCar ReturnEVCar(int id, string name)
    {
        return new EVCar(id, name);
    }
}

class Program
{
    delegate Car CarFactoryDel(int id, string name);
    delegate void LogICECarDetail(ICECar iceCar);
    delegate void LogEVCarDetail(EVCar evCar);

    static void LogCarDetailToText(Car car)
    {
        string objectType = $"Object Type : {car.GetType()}";
        string details = $"Car Details : {car.GetCarDetails()}";

        int maxStringLength = Math.Max(objectType.Length, details.Length);

        string seperator = "";

        for (int i = 0; i < maxStringLength; i++)
        {
            seperator += "/";
        }

        if (car is ICECar)
        {
            using (
                StreamWriter sw = new StreamWriter(
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ICEDetails.txt"),
                    true
                )
            )
            {
                sw.WriteLine(seperator);
                sw.WriteLine(objectType);
                sw.WriteLine(details);
                sw.WriteLine(seperator);
            }
        }
        else if (car is EVCar)
        {
            using (
                StreamWriter sw = new StreamWriter(
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "EVDetails.txt"),
                    true
                )
            )
            {
                sw.WriteLine(seperator);
                sw.WriteLine(objectType);
                sw.WriteLine(details);
                sw.WriteLine(seperator);
            }
        }
    }

    static void Main(string[] args)
    {
        CarFactoryDel carFactoryDel = CarFactory.ReturnICECar;

        Car IceCar = carFactoryDel(1, "Audi R8");

        carFactoryDel = CarFactory.ReturnEVCar;

        Car EvCar = carFactoryDel(2, "Tesla Model X");

        Console.WriteLine($"Object Type : {IceCar.GetType()}");
        Console.WriteLine($"Car Details : {IceCar.GetCarDetails()}");
        Console.WriteLine();

        Console.WriteLine($"Object Type : {EvCar.GetType()}");
        Console.WriteLine($"Car Details : {EvCar.GetCarDetails()}");

        LogICECarDetail logICECarDetailsDel = LogCarDetailToText;

        LogEVCarDetail logEVCarDetailsDel = LogCarDetailToText;

        // Check if IceCar is not null before invoking the delegate
        if (IceCar is ICECar iceCar)
        {
            logICECarDetailsDel(iceCar);
        }
        else
        {
            Console.WriteLine("ICECar is null.");
        }

        // Check if EvCar is not null before invoking the delegate
        if (EvCar is EVCar evCar)
        {
            logEVCarDetailsDel(evCar);
        }
        else
        {
            Console.WriteLine("EVCar is null.");
        }
    }
}
