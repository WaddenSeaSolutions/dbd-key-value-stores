using MongoExample.Core.Models;
using MongoExample.Infrastructure.Contexts;

public class ReadPostQuery
{

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