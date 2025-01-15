using System.Text.Json;
using Book.DataAccess.Entities;

namespace Book.Repository.Services;

public class BookServiceRepository : IBookServiceRepository
{
    private string _path;
    private string _directoryPath;

    private List<Boook> _books;

    public BookServiceRepository()
    {
        _path = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Music.json");
        _directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Data");

        _books = new List<Boook>();
        if (!Directory.Exists(_directoryPath))
        {
            Directory.CreateDirectory(_directoryPath);
        }
        if (!File.Exists(_path))
        {
            File.WriteAllText(_path, "[]");
        }

        

        _books = ReadAllBooks();
    }

    public void SaveData()
    {
        var fileJson = JsonSerializer.Serialize(_books);
        File.WriteAllText(_path, fileJson);
    }

    public List<Boook> ReadAllBooks()
    {
        var fileReasult = File.ReadAllText(_path);
        var fileJson = JsonSerializer.Deserialize<List<Boook>>(fileReasult);
        return fileJson;
    }

    public Boook ReadBookById(Guid bookId)
    {
        var result = _books.FirstOrDefault(bk => bk.Id == bookId);

        if (result == null)
        {
            throw new Exception("EXEPTION");
        }

        return result;
    }

    public void RemoveBook(Guid bookId)
    {
        var findBook = ReadBookById(bookId);
        _books.Remove(findBook);
        SaveData();
    }

    public void UpdateBook(Boook book)
    {
        var findBook = ReadBookById(book.Id);
        var index = _books.IndexOf(findBook);
        _books[index] = book;
        SaveData();
    }

    public Guid WriteBook(Boook book)
    {
        _books.Add(book);
        SaveData();
        return book.Id;
    }
}
