using System.ComponentModel;
using MongoDB.Bson.Serialization.Attributes;
using YABT.IServices;

namespace YABT.Models;

public enum ReadingStatus
{
    [Description("To read")]
    ToRead, 
    [Description("Reading")]
    Reading, 
    [Description("Finished")]
    Finished,
    [Description("Dropped")]
    Dropped
}

public class LibraryEntry : IEntity
{
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string Id { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
    public string UserID { get; set; }
    public string BookID { get; set; }
    public ReadingStatus Status { get; set; } = ReadingStatus.ToRead;
    public int Score { get; set; } = -1;
    public string Comment { get; set; }
    public int CustomPageCount { get; set; } = -1;
    public int CurrentPage { get; set; } = -1;
    public DateTime? DateAdded { get; set; }
    public DateTime? DateStarted { get; set; }
    public DateTime? DateCompleted { get; set; }
    public DateTime? LastUpdate { get; set; }
    public bool IsFavorite { get; set; }
    public bool IsDeleted { get; set; }

    public LibraryEntry(string userID, string bookID, ReadingStatus status)
    {
        UserID = userID;
        BookID = bookID;
        Status = status;
        DateAdded = DateTime.UtcNow;
        LastUpdate = DateTime.UtcNow;
    }

    public LibraryEntry() { }
}