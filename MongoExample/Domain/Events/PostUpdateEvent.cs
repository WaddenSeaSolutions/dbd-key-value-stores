namespace MongoExample.Domain.Events;

public class PostUpdatedEvent
{
    public Guid PostId { get; }
    public string Title { get; }
    public string Content { get; }

    public PostUpdatedEvent(Guid postId, string title, string content)
    {
        PostId = postId;
        Title = title;
        Content = content;
    }
}
