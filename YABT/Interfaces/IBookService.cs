using YABT.Models;

namespace YABT.IServices;

public interface IBookService
{
    public void AddOrUpdateOne(Book user);
    public void DeleteOne(string id);
    public Book? GetOne(string id);
    public List<Book> GetAll();
}