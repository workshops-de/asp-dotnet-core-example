using System.Collections.Generic;
using BookMonkey.Models;

namespace BookMonkey.Services
{
    public interface IBookService
    {
        IList<Book> GetAllBooks();
    }
}