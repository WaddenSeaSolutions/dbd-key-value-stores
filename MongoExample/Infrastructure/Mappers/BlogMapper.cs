using MongoExample.Core.Models;
using MongoExample.Domain.ValueObjects;
using MongoExample.Infrastructure.Models;

namespace MongoExample.Infrastructure.Mappers;

public static class BlogMapper
{
    public static Blog ToDomain(this BlogDbModel blog)
    {
        return new Blog
        {
            Id = new BlogId(blog.Id),
            Description = blog.Description,
            Title = blog.Title,
        };
    }
    public static BlogDbModel ToDbModel(this Blog blog)
    {
        return new BlogDbModel
        {
            Id = blog.Id.Value,
            Description = blog.Description,
            Title = blog.Title,
        };
    }
}