using MongoDB.Driver;
using YABT.IServices;
using YABT.Models;

namespace YABT.Services;

public class BookService:MongoService<Book>, IBookService
{
    public BookService() : base("books") { }
    
}