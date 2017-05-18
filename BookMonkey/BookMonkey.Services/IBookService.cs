using System.Collections.Generic;
using System.Threading.Tasks;
using BookMonkey.Services.Models;

namespace BookMonkey.Services
{
    public interface IBookService
    {
        Task<IList<Book>> GetAllBooks();
        Task<Book> GetByIsbn(string isbn);
        Task UpdateBook(Book book);
    }
}