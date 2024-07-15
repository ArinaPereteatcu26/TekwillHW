using System;

public interface IRunnable
{
    void Run();
}

public abstract class Animal
{
    public abstract void MakeSound();

    public virtual void Eat()
    {
        Console.WriteLine("Animal eats");
    }
}

public class Caine : Animal, IRunnable
{
    public override void MakeSound()
    {
        Console.WriteLine("Caine latra");
    }
    public override void Eat()
    {
        Console.WriteLine("Cainele mananca oase");
    }

    public void Run()
    {
        Console.WriteLine("Dog runs");
    }
}

public class Pisica : Animal, IRunnable
{
    public override void MakeSound()
    {
        Console.WriteLine("Cat miau");
    }

    public override void Eat() 
    {
        Console.WriteLine("Pisica mananca peste");
    }
    public void Run()
    {
        Console.WriteLine("Cat runs");
    }
}
public class Program
{
    static void Main(string[] args)
    {
        Caine caine = new Caine();
        caine.MakeSound();
        caine.Eat();
        caine.Run();

        Pisica pisica = new Pisica();
        pisica.MakeSound();
        pisica.Eat();
        pisica.Run();

    }
}
