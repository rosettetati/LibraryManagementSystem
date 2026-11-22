
using System;

public class Book
{
    public int Id { get; private set; }

    public string Title { get; private set; }

    public string Author { get; private set; }

    public string Genre { get; private set; }

    public int PublicationYear { get; private set; }

    public bool IsAvailable { get; private set; }

    // Constructor
    public Book(
        int id,
        string title,
        string author,
        string genre,
        int publicationYear,
        bool isAvailable = true)
    {
        Id = id;
        Title = title;
        Author = author;
        Genre = genre;
        PublicationYear = publicationYear;
        IsAvailable = isAvailable;
    }

    // Behavior
    public bool Borrow()
    {
        if (!IsAvailable)
        {
            return false;
        }

        IsAvailable = false;
        return true;
    }

    public bool ReturnBook()
    {
        if (IsAvailable)
        {
            return false;
        }

        IsAvailable = true;
        return true;
    }

    public void DisplayInfo()
    {
        Console.WriteLine(
            $"ID: {Id} | Title: {Title} | Author: {Author} | " +
            $"Genre: {Genre} | Year: {PublicationYear} | " +
            $"Available: {IsAvailable}");
    }
}
