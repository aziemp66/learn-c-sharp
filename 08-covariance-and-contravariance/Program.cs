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

    static void Main(string[] args)
    {
        CarFactoryDel carFactoryDel = CarFactory.ReturnICECar;

        Car IceCar = carFactoryDel.Invoke(1, "Audi R8");

        Console.WriteLine($"Object Type : {IceCar.GetType()}");
        Console.WriteLine($"Car Details : {IceCar.GetCarDetails()}");
        Console.WriteLine();

        carFactoryDel = CarFactory.ReturnEVCar;

        Car EVCar = carFactoryDel.Invoke(2, "Tesla Model X");

        Console.WriteLine($"Object Type : {EVCar.GetType()}");
        Console.WriteLine($"Car Details : {EVCar.GetCarDetails()}");
    }

    static void PrintICECar(ICECar iceCar)
    {
        Console.WriteLine(iceCar.Name);
    }
}
