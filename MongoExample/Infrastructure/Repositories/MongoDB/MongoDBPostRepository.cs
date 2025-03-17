using MongoDB.Driver;
using MongoExample.Core.Models;
using MongoExample.Domain.Interfaces;
using MongoExample.Domain.ValueObjects;
using MongoExample.Infrastructure.Contexts;
using MongoExample.Infrastructure.Mappers;

namespace MongoExample.Infrastructure.Repositories.MongoDB;

public class MongoDBPostRepository : IPostRepository
{
    private readonly MongoDbContext _dbContext;
    
    public MongoDBPostRepository(MongoDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<Post>> GetAllAsync()
    {
        var posts = await _dbContext.Posts.Find(_ => true).ToListAsync();
        return posts.Select(x => x.ToDomain());
    }
    
    public async Task<Post?> GetByIdAsync(PostId id)
    {
        var post = await _dbContext.Posts.Find(x => x.Id == id.Value).FirstOrDefaultAsync();
        return post?.ToDomain();
    }
    
    public async Task<Post> CreateAsync(Post post)
    {
        var postEntity = post.ToDbModel();
        await _dbContext.Posts.InsertOneAsync(postEntity);
        return postEntity.ToDomain();
    }
    
    public async Task<Post> UpdateAsync(Post post)
    {
        var postEntity = post.ToDbModel();
        await _dbContext.Posts.ReplaceOneAsync(x => x.Id == postEntity.Id, postEntity);
        return postEntity.ToDomain();
    }
    
    public async Task DeleteAsync(PostId id)
    {
        await _dbContext.Posts.DeleteOneAsync(x => x.Id == id.Value);
    }
}