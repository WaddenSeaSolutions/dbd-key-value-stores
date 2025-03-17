using MongoExample.Core.Models;
using MongoExample.Domain.ValueObjects;
using MongoExample.Infrastructure.Models;

namespace MongoExample.Infrastructure.Mappers;

public static class CommentMapper
{
    public static Comment ToDomain(this CommentDbModel comment)
    {
        return new Comment
        {
            Id = new CommentId(comment.Id),
            Content = comment.Content,
            CreatedAt = comment.CreatedAt,
            UpdatedAt = comment.UpdatedAt
        };
    }
    public static CommentDbModel ToDbModel(this Comment comment)
    {
        return new CommentDbModel
        {
            Id = comment.Id.Value,
            Content = comment.Content,
            CreatedAt = comment.CreatedAt,
            UpdatedAt = comment.UpdatedAt
        };
    }
}