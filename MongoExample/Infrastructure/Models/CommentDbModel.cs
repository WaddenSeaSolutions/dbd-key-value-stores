using MongoDB.Bson;

namespace MongoExample.Infrastructure.Models;

public class CommentDbModel
{
    public ObjectId Id { get; set; }
    public string Content { get; set; }
    public string UserId { get; set; }
    public string UserName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}