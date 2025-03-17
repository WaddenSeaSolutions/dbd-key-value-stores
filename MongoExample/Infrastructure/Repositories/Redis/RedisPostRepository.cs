using System.Text.Json;
using MongoExample.Core.Models;
using MongoExample.Domain.Interfaces;
using MongoExample.Domain.ValueObjects;
using MongoExample.Infrastructure.Contexts;
using StackExchange.Redis;

namespace MongoExample.Infrastructure.Repositories.Redis;

public class RedisPostRepository : IPostRepository
{
    private readonly RedisDbContext _dbContext;
    private readonly TimeSpan _expiry;
    
    public RedisPostRepository(RedisDbContext dbContext, TimeSpan expiry)
    {
        _dbContext = dbContext;
        _expiry = expiry;
    }   
    
    public Task<IEnumerable<Post>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
    
    public async Task<Post?> GetByIdAsync(PostId id)
    {
        var post = await _dbContext.GetDatabase().StringGetAsync(id.ToString());
        return post.HasValue ? JsonSerializer.Deserialize<Post>(post) : null;
    }
    
    public async Task<Post> CreateAsync(Post post)
    {
        var serializedValue = JsonSerializer.Serialize(post);
        await _dbContext.GetDatabase().StringSetAsync(new RedisKey(post.Id.ToString()), serializedValue, _expiry);
        return post;
    }
    
    public Task<Post> UpdateAsync(Post post)
    {
        throw new NotImplementedException();
    }
    
    public async Task DeleteAsync(PostId id)
    {
        await _dbContext.GetDatabase().KeyDeleteAsync(id.ToString());
    }
}