
using Milestone04_Database.Models;

namespace Milestone04_Database.Presentation;

public static class ConsoleUI
{
    public static void ShowMainMenu()
    {
        Console.WriteLine("\n===== LIBRARY MANAGEMENT SYSTEM =====");
        Console.WriteLine("1. Register");
        Console.WriteLine("2. Login");
        Console.WriteLine("3. Exit");
        Console.Write("Choose an option: ");
    }

    public static void ShowLibraryMenu(string username)
    {
        Console.WriteLine($"\n===== {username}'S LIBRARY =====");
        Console.WriteLine("1. Add Book");
        Console.WriteLine("2. List Books");
        Console.WriteLine("3. Search Books");
        Console.WriteLine("4. Borrow Book");
        Console.WriteLine("5. Return Book");
        Console.WriteLine("6. Delete Book");
        Console.WriteLine("7. Logout");
        Console.Write("Choose an option: ");
    }

    public static string ReadInput(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine()?.Trim() ?? string.Empty;
    }

    public static int ReadInt(string prompt)
    {
        while (true)
        {
            string input = ReadInput(prompt);

            if (int.TryParse(input, out int number))
                return number;

            Console.WriteLine("Please enter a valid number.");
        }
    }

    public static void DisplayBooks(List<Book> books)
    {
        if (books.Count == 0)
        {
            Console.WriteLine("No books found.");
            return;
        }

        Console.WriteLine("\n===== BOOK LIST =====");

        foreach (Book book in books)
        {
            DisplayBook(book);
        }
    }

    public static void DisplayBook(Book book)
    {
        Console.WriteLine("----------------------------");
        Console.WriteLine($"ID: {book.Id}");
        Console.WriteLine($"Title: {book.Title}");
        Console.WriteLine($"Author: {book.Author}");
        Console.WriteLine($"Genre: {book.Genre}");
        Console.WriteLine($"Year: {book.PublicationYear}");
        Console.WriteLine($"Status: {(book.IsAvailable ? "Available" : "Borrowed")}");
    }

    public static void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    public static void Pause()
    {
        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
    }
}
