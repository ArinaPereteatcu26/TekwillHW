using System;
using System.Collections.Generic;

public interface IBorrowable
{
    void Borrow();
    void Return();
    bool IsBorrowed();
}

public abstract class LibraryItem : IBorrowable
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int PublicationYear { get; set; }
    private bool borrowed;

    public LibraryItem(string title, string author, int publicationYear)
    {
        Title = title;
        Author = author;
        PublicationYear = publicationYear;
        borrowed = false;
    }

    public void Borrow()
    {
        if (borrowed)
        {
            Console.WriteLine($"{Title} de {Author} este imprumutata");
        }
        else
        {
            borrowed = true;
            Console.WriteLine($"{Title} de {Author} a fost deja imprumutata");
        }
    }

    public void Return()
    {
        if (!borrowed)
        {
            Console.WriteLine($"{Title} de {Author} nu este imprumutata");
        }
        else
        {
            borrowed = false;
            Console.WriteLine($"{Title} de {Author} a fost returnata");
        }
    }

    public bool IsBorrowed()
    {
        return borrowed;
    }
}

class Book : LibraryItem
{
    public Book(string title, string author, int publicationYear) : base(title, author, publicationYear)
    {
    }
}

class Magazine : LibraryItem
{
    public Magazine(string title, string author, int publicationYear) : base(title, author, publicationYear)
    {
    }
}

class DVD : LibraryItem
{
    public DVD(string title, string author, int publicationYear) : base(title, author, publicationYear)
    {
    }
}

public class Library
{
    private List<LibraryItem> items = new List<LibraryItem>();

    public void AddItem(LibraryItem item)
    {
        items.Add(item);
        Console.WriteLine($"{item.Title} a fost adaugat in librarie");
    }

    public void BorrowItem(string title)
    {
        LibraryItem item = items.Find(x => x.Title == title);
        if (item != null)
        {
            item.Borrow();
        }
        else
        {
            Console.WriteLine($"{title} nu a fost gasit in librarie");
        }
    }

    public void ReturnItem(string title)
    {
        LibraryItem item = items.Find(x => x.Title == title);
        if (item != null)
        {
            item.Return();
        }
        else
        {
            Console.WriteLine($"{title} nu a fost gasit in librarie");
        }
    }
}

public class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();

        library.AddItem(new Book("A Christmas Carol", "Charles Dickens", 1843));
        library.AddItem(new Magazine("The Kardashians", "Kanye West", 2023));
        library.AddItem(new DVD("A Quiet Place", "John Krasinski", 2018));

        library.BorrowItem("A Christmas Carol");
        library.BorrowItem("The Kardashians");
        library.BorrowItem("A Christmas Carol");
        library.ReturnItem("A Christmas Carol");
        library.BorrowItem("A Happy New Year");
        library.BorrowItem("A Christmas Carol");
    }
}