using Microsoft.EntityFrameworkCore;
using MongoExample.Core.Models;
using MongoExample.Domain.Interfaces;
using MongoExample.Domain.ValueObjects;
using MongoExample.Infrastructure.Contexts;
using MongoExample.Infrastructure.Mappers;

namespace MongoExample.Infrastructure.Repositories.EFCore;

public class EFCorePostRepository : IPostRepository
{
    private readonly EFDbContext _dbContext;
    
    public EFCorePostRepository(EFDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<Post>> GetAllAsync()
    {
        var posts = await _dbContext.Posts.ToListAsync();
        return posts.Select(x => x.ToDomain());
    }

    public async Task<Post?> GetByIdAsync(PostId id)
    {
        var post = await _dbContext.Posts.FirstOrDefaultAsync(x => x.Id == id.Value);
        return post.ToDomain();
    }
    
    public async Task<Post> CreateAsync(Post post)
    {
        var postEntity = post.ToDbModel();
        await _dbContext.Posts.AddAsync(postEntity);
        await _dbContext.SaveChangesAsync();
        return postEntity.ToDomain();
    }
    
    public async Task<Post> UpdateAsync(Post post)
    {
        var postEntity = post.ToDbModel();
        _dbContext.Posts.Update(postEntity);
        await _dbContext.SaveChangesAsync();
        return postEntity.ToDomain();
    }
    
    public async Task DeleteAsync(PostId id)
    {
        var post = await _dbContext.Posts.FirstOrDefaultAsync(x => x.Id == id.Value);
        _dbContext.Posts.Remove(post);
        await _dbContext.SaveChangesAsync();
    }
}