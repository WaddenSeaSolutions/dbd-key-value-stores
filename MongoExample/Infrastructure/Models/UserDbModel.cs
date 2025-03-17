using MongoDB.Bson;

namespace MongoExample.Infrastructure.Models;

public class UserDbModel
{
    public ObjectId Id { get; set; }
    public string Name { get; set; }
    public string Handle { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}