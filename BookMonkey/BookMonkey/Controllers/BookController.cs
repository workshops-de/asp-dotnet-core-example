using System.Threading.Tasks;
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

        public async Task<IActionResult> Index()
        {
            return View(await _bookService.GetAllBooks());
        }

        public async Task<IActionResult> Detail(string id)
        {
            var book = await _bookService.GetByIsbn(id);
            return View(book);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var book = await _bookService.GetByIsbn(id);
            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Book book)
        {
            if (!ModelState.IsValid)
                return View(book);

            await _bookService.UpdateBook(book);
            return RedirectToAction(nameof(Detail), new { id = book.Isbn });
        }
    }
}