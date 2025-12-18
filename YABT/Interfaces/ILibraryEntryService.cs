using YABT.Models;
using YABT.ViewModels;

namespace YABT.IServices;

public interface ILibraryEntryService
{
    public void AddOrUpdateOne(LibraryEntry user);
    public void DeleteOne(string id);
    public LibraryEntry? GetOne(string id);
    public List<LibraryEntry> GetAll();
    public LibraryEntry? GetEntryOfUser(string userId, string bookId);
    public List<LibraryEntry> GetAllEntriesOfUser(string userId);
    public Task<List<LibraryBookViewModel>> GetUserLibraryBooksAsync(string userId);
}