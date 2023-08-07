namespace Program;

public class MyProgram
{
    LivingBeing lion1 = new Lion();
    Animal lion2 = new Lion();
    Lion lion3 = new Lion();
}

interface LivingBeing
{
    void breathe();
}

abstract class Animal : LivingBeing
{
    public void breathe() {
        Console.WriteLine("I'm Breating rn");
    }

    public abstract void reproduce();
}

class Lion : Animal
{
    public override void reproduce()
    {
        Console.WriteLine("By Pregnancy");
    }
}