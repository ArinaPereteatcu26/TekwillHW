using System;
using System.Collections.Generic;
using System.Linq;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }
    public int CopiesAvailable { get; set; }

    
}



class Program
{
    static void Main(string[] args)
    {
        List<Book> books = new List<Book>
{
    new Book { Id = 1, Title = "C# in Depth", Author = "Jon Skeet", Year = 2019, CopiesAvailable = 5 },
    new Book { Id = 2, Title = "Pro C# 7", Author = "Andrew Troelsen", Year = 2018, CopiesAvailable = 2 },
    new Book { Id = 3, Title = "C# 6.0 and the .NET 4.6 Framework", Author = "Andrew Troelsen", Year = 2015, CopiesAvailable = 0 },
    new Book { Id = 4, Title = "Learning C# by Developing Games", Author = "Harrison Ferrone", Year = 2020, CopiesAvailable = 4 },
    new Book { Id = 5, Title = "CLR via C#", Author = "Jeffrey Richter", Year = 2012, CopiesAvailable = 1 }
};

        //Filtrare
        var booksByAndrewTroelsen = books.Where(b => b.Author == "Andrew Troelsen").ToList();
        Console.WriteLine("Carti scrise de Andrew Troelsen:");
        booksByAndrewTroelsen.ForEach(b => Console.WriteLine($"{b.Title} ({b.Year})"));

        //Ordonare
        var booksByOrderDesc = books.OrderByDescending(b => b.Year).ToList();
        Console.WriteLine("\nCarti ordonate dupa an descrescator:");
        booksByOrderDesc.ForEach(b => Console.WriteLine($"{b.Title} ({b.Year})"));

        //Proiectie
        var availableBooks= books.Where(b => b.CopiesAvailable > 0 ).Select(b => b.Title).ToList();
        Console.WriteLine("\nCarti care au cel putin o copie disponibila:");
        availableBooks.ForEach(title => Console.WriteLine(title));

        //Agregare
        var totalCopiesAvailable = books.Sum(b => b.CopiesAvailable);
        Console.WriteLine($"\nNumarul total de copii disponibile: {totalCopiesAvailable}");

        //Dinstinct
        var uniqueAuthors = books.Select(b => b.Author).Distinct().ToList();
        Console.WriteLine("\nAutori unici:");
        uniqueAuthors.ForEach(author => Console.WriteLine(author));

        //Pagini
        var secondPageBooks = books.OrderBy(b => b.Title).Skip(2).Take(2).ToList();
        Console.WriteLine("\nA2a pagina de rezultate:");
        secondPageBooks.ForEach(book => Console.WriteLine($"{book.Title} ({book.Year})"));
    }
}