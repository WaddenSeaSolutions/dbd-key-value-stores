using MongoExample.Core.Models;
using MongoExample.Domain.ValueObjects;
using MongoExample.Infrastructure.Models;

namespace MongoExample.Infrastructure.Mappers;

public static class PostMapper
{
    public static Post ToDomain(this PostDbModel dbModel)
    {
        return new Post
        {
            Id = new PostId(dbModel.Id),
            Title = dbModel.Title,
            Content = dbModel.Content,
            CreatedAt = dbModel.CreatedAt,
            UpdatedAt = dbModel.UpdatedAt
        };
    }
    
    public static PostDbModel ToDbModel(this Post domain)
    {
        return new PostDbModel
        {
            Id = domain.Id.Value,
            Title = domain.Title,
            Content = domain.Content,
            CreatedAt = domain.CreatedAt,
            UpdatedAt = domain.UpdatedAt
        };
    }
}