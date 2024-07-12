using System;


public class Carte
{
    public string Titlu { get; set; }
    public string Autor { get; set; }
    public int AnPublicare { get; set; }
    public int NumarPagini { get; set; }

    public Carte(string titlu, string autor, int anPublicare, int numarPagini)
    {
        Titlu = titlu;
        Autor = autor;
        AnPublicare = anPublicare;
        NumarPagini = numarPagini;
    }

   public void AfisareDetalii()
    {
        Console.WriteLine($"Titlu:{Titlu}");
        Console.WriteLine($"Autor:{Autor}");
        Console.WriteLine($"Anul Publicarii:{AnPublicare}");
        Console.WriteLine($"Numarul de pagini:{NumarPagini}");
    }
}

class Program 
{
    public static void Main(string[] args)
    {
        Carte carte1 = new Carte("Titlul Cartii", "Autorul Cartii", 2024, 350);
        carte1.AfisareDetalii();


    }
}