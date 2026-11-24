namespace Milestone04_Database.Models;

public class User
{
    public int Id { get; set; }

    public string Username { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    // One user can own many books
    public List<Book> Books { get; set; } = new();
}