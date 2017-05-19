using System.Collections.Generic;
using System.Threading.Tasks;
using BookMonkey.Controllers;
using BookMonkey.Services;
using BookMonkey.Services.Models;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Xunit;

namespace BookMonkey.Tests
{
    public class BookApiControllerTest
    {
        private readonly BookApiController _subject;
        private readonly IBookService _serviceMock;

        public BookApiControllerTest()
        {
            _serviceMock = Substitute.For<IBookService>();
            _subject = new BookApiController(_serviceMock);
        }

        [Fact]
        public async Task Asking_the_controller_for_all_books_will_return_200_OK_with_all_the_books_returned_by_the_service()
        {
            var fakeBookList = new List<Book> { new Book() };
            _serviceMock.GetAllBooks().Returns(Task.FromResult<IList<Book>>(fakeBookList));

            var result = await _subject.GetAllBooks();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IList<Book>>(okResult.Value);
            Assert.Equal(fakeBookList.Count, model.Count);
        }

        [Fact]
        public async Task Asking_the_controller_for_an_existing_book_will_return_200_OK()
        {
            const string isbn = "1234";
            var book = new Book();
            _serviceMock.GetByIsbn(isbn).Returns(Task.FromResult(book));

            var result = await _subject.GetBook(isbn);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<Book>(okResult.Value);
            Assert.Same(book, model);
        }

        [Fact]
        public async Task Asking_the_controller_for_an_nonexistent_book_will_return_a_404()
        {
            const string isbn = "1234";
            _serviceMock.GetByIsbn(isbn).Returns(Task.FromResult<Book>(null));

            var result = await _subject.GetBook(isbn);

            Assert.IsType<NotFoundResult>(result);
        }
    }
}