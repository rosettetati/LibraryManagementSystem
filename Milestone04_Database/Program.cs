
using Milestone04_Database.Data;
using Milestone04_Database.Presentation;

class Program
{
    static void Main()
    {
        using (LibraryDbContext db = new())
        {
            db.Database.EnsureCreated();
        }

        Console.WriteLine("Database initialized successfully!");

        LibraryApp app = new LibraryApp();
        app.Run();
    }
}
