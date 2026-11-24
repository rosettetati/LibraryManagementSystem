using System.ComponentModel.DataAnnotations;

namespace Milestone05_WebAPI.DTOs
{
    public class BookCreateDto
    {
        [Required]
        [StringLength(150)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Author { get; set; } = string.Empty;

        [StringLength(50)]
        public string Genre { get; set; } = string.Empty;

        [Range(0, 9999)]
        public int PublicationYear { get; set; }

        [Range(1, int.MaxValue)]
        public int UserId { get; set; }
    }
}