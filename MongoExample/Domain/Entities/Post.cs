using MongoExample.Domain.ValueObjects;

namespace MongoExample.Core.Models;

public class Post
{
    public PostId Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string UserId { get; set; }
    public string UserName { get; set; }
    public BlogId BlogId { get; set; }
    public List<Comment> Comments { get; set; } = new();
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}