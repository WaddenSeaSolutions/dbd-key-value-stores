using MongoExample.Domain.ValueObjects;

namespace MongoExample.Core.Models;

public class User
{
    public UserId Id { get; set; }
    public string Name { get; set; }
    public string Handle { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}