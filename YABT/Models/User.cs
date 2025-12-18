using System.ComponentModel;
using MongoDB.Bson.Serialization.Attributes;
using YABT.IServices;

namespace YABT.Models;

public enum Roles
{
    [Description("Admin")]
    Admin,
    [Description("User")]
    User
}

public class User : IEntity
{
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string Id { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
    public string Email { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public DateTime? RegistrationDate { get; set; }
    public bool EmailConfirmed { get; set; }
    public DateTime? LastActivityDate { get; set; }
    public Roles Role { get; set; }
    public bool IsActive { get; set; }
}