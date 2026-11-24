
using System;
using System.Collections.Generic;
using Milestone03_LayeredConsole.Models;
using Milestone03_LayeredConsole.Services;

namespace Milestone03_LayeredConsole.Presentation
{
    public class LibraryMenu
    {
        private readonly BookService bookService;
        private readonly UserService userService;

        public LibraryMenu(
            BookService bookService,
            UserService userService)
        {
            this.bookService = bookService;
            this.userService = userService;
        }

        public void Run()
        {
            bool running = true;

            while (running && userService.IsLoggedIn)
            {
                Console.WriteLine(
                    $"\n===== MY LIBRARY ({userService.CurrentUser!.Username}) ====="
                );

                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. List My Books");
                Console.WriteLine("3. Find Book");
                Console.WriteLine("4. Delete Book");
                Console.WriteLine("5. Borrow Book");
                Console.WriteLine("6. Return Book");
                Console.WriteLine("7. Logout");

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
                        BorrowBook();
                        break;

                    case "6":
                        ReturnBook();
                        break;

                    case "7":
                        userService.Logout();
                        running = false;
                        Console.WriteLine("Logged out successfully.");
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        private void AddBook()
        {
            Console.WriteLine("\n--- ADD BOOK ---");

            Console.Write("Title: ");
            string title = Console.ReadLine() ?? "";

            Console.Write("Author: ");
            string author = Console.ReadLine() ?? "";

            Console.Write("Genre: ");
            string genre = Console.ReadLine() ?? "";

            Console.Write("Publication year: ");

            if (!int.TryParse(Console.ReadLine(), out int year))
            {
                Console.WriteLine("Invalid year.");
                return;
            }

            bool success = bookService.AddBook(
                title,
                author,
                genre,
                year,
                out string message
            );

            Console.WriteLine(message);
        }

        private void ListBooks()
        {
            Console.WriteLine("\n--- MY BOOKS ---");

            List<Book> books = bookService.GetMyBooks();

            if (books.Count == 0)
            {
                Console.WriteLine("You have no books yet.");
                return;
            }

            foreach (Book book in books)
            {
                book.DisplayInfo();
            }
        }

        private void FindBook()
        {
            Console.Write("\nEnter title, author, or genre: ");

            string search = Console.ReadLine() ?? "";

            List<Book> results = bookService.FindMyBooks(search);

            if (results.Count == 0)
            {
                Console.WriteLine("No matching books found.");
                return;
            }

            Console.WriteLine("\n--- SEARCH RESULTS ---");

            foreach (Book book in results)
            {
                book.DisplayInfo();
            }
        }

        private void DeleteBook()
        {
            ListBooks();

            Console.Write("\nEnter book ID to delete: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }

            bool success = bookService.DeleteBook(
                id,
                out string message
            );

            Console.WriteLine(message);
        }

        private void BorrowBook()
        {
            ListBooks();

            Console.Write("\nEnter book ID to borrow: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }

            bool success = bookService.BorrowBook(
                id,
                out string message
            );

            Console.WriteLine(message);
        }

        private void ReturnBook()
        {
            ListBooks();

            Console.Write("\nEnter book ID to return: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }

            bool success = bookService.ReturnBook(
                id,
                out string message
            );

            Console.WriteLine(message);
        }
    }
}
