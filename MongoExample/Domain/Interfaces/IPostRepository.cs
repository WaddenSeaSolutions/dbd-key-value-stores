using MongoExample.Core.Models;
using MongoExample.Domain.ValueObjects;

namespace MongoExample.Domain.Interfaces;

public interface IPostRepository
{
    Task<IEnumerable<Post>> GetAllAsync();
    Task<Post?> GetByIdAsync(PostId id);
    Task<Post> CreateAsync(Post post);
    Task<Post> UpdateAsync(Post post);
    Task DeleteAsync(PostId id);
}