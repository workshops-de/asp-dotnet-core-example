using System.Collections.Generic;
using System.Linq;
using BookMonkey.Services.Database;
using BookMonkey.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace BookMonkey.Services
{
    public class DbBookService : IBookService
    {
        public IList<Book> GetAllBooks()
        {
            using (var context = new BookMonkeyContext())
            {
                return context.Books.Include(b => b.Publisher).Select(b => new Book
                {
                    BookId = b.Id,
                    Isbn = b.Isbn,
                    Abstract = b.Abstract,
                    Publisher = b.Publisher.Name,
                    Subtitle = b.Subtitle,
                    NumPages = (int) b.NumPages,
                    Author = b.Author,
                    Title = b.Title
                }).ToList();
            }
        }

        public Book GetByIsbn(string isbn)
        {
            using (var context = new BookMonkeyContext())
            {
                var book = context.Books.Include(b => b.Publisher).FirstOrDefault(b => b.Isbn == isbn);
                return new Book
                {
                    BookId = book.Id,
                    Isbn = book.Isbn,
                    Abstract = book.Abstract,
                    Publisher = book.Publisher.Name,
                    Subtitle = book.Subtitle,
                    NumPages = (int)book.NumPages,
                    Author = book.Author,
                    Title = book.Title
                };
            }
        }

        public void UpdateBook(Book book)
        {
            using (var context = new BookMonkeyContext())
            {
                var dbBook = context.Books.Include(b => b.Publisher).FirstOrDefault(b => b.Id == book.BookId);

                dbBook.Isbn = book.Isbn;
                dbBook.Abstract = book.Abstract;
                dbBook.Publisher.Name = book.Publisher;
                dbBook.Subtitle = book.Subtitle;
                dbBook.NumPages = book.NumPages;
                dbBook.Author = book.Author;
                dbBook.Title = book.Title;

                context.SaveChanges();
            }
        }
    }
}