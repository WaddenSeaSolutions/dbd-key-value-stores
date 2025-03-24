using MongoExample.Application.Services;

public class UpdatePostCommand
{


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