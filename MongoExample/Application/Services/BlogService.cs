using MongoExample.Domain.Interfaces;

namespace MongoExample.Application.Services;

public class BlogService
{
    private readonly IBlogRepository _blogRepository;
    
    public BlogService(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }
}