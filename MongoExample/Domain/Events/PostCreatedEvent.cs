namespace MongoExample.Domain.Events;

public class PostCreatedEvent
{
    public Guid BlogId { get; }
    public Guid UserId { get; }
    public string Username { get; }
    public string Title { get; }
    public string Content { get; }

    public PostCreatedEvent(Guid blogId, Guid userId, string username, string title, string content)
    {
        BlogId = blogId;
        UserId = userId;
        Username = username;
        Title = title;
        Content = content;
    }
}
