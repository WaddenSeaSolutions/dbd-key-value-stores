using MongoExample.Application.Services;

public class UpdatePostCommand
{
    public Guid PostId { get; }
    public string Title { get; }
    public string Content { get; }

    public UpdatePostCommand(Guid postId, string title, string content)
    {
        PostId = postId;
        Title = title;
        Content = content;
    }
}

public class UpdatePostCommandHandler
{
    private readonly PostService _postService;

    public UpdatePostCommandHandler(PostService postService)
    {
        _postService = postService;
    }

    public async Task HandleAsync(UpdatePostCommand command)
    {
        await _postService.UpdatePostAsync(command.PostId, command.Title, command.Content);
    }
}