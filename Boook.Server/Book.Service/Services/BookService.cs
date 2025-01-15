using Book.DataAccess.Entities;
using Book.Repository.Services;
using Book.Service.DTOs;

namespace Book.Service.Services;

public class BookService : IBookService
{
    private IBookServiceRepository _bookRepo;

    public BookService()
    {
        _bookRepo = new BookServiceRepository();
    }

    public Guid AddBook(BookDto book)
    {
        ValidateBookDto(book);
        var bookConvert = ConvertBookToEntity(book);
        var bookResult = _bookRepo.WriteBook(bookConvert);
        return bookResult;
    }

    public BookDto GetBookById(Guid bookId)
    {
        var getMovieById = _bookRepo.ReadBookById(bookId);
        return ConvertBookToDto(getMovieById);
    }

    public List<BookDto> GetAllBooks()
    {
        return _bookRepo.ReadAllBooks().Select(bk => ConvertBookToDto(bk)).ToList();
    }

    public void RemoveBook(Guid bookId)
    {
        _bookRepo.RemoveBook(bookId);
    }

    public void UpdateBook(BookDto book)
    {
        _bookRepo.UpdateBook(ConvertBookToEntity(book));
    }

    public List<BookDto> GetAllBooksByAuthor(string author)
    {
        return GetAllBooks().Where(bk => bk.Author == author).ToList();
    }

    public BookDto GetTopRatedBook()
    {
        var maxRatedBook = GetAllBooks().Max(bk => bk.Rating);
        var result = GetAllBooks().FirstOrDefault(bk => bk.Rating == maxRatedBook);

        if (result is null)
        {
            throw new Exception("ERROR");
        }

        return result;
    }

    public List<BookDto> GetBooksPublishedAfterYear(int year)
    {
        return GetAllBooks().Where(bk => bk.PublishedDate.Year == year).ToList();
    }

    public BookDto GetMostPopularBook()
    {
        var popularBook = GetAllBooks().Max(bk => bk.Rating);
        var result = GetAllBooks().FirstOrDefault(bk => bk.Rating == popularBook);

        if (result is null)
        {
            throw new Exception("ERROR");
        }

        return result;
    }

    public List<BookDto> SearchBooksByTitle(string keyword)
    {
        return GetAllBooks().Where(bk => bk.Title.Contains(keyword)).ToList();
    }

    public List<BookDto> GetBooksWithinPageRange(int minPages, int maxPages)
    {
        return GetAllBooks().Where(bk => bk.Pages > minPages && bk.Pages < maxPages).ToList();
    }

    public int GetTotalCopiesSoldByAuthor(string author)
    {
        return GetAllBooks().Where(bk => bk.Author == author).Sum(bok => bok.NumberOfCopiesSold);
    }

    public List<BookDto> GetBooksSortedByRating()
    {
        return GetAllBooks().OrderBy(bk => bk.Rating).ToList();
    }

    public List<BookDto> GetRecentBooks(int years)
    {
        return GetAllBooks().Where(bk => bk.PublishedDate.Year == years).ToList();
    }

    public List<BookDto> GetAllBooksByDescription(string description)
    {
        return GetAllBooks().Where(bk => bk.Description.Contains(description)).ToList();
    }

    private void ValidateBookDto(BookDto book)
    {
        if (string.IsNullOrEmpty(book.Title) || book.Title.Length > 30 || book.Title.Length < 1)
        {
            throw new Exception("TITLE EXEPTION");
        }

        if (string.IsNullOrEmpty(book.Author) || book.Author.Length > 30 || book.Author.Length < 1)
        {
            throw new Exception("AUTHOR EXEPTION");
        }

        if (book.Pages < 5 || book.Pages > 600)
        {
            throw new Exception("PAGES EXEPTION");
        }

        if (book.Rating < 1 || book.Rating > 10)
        {
            throw new Exception("RATING EXEPTION");
        }
    }

    private Boook ConvertBookToEntity(BookDto book)
    {
        return new Boook
        {
            Id = book.Id ?? Guid.NewGuid(),
            Title = book.Title,
            Author = book.Author,
            Description = book.Description,
            Pages = book.Pages,
            Rating = book.Rating,
            NumberOfCopiesSold = book.NumberOfCopiesSold,
            PublishedDate = book.PublishedDate,
        };
    }

    private BookDto ConvertBookToDto(Boook book)
    {
        return new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            Description = book.Description,
            Pages = book.Pages,
            Rating = book.Rating,
            NumberOfCopiesSold = book.NumberOfCopiesSold,
            PublishedDate = book.PublishedDate,
        };
    }
}