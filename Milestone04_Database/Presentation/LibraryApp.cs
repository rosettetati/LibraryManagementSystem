using Milestone04_Database.Models;
using Milestone04_Database.Services;

namespace Milestone04_Database.Presentation;

public class LibraryApp
{
    private readonly UserService _userService;
    private readonly BookService _bookService;

    public LibraryApp()
    {
        _userService = new UserService();
        _bookService = new BookService();
    }

    public void Run()
    {
        bool running = true;

        while (running)
        {
            ConsoleUI.ShowMainMenu();
            string choice = Console.ReadLine() ?? string.Empty;

            switch (choice)
            {
                case "1":
                    Register();
                    break;

                case "2":
                    Login();
                    break;

                case "3":
                    running = false;
                    ConsoleUI.ShowMessage("Goodbye!");
                    break;

                default:
                    ConsoleUI.ShowMessage("Invalid option.");
                    break;
            }
        }
    }

    private void Register()
    {
        string username = ConsoleUI.ReadInput("Enter username: ");
        string password = ConsoleUI.ReadInput("Enter password: ");

        bool success = _userService.RegisterUser(username, password);

        if (success)
            ConsoleUI.ShowMessage("Registration successful!");
        else
            ConsoleUI.ShowMessage(
                "Registration failed. Username may already exist or input is invalid.");

        ConsoleUI.Pause();
    }

    private void Login()
    {
        string username = ConsoleUI.ReadInput("Enter username: ");
        string password = ConsoleUI.ReadInput("Enter password: ");

        User? user = _userService.Login(username, password);

        if (user == null)
        {
            ConsoleUI.ShowMessage("Invalid username or password.");
            ConsoleUI.Pause();
            return;
        }

        ConsoleUI.ShowMessage($"Welcome, {user.Username}!");
        LibraryMenu(user);
    }

    private void LibraryMenu(User user)
    {
        bool loggedIn = true;

        while (loggedIn)
        {
            ConsoleUI.ShowLibraryMenu(user.Username);
            string choice = Console.ReadLine() ?? string.Empty;

            switch (choice)
            {
                case "1":
                    AddBook(user);
                    break;

                case "2":
                    ListBooks(user);
                    break;

                case "3":
                    SearchBooks(user);
                    break;

                case "4":
                    BorrowBook(user);
                    break;

                case "5":
                    ReturnBook(user);
                    break;

                case "6":
                    DeleteBook(user);
                    break;

                case "7":
                    loggedIn = false;
                    ConsoleUI.ShowMessage("Logged out.");
                    break;

                default:
                    ConsoleUI.ShowMessage("Invalid option.");
                    ConsoleUI.Pause();
                    break;
            }
        }
    }

    private void AddBook(User user)
    {
        string title = ConsoleUI.ReadInput("Title: ");
        string author = ConsoleUI.ReadInput("Author: ");
        string genre = ConsoleUI.ReadInput("Genre: ");
        int year = ConsoleUI.ReadInt("Publication year: ");

        Book book = new Book
        {
            Title = title,
            Author = author,
            Genre = genre,
            PublicationYear = year,
            IsAvailable = true,
            UserId = user.Id
        };

        bool success = _bookService.AddBook(book);

        ConsoleUI.ShowMessage(
            success ? "Book added successfully!" : "Invalid book information.");

        ConsoleUI.Pause();
    }

    private void ListBooks(User user)
    {
        List<Book> books = _bookService.GetBooks(user.Id);
        ConsoleUI.DisplayBooks(books);
        ConsoleUI.Pause();
    }

    private void SearchBooks(User user)
    {
        string searchTerm = ConsoleUI.ReadInput("Search term: ");

        List<Book> books = _bookService.SearchBooks(user.Id, searchTerm);

        ConsoleUI.DisplayBooks(books);
        ConsoleUI.Pause();
    }

    private void BorrowBook(User user)
    {
        int bookId = ConsoleUI.ReadInt("Book ID to borrow: ");

        bool success = _bookService.BorrowBook(bookId, user.Id);

        ConsoleUI.ShowMessage(
            success ? "Book borrowed successfully!" :
            "Book not found or already borrowed.");

        ConsoleUI.Pause();
    }

    private void ReturnBook(User user)
    {
        int bookId = ConsoleUI.ReadInt("Book ID to return: ");

        bool success = _bookService.ReturnBook(bookId, user.Id);

        ConsoleUI.ShowMessage(
            success ? "Book returned successfully!" :
            "Book not found or is not currently borrowed.");

        ConsoleUI.Pause();
    }

    private void DeleteBook(User user)
    {
        int bookId = ConsoleUI.ReadInt("Book ID to delete: ");

        bool success = _bookService.DeleteBook(bookId, user.Id);

        ConsoleUI.ShowMessage(
            success ? "Book deleted successfully!" :
            "Book not found.");

        ConsoleUI.Pause();
    }
}