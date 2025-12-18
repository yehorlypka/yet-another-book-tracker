using YABT.Models;

namespace YABT.IServices;

public interface IUserService
{
    public void AddOrUpdateOne(User user);
    public void DeleteOne(string id);
    public User? GetOne(string id);
    public List<User> GetAll();
    
    public User? GetUserByEmail(string email);
}