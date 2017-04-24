using System.Collections.Generic;
using BookMonkey.Services.Models;

namespace BookMonkey.Services
{
    public interface IBookService
    {
        IList<Book> GetAllBooks();
        Book GetByIsbn(string isbn);
        void UpdateBook(Book book);
    }
}