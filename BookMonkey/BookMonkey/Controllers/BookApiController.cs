using System.Threading.Tasks;
using BookMonkey.Services;
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
    }
}