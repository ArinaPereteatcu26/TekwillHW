using System;


public class Student
{
    public string Nume { get; set; }
    public int Varsta { get; set; }
    public string Specializare { get; set; }

    public Student(string nume, int varsta, string specializare)
    {
        Nume = nume;
        Varsta = varsta;
        Specializare = specializare;
    }

    public Student(Student student)
    {
        Nume = student.Nume;
        Varsta = student.Varsta;
        Specializare = student.Specializare;
    }

    public void AfisareDetalii()
    {
        Console.WriteLine($"{Nume}, {Varsta}, {Specializare}");
        
    }
}

public class Program
{
    static void Main(string[] args)
    {
        Student student1 = new Student("Aliona Marona", 23, "Streamer");
     
        student1.AfisareDetalii();

        Student student2 = new Student(student1);
        student1.AfisareDetalii();

        student1.Nume = "Ion Creanga";
        student1.Varsta = 25;
        student1.Specializare = "Youtuber";

        Console.WriteLine("Detalii student1:");
        student1.AfisareDetalii();

        Console.WriteLine("\nDetalii student2:");
        student2.AfisareDetalii();

    }
}