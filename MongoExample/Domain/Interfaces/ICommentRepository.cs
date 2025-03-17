using MongoExample.Core.Models;
using MongoExample.Domain.ValueObjects;

namespace MongoExample.Domain.Interfaces;

public interface ICommentRepository
{
    Task<IEnumerable<Comment>> GetAllAsync();
    Task<Comment?> GetByIdAsync(CommentId id);
    Task CreateAsync(Comment comment);
    Task UpdateAsync(Comment comment);
    Task DeleteAsync(CommentId id);
}