using System.Threading.Tasks;
using BookMonkey.Services;
using BookMonkey.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookMonkey.Controllers
{
    [Authorize]
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

            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpPut]
        [Route("{isbn}")]
        public async Task<IActionResult> UpdateBook(string isbn, [FromBody] Book book)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var fromFromDb = await _bookService.GetByIsbn(isbn);

            if (fromFromDb == null)
                return NotFound();

            await _bookService.UpdateBook(book);
            return Ok();
        }

        [HttpGet]
        [Route("{isbn}/authors")]
        public async Task<IActionResult> GetAuthorsOfBook(string isbn)
        {
            var authors = await _bookService.GetAuthorsOfBook(isbn);

            if (authors == null)
                return NotFound();

            return Ok(authors);
        }
    }
}