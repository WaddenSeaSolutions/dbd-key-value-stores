using MongoExample.Core.Models;

public class ReadPostQuery
{
    public Guid PostId { get; }

    public ReadPostQuery(Guid postId)
    {
        PostId = postId;
    }
}

public class ReadPostQueryHandler
{
    private readonly IMongoRepository<Post> _postRepository;

    public ReadPostQueryHandler(IMongoRepository<Post> postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<Post> HandleAsync(ReadPostQuery query)
    {
        return await _postRepository.GetByIdAsync(query.PostId);
    }
}