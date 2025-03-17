using MongoExample.Core.Models;
using MongoExample.Domain.Interfaces;
using MongoExample.Domain.ValueObjects;

namespace MongoExample.Application.Services;

public class PostService
{
    private readonly IPostRepository _postRepository;
    private readonly IPostRepository _redisPostRepository;
    
    public PostService(IPostRepository postRepository, IPostRepository redisPostRepository)
    {
        _postRepository = postRepository;
        _redisPostRepository = redisPostRepository;
    }

    public async Task<Post?> GetPostByIdAsync(string id)
    {
        PostId postId = new PostId(id);
        return await GetPostByIdAsync(postId);
    }
    public async Task<Post?> GetPostByIdAsync(PostId id)
    {
        Post? cachedPost = await _redisPostRepository.GetByIdAsync(id);
        if(cachedPost is not null)
            return cachedPost;
        
        Post? post = await _postRepository.GetByIdAsync(id);
        if(post is not null)
            await _redisPostRepository.CreateAsync(post);
        return post;
    }
}