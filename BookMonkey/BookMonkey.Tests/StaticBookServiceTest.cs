using System.Threading.Tasks;
using BookMonkey.Services;
using Xunit;

namespace BookMonkey.Tests
{
    public class StaticBookServiceTest
    {
        private readonly StaticBookService _subject;

        public StaticBookServiceTest()
        {
            _subject = new StaticBookService();
        }

        [Fact]
        public async Task Fetching_all_books_will_return_the_contained_book_list()
        {
            var books = await _subject.GetAllBooks();

            Assert.NotEmpty(books);
            Assert.True(books.Count == 3);
        }

        [Fact]
        public async Task Trying_to_fetch_a_non_existent_book_will_yield_null()
        {
            var book = await _subject.GetByIsbn("12345");

            Assert.Null(book);
        }

        [Fact]
        public async Task Trying_to_fetch_an_existent_book_should_return_the_book()
        {
            const string isbn = "978-3-86490-120-1";
            var book = await _subject.GetByIsbn(isbn);

            Assert.NotNull(book);
            Assert.Equal(book.Isbn, isbn);
        }

        [Fact]
        public async Task Trying_to_fetch_the_authors_of_an_non_existent_book_will_return_null()
        {
            var authors = await _subject.GetAuthorsOfBook("12345");

            Assert.Null(authors);
        }

        [Fact]
        public async Task Trying_to_fetch_the_authors_of_an_existent_book_will_return_a_string_list_of_authors()
        {
            const string isbn = "978-3-86490-120-1";
            var authors = await _subject.GetAuthorsOfBook(isbn);

            Assert.NotEmpty(authors);
            Assert.True(authors.Count == 4);
        }

        [Fact]
        public async Task Updating_a_book_will_set_changed_values_accordingly()
        {
            const string isbn = "978-3-86490-120-1";
            const string newtitle = "NewTitle";
            var book = await _subject.GetByIsbn(isbn);

            book.Title = newtitle;
            await _subject.UpdateBook(book);

            var supposedlyUpdatedBook = await _subject.GetByIsbn(isbn);
            Assert.Equal(supposedlyUpdatedBook.Title, newtitle);
        }
    }
}
