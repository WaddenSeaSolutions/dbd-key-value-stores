namespace MongoExample.Application.Queries
{
    public class GetPostQuery
    {
        public string PostId { get; }

        public GetPostQuery(string postId)
        {
            PostId = postId;
        }
    }

}
