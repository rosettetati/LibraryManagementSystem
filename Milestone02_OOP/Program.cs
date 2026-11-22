
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

class Program
{
    static List<Book> books = new List<Book>();

    static string filePath = Path.Combine(
        AppContext.BaseDirectory,
        "books.json"
    );

    static void Main()
    {
        LoadBooks();

        bool running = true;

        while (running)
        {
            Console.WriteLine("\n===== LIBRARY MANAGEMENT SYSTEM =====");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. List Books");
            Console.WriteLine("3. Find Book");
            Console.WriteLine("4. Delete Book");
            Console.WriteLine("5. Exit");

            Console.Write("Choose an option: ");
            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    AddBook();
                    break;

                case "2":
                    ListBooks();
                    break;

                case "3":
                    FindBook();
                    break;

                case "4":
                    DeleteBook();
                    break;

                case "5":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    static void AddBook()
    {
        Console.Write("Enter book title: ");
        string title = Console.ReadLine() ?? "";

        Console.Write("Enter author: ");
        string author = Console.ReadLine() ?? "";

        Console.Write("Enter genre: ");
        string genre = Console.ReadLine() ?? "";

        Console.Write("Enter publication year: ");

        if (!int.TryParse(Console.ReadLine(), out int year))
        {
            Console.WriteLine("Invalid year.");
            return;
        }

        if (string.IsNullOrWhiteSpace(title) ||
            string.IsNullOrWhiteSpace(author) ||
            string.IsNullOrWhiteSpace(genre))
        {
            Console.WriteLine("Fields cannot be empty.");
            return;
        }

        int newId = books.Count == 0
            ? 1
            : books.Max(book => book.Id) + 1;

        Book newBook = new Book(
            newId,
            title,
            author,
            genre,
            year
        );

        books.Add(newBook);

        SaveBooks();

        Console.WriteLine("Book added successfully!");
    }

    static void ListBooks()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("The library is empty.");
            return;
        }

        Console.WriteLine("\n--- BOOK LIST ---");

        foreach (Book book in books)
        {
            book.DisplayInfo();
        }
    }

    static void FindBook()
    {
        Console.Write("Enter title or author to search: ");
        string search = Console.ReadLine() ?? "";

        List<Book> results = books
            .Where(book =>
                book.Title.Contains(
                    search,
                    StringComparison.OrdinalIgnoreCase
                )
                ||
                book.Author.Contains(
                    search,
                    StringComparison.OrdinalIgnoreCase
                ))
            .ToList();

        if (results.Count == 0)
        {
            Console.WriteLine("Book not found.");
            return;
        }

        Console.WriteLine("\n--- SEARCH RESULTS ---");

        foreach (Book book in results)
        {
            book.DisplayInfo();
        }
    }

    static void DeleteBook()
    {
        ListBooks();

        if (books.Count == 0)
        {
            return;
        }

        Console.Write("Enter book ID to delete: ");

        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        Book? book = books.FirstOrDefault(b => b.Id == id);

        if (book == null)
        {
            Console.WriteLine("Book not found.");
            return;
        }

        books.Remove(book);

        SaveBooks();

        Console.WriteLine("Book deleted successfully!");
    }

    static void SaveBooks()
    {
        string json = JsonSerializer.Serialize(
            books,
            new JsonSerializerOptions
            {
                WriteIndented = true
            }
        );

        File.WriteAllText(filePath, json);
    }

    static void LoadBooks()
    {
        if (!File.Exists(filePath))
        {
            books = new List<Book>();
            return;
        }

        try
        {
            string json = File.ReadAllText(filePath);

            books = JsonSerializer.Deserialize<List<Book>>(json)
                    ?? new List<Book>();
        }
        catch (JsonException)
        {
            Console.WriteLine("Could not read the books JSON file.");
            books = new List<Book>();
        }
    }
}
