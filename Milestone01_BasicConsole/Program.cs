
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Program
{
    static List<string> books = new List<string>();
    static string filePath = "books.json";

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
                    Console.WriteLine("Invalid option. Try again.");
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
        string year = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(title) ||
            string.IsNullOrWhiteSpace(author) ||
            string.IsNullOrWhiteSpace(genre) ||
            string.IsNullOrWhiteSpace(year))
        {
            Console.WriteLine("All fields are required.");
            return;
        }

        string book = $"{title} | {author} | {genre} | {year}";

        books.Add(book);

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

        for (int i = 0; i < books.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {books[i]}");
        }
    }

    static void FindBook()
    {
        Console.Write("Enter title or author to search: ");
        string search = Console.ReadLine() ?? "";

        bool found = false;

        foreach (string book in books)
        {
            if (book.Contains(search, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(book);
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("Book not found.");
        }
    }

    static void DeleteBook()
    {
        ListBooks();

        if (books.Count == 0)
        {
            return;
        }

        Console.Write("Enter book number to delete: ");

        if (!int.TryParse(Console.ReadLine(), out int number))
        {
            Console.WriteLine("Please enter a valid number.");
            return;
        }

        if (number >= 1 && number <= books.Count)
        {
            books.RemoveAt(number - 1);

            SaveBooks();

            Console.WriteLine("Book deleted successfully!");
        }
        else
        {
            Console.WriteLine("Invalid book number.");
        }
    }

    static void SaveBooks()
    {
        string json = JsonSerializer.Serialize(
            books,
            new JsonSerializerOptions { WriteIndented = true }
        );

        File.WriteAllText(filePath, json);
    }

    static void LoadBooks()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);

            books = JsonSerializer.Deserialize<List<string>>(json)
                    ?? new List<string>();
        }
    }
}
