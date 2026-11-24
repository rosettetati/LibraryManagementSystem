namespace Milestone04_Database.Models;

public class Book
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Author { get; set; } = string.Empty;

    public string Genre { get; set; } = string.Empty;

    public int PublicationYear { get; set; }

    public bool IsAvailable { get; set; } = true;

    // Foreign key
    public int UserId { get; set; }

    // Navigation property
    public User? User { get; set; }
}