namespace Model;

abstract class Animal : LivingBeing
{
    public abstract void Eat();

    public void Reproduce()
    {
        Console.WriteLine("Have Sex");
    }
}
