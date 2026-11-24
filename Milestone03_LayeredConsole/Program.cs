using Milestone03_LayeredConsole.Repositories;
using Milestone03_LayeredConsole.Services;
using Milestone03_LayeredConsole.Presentation;

class Program
{
    static void Main()
    {
        // Repositories
        UserRepository userRepository = new();
        BookRepository bookRepository = new();

        // Services
        UserService userService = new(userRepository);
        BookService bookService = new(bookRepository, userService);

        // Presentation
        LibraryMenu libraryMenu = new(bookService, userService);
        MainMenu mainMenu = new(userService, libraryMenu);

        // Start application
        mainMenu.Run();
    }
}