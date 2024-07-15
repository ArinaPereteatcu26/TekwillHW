using System;
using System.Globalization;

class Animal
{
   public string Nume;

    public virtual void AfisareDetalii()
    {
        Console.WriteLine($"Numele este:{Nume}");
    }

    public Animal(string nume)
    {
        Nume = nume;
    }
}

class Mamifer : Animal 
{
    public string CuloareBlana { get; set; }

    public Mamifer(string nume, string culoareBlana) : base(nume)
    {
        CuloareBlana = culoareBlana;
    }


    public override void AfisareDetalii()
    {
        base.AfisareDetalii();
        Console.WriteLine($"Culoarea blanii este: {CuloareBlana}");
    }

    
}

class Pasare : Animal 
{
    public string TipZbor;
    public Pasare(string nume, string tipZbor) : base(nume)
    {
        TipZbor = tipZbor;
    }

    public override void AfisareDetalii()
    {
        base.AfisareDetalii();
        Console.WriteLine($"Tipul de zbor este:{TipZbor}");
    }
    
}

class Papagal : Pasare 
{
    string Vocabular;

    public Papagal(string nume, string tipZbor, string vocabular) : base(nume, tipZbor)
    {
        Vocabular = vocabular;
    }

    public override void AfisareDetalii()
    {
        base.AfisareDetalii();
        Console.WriteLine($"Detalii despre vocabular: {Vocabular}");
    }

   
}

class Program
{
    static void Main(string[] args)
    {
        Mamifer mamifer = new Mamifer("Urs", "brun");
        Pasare pasare = new Pasare("Soim", "Periculos");
        Papagal papagal = new Papagal("Papagal colorat", "Zbor regulat", "Vocabular bogat");

        mamifer.AfisareDetalii();
        pasare.AfisareDetalii();
        papagal.AfisareDetalii();

    }
}