using System;
using System.Collections.Generic;
using System.Linq;
using Milestone03_LayeredConsole.Models;
using Milestone03_LayeredConsole.Repositories;

namespace Milestone03_LayeredConsole.Services
{
    public class BookService
    {
        private readonly BookRepository bookRepository;
        private readonly UserService userService;

        public BookService(
            BookRepository bookRepository,
            UserService userService)
        {
            this.bookRepository = bookRepository;
            this.userService = userService;
        }

        // Add a book for the currently logged-in user
        public bool AddBook(
            string title,
            string author,
            string genre,
            int publicationYear,
            out string message)
        {
            if (userService.CurrentUser == null)
            {
                message = "You must log in first.";
                return false;
            }

            title = title.Trim();
            author = author.Trim();
            genre = genre.Trim();

            if (string.IsNullOrWhiteSpace(title) ||
                string.IsNullOrWhiteSpace(author) ||
                string.IsNullOrWhiteSpace(genre))
            {
                message = "Title, author, and genre are required.";
                return false;
            }

            if (publicationYear < 0 ||
                publicationYear > DateTime.Now.Year)
            {
                message = "Invalid publication year.";
                return false;
            }

            List<Book> books = bookRepository.GetAll();

            int newId = books.Count == 0
                ? 1
                : books.Max(book => book.Id) + 1;

            Book newBook = new Book(
                newId,
                title,
                author,
                genre,
                publicationYear,
                userService.CurrentUser.Id
            );

            books.Add(newBook);
            bookRepository.SaveAll(books);

            message = "Book added successfully!";
            return true;
        }

        // Get only the books belonging to the logged-in user
        public List<Book> GetMyBooks()
        {
            if (userService.CurrentUser == null)
            {
                return new List<Book>();
            }

            return bookRepository.GetByOwnerId(
                userService.CurrentUser.Id
            );
        }

        // Search only the logged-in user's books
        public List<Book> FindMyBooks(string search)
        {
            if (userService.CurrentUser == null ||
                string.IsNullOrWhiteSpace(search))
            {
                return new List<Book>();
            }

            search = search.Trim();

            return GetMyBooks()
                .Where(book =>
                    book.Title.Contains(
                        search,
                        StringComparison.OrdinalIgnoreCase
                    )
                    ||
                    book.Author.Contains(
                        search,
                        StringComparison.OrdinalIgnoreCase
                    )
                    ||
                    book.Genre.Contains(
                        search,
                        StringComparison.OrdinalIgnoreCase
                    ))
                .ToList();
        }

        // Delete only a book belonging to the logged-in user
        public bool DeleteBook(int bookId, out string message)
        {
            if (userService.CurrentUser == null)
            {
                message = "You must log in first.";
                return false;
            }

            List<Book> books = bookRepository.GetAll();

            Book? book = books.FirstOrDefault(
                b => b.Id == bookId &&
                     b.OwnerUserId == userService.CurrentUser.Id
            );

            if (book == null)
            {
                message = "Book not found in your library.";
                return false;
            }

            books.Remove(book);
            bookRepository.SaveAll(books);

            message = "Book deleted successfully!";
            return true;
        }

        // Borrow one of your books
        public bool BorrowBook(int bookId, out string message)
        {
            if (userService.CurrentUser == null)
            {
                message = "You must log in first.";
                return false;
            }

            List<Book> books = bookRepository.GetAll();

            Book? book = books.FirstOrDefault(
                b => b.Id == bookId &&
                     b.OwnerUserId == userService.CurrentUser.Id
            );

            if (book == null)
            {
                message = "Book not found in your library.";
                return false;
            }

            if (!book.IsAvailable)
            {
                message = "This book is already borrowed.";
                return false;
            }

            book.IsAvailable = false;
            bookRepository.SaveAll(books);

            message = "Book borrowed successfully!";
            return true;
        }

        // Return one of your books
        public bool ReturnBook(int bookId, out string message)
        {
            if (userService.CurrentUser == null)
            {
                message = "You must log in first.";
                return false;
            }

            List<Book> books = bookRepository.GetAll();

            Book? book = books.FirstOrDefault(
                b => b.Id == bookId &&
                     b.OwnerUserId == userService.CurrentUser.Id
            );

            if (book == null)
            {
                message = "Book not found in your library.";
                return false;
            }

            if (book.IsAvailable)
            {
                message = "This book is already available.";
                return false;
            }

            book.IsAvailable = true;
            bookRepository.SaveAll(books);

            message = "Book returned successfully!";
            return true;
        }
    }
}