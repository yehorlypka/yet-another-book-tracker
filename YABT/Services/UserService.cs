using MongoDB.Driver;
using YABT.IServices;
using YABT.Models;

namespace YABT.Services;

public class UserService:MongoService<User>, IUserService
{
    public UserService() : base("users") { }

    public User? GetUserByEmail(string email)
    {
        return _collection.Find(u => u.Email == email).FirstOrDefault();
    }
}