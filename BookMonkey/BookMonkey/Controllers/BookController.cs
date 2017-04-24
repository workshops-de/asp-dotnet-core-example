using BookMonkey.Services;
using BookMonkey.Services.Models;
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

        public IActionResult Edit(string id)
        {
            var book = _bookService.GetByIsbn(id);
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (!ModelState.IsValid)
                return View(book);

            _bookService.UpdateBook(book);
            return RedirectToAction(nameof(Detail), new { id = book.Isbn });
        }
    }
}