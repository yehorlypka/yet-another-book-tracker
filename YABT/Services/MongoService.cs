using MongoDB.Driver;
using YABT.IServices;

namespace YABT.Services;

public class MongoService<T> where T : IEntity
{
    public readonly IMongoCollection<T> _collection;

    public MongoService(string collectionName)
    {
        var client = new MongoClient("mongodb+srv://yehorlypka:a95chvdYvUjSnqbr@yet-another-book-tracke.zh43d3z.mongodb.net/");
        var database = client.GetDatabase("YABT");
        _collection = database.GetCollection<T>(collectionName);
    }

    public void AddOrUpdateOne(T entry)
    {
        try
        {
            var entryObj = _collection.Find(x => x.Id == entry.Id).FirstOrDefault();
            if (entryObj == null)
            {
                _collection.InsertOne(entry);
            }
            else
            {
                _collection.ReplaceOne(x => x.Id == entry.Id, entry);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void DeleteOne(string id)
    {
        try
        {
            _collection.DeleteOneAsync(u => u.Id == id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public T? GetOne(string id)
    {
        return _collection.Find(u => u.Id == id).FirstOrDefault();
    }

    public List<T> GetAll()
    {
        return _collection.Find(FilterDefinition<T>.Empty).ToList();
    }
}