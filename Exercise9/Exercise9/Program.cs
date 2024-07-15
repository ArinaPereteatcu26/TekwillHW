using System;

public class Angajat
{
    public string Nume;

    public virtual void AfisareDetalii()
    {
        Console.WriteLine($"Numele este:{Nume}");
    }

    public Angajat(string nume) 
    {
        Nume= nume;
    }
}

 class Manager : Angajat
{
    public string Departament;
    
    public override void AfisareDetalii()
    {
        base.AfisareDetalii();
        Console.WriteLine($"Departamentul este: {Departament}");
    }

    public Manager(string nume, string departament) : base(nume)
    {
        Departament= departament;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Manager manager = new Manager("Travis Scott", "Music");

        manager.AfisareDetalii();
    }
}