namespace Milestone05_WebAPI.DTOs
{
    public class BookResponseDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;

        public string Genre { get; set; } = string.Empty;

        public int PublicationYear { get; set; }

        public bool IsAvailable { get; set; }

        public int UserId { get; set; }
    }
}