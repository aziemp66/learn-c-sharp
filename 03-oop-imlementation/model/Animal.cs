namespace Model;

abstract class Animal : LivingBeing
{
    public abstract void Eat();

    public virtual void Reproduce()
    {
        Console.WriteLine("Have Sex");
    }
}
