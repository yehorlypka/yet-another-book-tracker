using MongoDB.Driver;
using YABT.IServices;
using YABT.Models;
using YABT.ViewModels;

namespace YABT.Services;

public class LibraryEntryService:MongoService<LibraryEntry>, ILibraryEntryService
{
    public LibraryEntryService() : base("user_library") { }
    
    public List<LibraryEntry> GetAllEntriesOfUser(string userId)
    {
        return _collection.Find(u => u.UserID == userId).ToList();
    }

    public LibraryEntry? GetEntryOfUser(string userId, string bookId)
    {
        return _collection.Find(u => u.UserID == userId && u.BookID == bookId).FirstOrDefault();
    }
    
    public async Task<List<LibraryBookViewModel>> GetUserLibraryBooksAsync(string userId)
    {
        // 1) Get all library entries
        var entries = GetAllEntriesOfUser(userId);

        if (!entries.Any())
            return new List<LibraryBookViewModel>();

        // 2) Collect distinct Book IDs
        var bookIds = entries
            .Select(e => e.BookID)
            .Distinct()
            .ToList();

        // 3) Load all books in one query
        BookService bookService = new BookService();
        var books = await bookService._collection
            .Find(b => bookIds.Contains(b.Id))
            .ToListAsync();

        // 4) Join entries + books into view models
        var result = entries.Select(entry => new LibraryBookViewModel
            {
                Entry = entry,
                Book = books.FirstOrDefault(b => b.Id == entry.BookID)
            })
            .Where(vm => vm.Book != null) // safety
            .ToList();

        return result;
    }
}