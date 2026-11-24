using Microsoft.EntityFrameworkCore;
using Milestone04_Database.Data;
using Milestone04_Database.Models;

namespace Milestone04_Database.Repositories;

public class BookRepository
{
    public void Add(Book book)
    {
        using LibraryDbContext db = new();

        db.Books.Add(book);
        db.SaveChanges();
    }

    public List<Book> GetAll()
    {
        using LibraryDbContext db = new();

        return db.Books
            .Include(b => b.User)
            .ToList();
    }

    public Book? GetById(int id)
    {
        using LibraryDbContext db = new();

        return db.Books
            .Include(b => b.User)
            .FirstOrDefault(b => b.Id == id);
    }

    public List<Book> GetByUserId(int userId)
    {
        using LibraryDbContext db = new();

        return db.Books
            .Where(b => b.UserId == userId)
            .ToList();
    }

    public List<Book> Search(int userId, string searchTerm)
    {
        using LibraryDbContext db = new();

        string term = searchTerm.ToLower();

        return db.Books
            .Where(b => b.UserId == userId &&
                (b.Title.ToLower().Contains(term) ||
                 b.Author.ToLower().Contains(term) ||
                 b.Genre.ToLower().Contains(term)))
            .ToList();
    }

    public bool Delete(int bookId, int userId)
    {
        using LibraryDbContext db = new();

        Book? book = db.Books.FirstOrDefault(
            b => b.Id == bookId && b.UserId == userId);

        if (book == null)
        {
            return false;
        }

        db.Books.Remove(book);
        db.SaveChanges();

        return true;
    }

    public bool Borrow(int bookId, int userId)
    {
        using LibraryDbContext db = new();

        Book? book = db.Books.FirstOrDefault(
            b => b.Id == bookId &&
                 b.UserId == userId &&
                 b.IsAvailable);

        if (book == null)
        {
            return false;
        }

        book.IsAvailable = false;
        db.SaveChanges();

        return true;
    }

    public bool Return(int bookId, int userId)
    {
        using LibraryDbContext db = new();

        Book? book = db.Books.FirstOrDefault(
            b => b.Id == bookId &&
                 b.UserId == userId &&
                 !b.IsAvailable);

        if (book == null)
        {
            return false;
        }

        book.IsAvailable = true;
        db.SaveChanges();

        return true;
    }
}