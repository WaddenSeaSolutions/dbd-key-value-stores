using MongoExample.Domain.Interfaces;

namespace MongoExample.Application.Services;

public class CommentService
{
    private readonly ICommentRepository _commentRepository;
    
    public CommentService(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }
}