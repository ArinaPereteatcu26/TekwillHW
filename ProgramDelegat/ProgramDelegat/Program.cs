using System;

public delegate int MathOperation(int x, int y);

class Program
{
    public static int Adunare(int x, int y)
    {
        return x + y;
    }

    public static int Scadere(int x, int y)
    {
        return x - y;
    }

    public static int Inmultire(int x, int y)
    {
        return x * y;
    }

    public static int Impartire(int x, int y)
    {
        if (y == 0)
        {
            Console.WriteLine("Eroare de impartire la 0");
            return 0;
        }
        return x / y;
    }

    public static void Main(string[] args)
    {
        MathOperation operation = Adunare;
        int result = operation(8, 9);
        Console.WriteLine($"Rezultat adunare:{result}");

        operation = Scadere;
        int result2 = operation(8, 9);
        Console.WriteLine($"Rezultat scadere: {result2}");

        operation = Inmultire;
        int result3 = operation(8, 9);
        Console.WriteLine($"Rezultat inmultire: {result3}");

        operation = Impartire;
        int result4 = operation(4, 2);
        Console.WriteLine($"Rezultat impartire: {result4}");
    }
}