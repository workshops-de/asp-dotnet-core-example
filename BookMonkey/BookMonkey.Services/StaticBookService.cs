using System.Collections.Generic;
using System.Linq;
using BookMonkey.Services.Models;

namespace BookMonkey.Services
{
    public class StaticBookService : IBookService
    {
        private static readonly IList<Book> _books = new List<Book>
        {
            new Book
            {
                Title = "Design Patterns",
                Subtitle = "Elements of Reusable Object-Oriented Software",
                Isbn = "978-0-20163-361-0",
                Abstract = "Capturing a wealth of experience about the design of object-oriented software, four top-notch designers present a catalog of simple and succinct solutions to commonly occurring design problems. Previously undocumented, these 23 patterns allow designers to create more flexible, elegant, and ultimately reusable designs without having to rediscover the design solutions themselves.",
                NumPages = 395,
                Author = "Erich Gamma / Richard Helm / Ralph E. Johnson / John Vlissides",
                Publisher = "Addison-Wesley"
            },
            new Book
            {
                Title = "REST und HTTP",
                Subtitle = "Entwicklung und Integration nach dem Architekturstil des Web",
                Isbn = "978-3-86490-120-1",
                Abstract = "Das Buch bietet eine theoretisch fundierte, vor allem aber praxistaugliche Anleitung zum professionellen Einsatz von RESTful HTTP. Es beschreibt den Architekturstil REST (Representational State Transfer) und seine Umsetzung im Rahmen der Protokolle des World Wide Web (HTTP, URIs und andere).",
                NumPages = 330,
                Author = "Stefan Tilkov / Martin Eigenbrodt / Silvia Schreier / Oliver Wolf",
                Publisher = "dpunkt.verlag"
            },
            new Book
            {
                Title = "Eloquent JavaScript",
                Subtitle = "A Modern Introduction to Programming",
                Isbn = "978-1-59327-584-6",
                Abstract = "JavaScript lies at the heart of almost every modern web application, from social apps to the newest browser-based games. Though simple for beginners to pick up and play with, JavaScript is a flexible, complex language that you can use to build full-scale applications.",
                NumPages = 472,
                Author = "Marijn Haverbeke",
                Publisher = "No Starch Press"
            },
        };

        public IList<Book> GetAllBooks()
        {
            return new List<Book>(_books);
        }

        public Book GetByIsbn(string isbn)
        {
            return _books.FirstOrDefault(b => b.Isbn == isbn);
        }
    }
}