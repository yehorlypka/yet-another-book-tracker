using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using YABT.IServices;
using YABT.Services;

namespace YABT.Models;

public class Book : IEntity
{
    // [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    // public string Id { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
    [BsonId]                                // marks it as the _id field
    [BsonRepresentation(BsonType.String)]   // store as string
    public string Id { get; set; }
    public string ISBN10 { get; set; }
    public string ISBN13 { get; set; }
    public string Title { get; set; }
    public List<string> Authors { get; set; } = new List<string>();
    public string Description { get; set; }
    public string Publisher { get; set; }
    public List<string> Categories { get; set; } = new List<string>();
    public int PageCount { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public string Language { get; set; }
    public string CoverImageURL { get; set; }
    
    public Book()
    {
        Id = Utility.ComputeBookHash(this);
    }
}