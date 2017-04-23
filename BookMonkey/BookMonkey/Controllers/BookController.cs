using BookMonkey.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookMonkey.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public IActionResult Index()
        {
            return View(_bookService.GetAllBooks());
        }

        public IActionResult Detail(string id)
        {
            var book = _bookService.GetByIsbn(id);
            return View(book);
        }
    }
}