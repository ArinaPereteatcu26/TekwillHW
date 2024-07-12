using System;
using System.Security.Cryptography.X509Certificates;

public static class Helper
{
    public static Random random = new Random();
    public static string GenerareCodUnic(string prefix)
    {
        int randomNumber = random.Next(1000, 9999);
        return $"{prefix}{randomNumber}";
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine(Helper.GenerareCodUnic("ABC"));
        Console.WriteLine(Helper.GenerareCodUnic("XYZ"));
        Console.WriteLine(Helper.GenerareCodUnic("MIAU"));
        Console.WriteLine(Helper.GenerareCodUnic("ABC"));
        Console.WriteLine(Helper.GenerareCodUnic("ABC"));
        Console.WriteLine(Helper.GenerareCodUnic("ABC"));
    }
}
