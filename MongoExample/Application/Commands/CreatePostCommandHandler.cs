using MongoExample.Application.Services;

public class CreatePostCommandHandler
{
    private readonly PostService _postService;
    private readonly IDomainEventBus _domainEventBus;

    public CreatePostCommandHandler(PostService postService, IDomainEventBus domainEventBus)
    {
        _postService = postService;
        _domainEventBus = domainEventBus;
    }

    public async Task HandleAsync(CreatePostCommand command)
    {
        await _postService.CreatePostAsync(command.BlogId, command.UserId, command.Title, command.Content);
        await _domainEventBus.PublishAsync(new PostCreatedEvent(
            command.BlogId, command.UserId, "username", command.Title, command.Content
        ));
    }
}