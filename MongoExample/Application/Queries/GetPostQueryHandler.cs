using Microsoft.AspNetCore.Mvc;
using MongoExample.Application.Services;
using MongoExample.Core.Models;

namespace MongoExample.Application.Queries
{
    public class GetPostQueryHandler
    {
        private readonly PostService _postService;

        public GetPostQueryHandler(PostService postService)
        {
            _postService = postService;
        }

        public async Task<Post?> HandleAsync(GetPostQuery query)
        {
            return await _postService.GetPostByIdAsync(query.PostId);
        }

        public async Task<Post?> HandleAsync(string postId)
        {
            return await _postService.GetPostByIdAsync(postId);
        }
    }
}
