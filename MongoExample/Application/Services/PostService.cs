using MongoDB.Bson;
using MongoExample.Application.Interfaces;
using MongoExample.Core.Models;
using MongoExample.Domain.Interfaces;
using MongoExample.Domain.ValueObjects;

namespace MongoExample.Application.Services;

public class PostServiceArgs : IPostServiceArgs
{
    public IPostRepository PostPersistenceRepository { get; set; }
    public IPostRepository PostCacheRepository { get; set; }
}

public class PostService
{
    private readonly IPostRepository _postPersistenceRepository;
    private readonly IPostRepository _postCacheRepository;
    
    public PostService(IPostServiceArgs args)
    {
        _postPersistenceRepository = args.PostPersistenceRepository;
        _postCacheRepository = args.PostCacheRepository;
    }       

    public async Task<Post?> GetPostByIdAsync(string id)
    {
        PostId postId = new PostId(id);
        return await GetPostByIdAsync(postId);
    }
    public async Task<Post?> GetPostByIdAsync(PostId id)
    {
        Post? cachedPost = await _postCacheRepository.GetByIdAsync(id);
        if(cachedPost is not null)
            return cachedPost;
        
        Post? post = await _postPersistenceRepository.GetByIdAsync(id);
        if(post is not null)
            await _postCacheRepository.CreateAsync(post);
        return post;
    }

    public async Task CreatePostAsync(BlogId blogId, string userId, string title, string content)
    {
        var newPost = new Post
        {
            Id = new PostId(ObjectId.GenerateNewId().ToString()),
            BlogId = blogId,
            UserId = userId,
            Title = title,
            Content = content,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        await _postPersistenceRepository.CreateAsync(newPost);
        await _postCacheRepository.CreateAsync(newPost);
    }
}