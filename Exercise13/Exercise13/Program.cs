using System;


public class MathOperations<T>
{
    public T Add(T a, T b)
    { 
        return (T)((dynamic)a + (dynamic)b);
    }
    public T Substract(T a, T b)
    {
        return (T)((dynamic)a - (dynamic)b);
    }
    public T Multiply(T a, T b)
    {
        return (T)((dynamic)a * (dynamic)b);
    }
    public T Divide(T a, T b)
    {
        if ((dynamic)b == 0)
        {
            throw new ArgumentException("Nu putem imparti la 0");
        }
        return (T)((dynamic)a / (dynamic)b);
    }
}

public class Program
{
    static void Main(string[] args)
    {
        var intNumber = new MathOperations<int>();
        Console.WriteLine(intNumber.Add(20,6));
        Console.WriteLine(intNumber.Substract(20, 6));
        Console.WriteLine(intNumber.Multiply(20, 6));
        Console.WriteLine(intNumber.Divide(20, 6));

    }
}