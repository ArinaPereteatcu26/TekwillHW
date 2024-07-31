using System;


public interface IWorkable
{
    void Work();
}

public interface IEatable
{
    void Eat();
}

public class HumanWorker : IWorkable, IEatable
{
    public void Work()
    {
        Console.WriteLine("Human working...");
    }

    public void Eat()
    {
        Console.WriteLine("Human eating...");
    }
}

public class RobotWorker : IWorkable
{
    public void Work()
    {
        Console.WriteLine("Robot working...");
    }
}

public class WorkerManager
{
    private readonly IWorkable _workable;

    public WorkerManager(IWorkable workable)
    {
        _workable = workable;
    }

    public void Manage()
    {
        _workable.Work();
    }
}