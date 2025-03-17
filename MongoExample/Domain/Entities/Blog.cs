using MongoExample.Domain.ValueObjects;

namespace MongoExample.Core.Models;

public class Blog
{
    public BlogId Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}