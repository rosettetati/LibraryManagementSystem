namespace Milestone03_LayeredConsole.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;

        public string Genre { get; set; } = string.Empty;

        public int PublicationYear { get; set; }

        public bool IsAvailable { get; set; } = true;

        // Identifies the user who added this book
        public int OwnerUserId { get; set; }

        public Book()
        {
        }

        public Book(
            int id,
            string title,
            string author,
            string genre,
            int publicationYear,
            int ownerUserId)
        {
            Id = id;
            Title = title;
            Author = author;
            Genre = genre;
            PublicationYear = publicationYear;
            OwnerUserId = ownerUserId;
            IsAvailable = true;
        }

        public void DisplayInfo()
        {
            Console.WriteLine(
                $"ID: {Id} | Title: {Title} | Author: {Author} | " +
                $"Genre: {Genre} | Year: {PublicationYear} | " +
                $"Available: {IsAvailable}");
        }
    }
}