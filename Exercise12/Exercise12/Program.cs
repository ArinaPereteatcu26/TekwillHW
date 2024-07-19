using System;


class Angajat
{
    public string Nume;
    public int Vechime;

    public virtual int CalculeazaSalariu()
    {
        return 10000;
    }
    public Angajat(string nume, int vechime)
    {
        Nume = nume;
        Vechime = vechime;
    }
}

class Manager : Angajat 
{
    public Manager(string nume, int vechime): base(nume, vechime) 
    {}

    public override int CalculeazaSalariu()
    {
        return base.CalculeazaSalariu() + (int)(0.3 * 10000) * Vechime;
    }
}

class Programator : Angajat
{
    public List<string> Limbaje {  get; set; }
    public Programator(string nume, int vechime, List<string> limbaje) : base(nume, vechime)
    {
        Limbaje = limbaje;
    }

    public override int CalculeazaSalariu()
    {
        int salariu = 10000;
        foreach (var limbaj in Limbaje) 
        {
            salariu += (int)(0.5 * 10000);

            if (limbaj == "C#")
            {
                salariu += (int)(4 * 10000);

            }

        }
        return salariu;
        
    }

}

class Contabil : Angajat
{
    public Contabil(string nume, int vechime) : base(nume, vechime)
    { }
    public override int CalculeazaSalariu()
    {
        return base.CalculeazaSalariu() + (int)(0.2 * 10000) * Vechime;
    }
}

public class Program
{
    static void Main(string[] args)
    {
        List<Angajat> angajati = new List<Angajat>
        {
            new Manager("Ion",5),
            new Programator("Arina", 3, new List<string>{"C#","Python"}),
            new Contabil("Anatol", 6)
        };

        foreach (Angajat angajat in angajati)
        {
            Console.WriteLine($"Nume: {angajat.Nume}, Vechime:{angajat.Vechime}, Salariu:{angajat.CalculeazaSalariu()}");
        }
        
    }
}
