using Book.DataAccess.Entities;

namespace Book.Repository.Services;

public interface IBookServiceRepository
{
    Guid WriteBook(Boook book);
    Boook ReadBookById(Guid bookId);
    List<Boook> ReadAllBooks();
    void RemoveBook(Guid bookId);
    void UpdateBook(Boook book);
}
