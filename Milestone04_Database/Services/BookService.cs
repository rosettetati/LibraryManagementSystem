
using Milestone04_Database.Models;
using Milestone04_Database.Repositories;

namespace Milestone04_Database.Services;

public class BookService
{
    private readonly BookRepository _bookRepository;

    public BookService()
    {
        _bookRepository = new BookRepository();
    }

    public bool AddBook(Book book)
    {
        if (string.IsNullOrWhiteSpace(book.Title))
            return false;

        if (string.IsNullOrWhiteSpace(book.Author))
            return false;

        if (book.PublicationYear < 0 || book.PublicationYear > DateTime.Now.Year)
            return false;

        _bookRepository.Add(book);
        return true;
    }

    public List<Book> GetBooks(int userId)
    {
        return _bookRepository.GetByUserId(userId);
    }

    public List<Book> SearchBooks(int userId, string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return new List<Book>();

        return _bookRepository.Search(userId, searchTerm);
    }

    public bool DeleteBook(int bookId, int userId)
    {
        return _bookRepository.Delete(bookId, userId);
    }

    public bool BorrowBook(int bookId, int userId)
    {
        return _bookRepository.Borrow(bookId, userId);
    }

    public bool ReturnBook(int bookId, int userId)
    {
        return _bookRepository.Return(bookId, userId);
    }
}
