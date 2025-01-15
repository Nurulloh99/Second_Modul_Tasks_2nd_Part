using Book.Service.DTOs;
using Book.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Boook.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBookService _bookService;

        public BookController()
        {
            _bookService = new BookService();
        }

        [HttpPost("Add book")]

        public Guid AddBook(BookDto book)
        {
            return _bookService.AddBook(book);
        }


        [HttpGet("Get all books")]

        public List<BookDto> GetAllBooks()
        {
            return _bookService.GetAllBooks();
        }


        [HttpDelete("Delete book")]

        public void RemoveBook(Guid bookId)
        {
            _bookService.RemoveBook(bookId);
        }


        [HttpPut("Update book")]

        public void UpdateBook(BookDto book)
        {
            _bookService.UpdateBook(book);
        }


        [HttpGet("Get book by ID")]

        public BookDto GetBookById(Guid bookId)
        {
            return _bookService.GetBookById(bookId);
        }


        [HttpGet("Get all books by author")]

        public List<BookDto> GetAllBooksByAuthor(string author)
        {
            return _bookService.GetAllBooksByAuthor(author);
        }


        [HttpGet("Get all books by description")]

        public List<BookDto> GetAllBooksByDescription(string description)
        {
            return _bookService.GetAllBooksByDescription(description);
        }


        [HttpGet("Get top rated book")]

        public BookDto GetTopRatedBook()
        {
            return _bookService.GetTopRatedBook();
        }


        [HttpGet("Get books published after year")]

        public List<BookDto> GetBooksPublishedAfterYear(int year)
        {
            return _bookService.GetBooksPublishedAfterYear(year);
        }


        [HttpGet("Get most popular book")]

        public BookDto GetMostPopularBook()
        {
            return _bookService.GetMostPopularBook();
        }


        [HttpGet("Search books by title")]

        public List<BookDto> SearchBooksByTitle(string keyword)
        {
            return _bookService.SearchBooksByTitle(keyword);
        }


        [HttpGet("Get books within page range")]

        public List<BookDto> GetBooksWithinPageRange(int minPages, int maxPages)
        {
            return _bookService.GetBooksWithinPageRange(minPages, maxPages);
        }


        [HttpGet("Get total copies sold by author")]

        public int GetTotalCopiesSoldByAuthor(string author)
        {
            return _bookService.GetTotalCopiesSoldByAuthor(author);
        }


        [HttpGet("Get books sorted by rating")]

        public List<BookDto> GetBooksSortedByRating()
        {
            return _bookService.GetBooksSortedByRating();
        }


        [HttpGet("Get recent books")]

        public List<BookDto> GetRecentBooks(int years)
        {
            return _bookService.GetRecentBooks(years);
        }  
    }
}

//Guid AddBook(BookDto book);
//BookDto GetBookById(Guid bookId);
//List<BookDto> GetAllBooks();
//void RemoveBook(Guid bookId);
//void UpdateBook(BookDto book);
//List<BookDto> GetAllBooksByAuthor(string author);
//List<BookDto> GetAllBooksByDescription(string description);
//BookDto GetTopRatedBook(); // rating eng baland kitob qaytarilsin
//List<BookDto> GetBooksPublishedAfterYear(int year); // year yilidan keyin nashr bo'lgan kitoblarni qaytarilsin
//BookDto GetMostPopularBook(); // eng ko'p sotilgan kitob qaytarilsin
//List<BookDto> SearchBooksByTitle(string keyword); // titleda keyword qatnashgan kitoblar royxati qaytsin
//List<BookDto> GetBooksWithinPageRange(int minPages, int maxPages);
//int GetTotalCopiesSoldByAuthor(string author); // author ga tegishli sotilgan kitoblar soni qaytarilsin
//List<BookDto> GetBooksSortedByRating(); // ratinga qarab sortlab bering. Kattadan kichikga
//List<BookDto> GetRecentBooks(int years); // shu yil ichida nashr qilingan kitoblar royxati qaytarilsin.

