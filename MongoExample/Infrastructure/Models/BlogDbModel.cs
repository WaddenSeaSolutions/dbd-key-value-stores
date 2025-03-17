using MongoDB.Bson;

namespace MongoExample.Infrastructure.Models;

public class BlogDbModel
{
    public ObjectId Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}