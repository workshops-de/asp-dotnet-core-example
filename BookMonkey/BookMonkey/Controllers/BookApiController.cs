using System.Threading.Tasks;
using BookMonkey.Services;
using BookMonkey.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookMonkey.Controllers
{
    [Produces("application/json")]
    [Route("api/books")]
    public class BookApiController : Controller
    {
        private readonly IBookService _bookService;

        public BookApiController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookService.GetAllBooks();
            return Ok(books);
        }

        [HttpGet]
        [Route("{isbn}")]
        public async Task<IActionResult> GetBook(string isbn)
        {
            var book = await _bookService.GetByIsbn(isbn);
            return Ok(book);
        }

        [HttpPut]
        [Route("{isbn}")]
        public async Task<IActionResult> UpdateBook(string isbn, [FromBody] Book book)
        {
            await _bookService.UpdateBook(book);
            return Ok();
        }
    }
}