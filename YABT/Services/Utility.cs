using System.ComponentModel;
using YABT.Models;

namespace YABT.Services;

public static class Utility
{
    public static string GetEnumDescription(Enum status)
    {
        var field = status.GetType().GetField(status.ToString());
        var attr = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
        return attr?.Description ?? status.ToString();
    }
    
    public static string ComputeBookHash(Book book)
    {
        var input = $"{book.ISBN13}|{book.ISBN10}|{book.Title}|{string.Join(",", book.Authors)}";
        using var sha = System.Security.Cryptography.SHA256.Create();
        var hash = sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input));
        return Convert.ToHexString(hash);
    }
}