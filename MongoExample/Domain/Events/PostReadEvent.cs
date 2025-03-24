namespace MongoExample.Domain.Events;

public class PostReadEvent
{
    public Guid PostId { get; }
    public string Title { get; }
    public string Content { get; }
    public Guid UserId { get; }

    public PostReadEvent(Guid postId, string title, string content, Guid userId)
    {
        PostId = postId;
        Title = title;
        Content = content;
        UserId = userId;
    }
}
