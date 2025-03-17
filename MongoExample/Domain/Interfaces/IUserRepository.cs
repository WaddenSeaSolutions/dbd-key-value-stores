using MongoExample.Core.Models;
using MongoExample.Domain.ValueObjects;

namespace MongoExample.Domain.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllAsync();
    Task<User?> GetByIdAsync(UserId id);
    Task<User> CreateAsync(User user);
    Task<User> UpdateAsync(User user);
    Task<bool> DeleteAsync(UserId id);
}