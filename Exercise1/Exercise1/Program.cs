using System;
namespace Homework12
{

    public class Angajat
    {
        public string Name;
        public int Salariu;
        public string Departament;

        public Angajat(string name, int salariu, string departament)
        {
            Name = name;
            Salariu = salariu;
            Departament = departament;
        }


        public void AfisareDetalii()
        {
            Console.WriteLine($"Nume: {Name}, Salariu: {Salariu}, Departament: {Departament}");
        }
    }


    public class Program
    {
        public static void Main(string[] args)
        {
            Angajat angajat1 = new Angajat("Arnold Schwarznager", 50000, "HR");
            Angajat angajat2 = new Angajat("Irina Malina", 100000, "Developer");
            Angajat angajat3 = new Angajat("Alisa Melisa", 60000, "SMM");



            angajat1.AfisareDetalii();
            angajat2.AfisareDetalii();
            angajat3.AfisareDetalii();
        }
    }

}