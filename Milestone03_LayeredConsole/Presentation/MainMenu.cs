using System;
using Milestone03_LayeredConsole.Services;

namespace Milestone03_LayeredConsole.Presentation
{
    public class MainMenu
    {
        private readonly UserService userService;
        private readonly LibraryMenu libraryMenu;

        public MainMenu(
            UserService userService,
            LibraryMenu libraryMenu)
        {
            this.userService = userService;
            this.libraryMenu = libraryMenu;
        }

        public void Run()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n===== LIBRARY MANAGEMENT SYSTEM =====");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine() ?? "";

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
                        Console.WriteLine("Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        private void Register()
        {
            Console.WriteLine("\n--- REGISTER ---");

            Console.Write("Enter username: ");
            string username = Console.ReadLine() ?? "";

            Console.Write("Enter password: ");
            string password = Console.ReadLine() ?? "";

            bool success = userService.Register(
                username,
                password,
                out string message
            );

            Console.WriteLine(message);
        }

        private void Login()
        {
            Console.WriteLine("\n--- LOGIN ---");

            Console.Write("Enter username: ");
            string username = Console.ReadLine() ?? "";

            Console.Write("Enter password: ");
            string password = Console.ReadLine() ?? "";

            bool success = userService.Login(
                username,
                password,
                out string message
            );

            Console.WriteLine(message);

            if (success)
            {
                libraryMenu.Run();
            }
        }
    }
}