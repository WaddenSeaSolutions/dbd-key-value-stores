using MongoExample.Core.Models;
using MongoExample.Domain.ValueObjects;

namespace MongoExample.Domain.Interfaces;

public interface IBlogRepository
{
    Task<IEnumerable<Blog>> GetAllAsync();
    Task<Blog> GetByIdAsync(BlogId id);
    Task<Blog> CreateAsync(Blog blog);
    Task<Blog> UpdateAsync(Blog blog);
    Task<bool> DeleteAsync(BlogId id);
}