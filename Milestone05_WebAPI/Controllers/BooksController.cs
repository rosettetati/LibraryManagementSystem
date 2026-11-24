using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Milestone05_WebAPI.Data;
using Milestone05_WebAPI.DTOs;
using Milestone05_WebAPI.Models;

namespace Milestone05_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly LibraryDbContext _db;

        public BooksController(LibraryDbContext db)
        {
            _db = db;
        }

        // GET: api/books
        [HttpGet]
        public async Task<ActionResult<List<BookResponseDto>>> GetBooks()
        {
            List<Book> books = await _db.Books.ToListAsync();

            List<BookResponseDto> result = books.Select(MapToDto).ToList();

            return Ok(result);
        }

        // GET: api/books/1
        [HttpGet("{id}")]
        public async Task<ActionResult<BookResponseDto>> GetBook(int id)
        {
            Book? book = await _db.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(MapToDto(book));
        }

        // POST: api/books
        [HttpPost]
        public async Task<ActionResult<BookResponseDto>> CreateBook(
            BookCreateDto dto)
        {
            if (dto.PublicationYear > DateTime.Now.Year)
            {
                return BadRequest("Publication year cannot be in the future.");
            }

            bool userExists = await _db.Users.AnyAsync(u => u.Id == dto.UserId);

            if (!userExists)
            {
                return BadRequest("The specified user does not exist.");
            }

            Book book = new Book
            {
                Title = dto.Title,
                Author = dto.Author,
                Genre = dto.Genre,
                PublicationYear = dto.PublicationYear,
                IsAvailable = true,
                UserId = dto.UserId
            };

            _db.Books.Add(book);
            await _db.SaveChangesAsync();

            BookResponseDto result = MapToDto(book);

            return CreatedAtAction(
                nameof(GetBook),
                new { id = book.Id },
                result);
        }

        // PUT: api/books/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(
            int id,
            BookUpdateDto dto)
        {
            Book? book = await _db.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            if (dto.PublicationYear > DateTime.Now.Year)
            {
                return BadRequest("Publication year cannot be in the future.");
            }

            book.Title = dto.Title;
            book.Author = dto.Author;
            book.Genre = dto.Genre;
            book.PublicationYear = dto.PublicationYear;
            book.IsAvailable = dto.IsAvailable;

            await _db.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/books/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            Book? book = await _db.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            _db.Books.Remove(book);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        // Convert database entity into response DTO
        private static BookResponseDto MapToDto(Book book)
        {
            return new BookResponseDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Genre = book.Genre,
                PublicationYear = book.PublicationYear,
                IsAvailable = book.IsAvailable,
                UserId = book.UserId
            };
        }
    }
}