using MongoExample.Core.Models;
using MongoExample.Domain.ValueObjects;
using MongoExample.Infrastructure.Models;

namespace MongoExample.Infrastructure.Mappers;

public static class UserMapper
{
    public static User ToDomain(this UserDbModel user)
    {
        return new User
        {
            Id = new UserId(user.Id),
            Name = user.Name,
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.UpdatedAt
        };
    }
    public static UserDbModel ToDbModel(this User user)
    {
        return new UserDbModel
        {
            Id = user.Id.Value,
            Name = user.Name,
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.UpdatedAt
        };
    }
}