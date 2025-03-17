using MongoDB.Driver;
using MongoExample.Infrastructure.Models;

namespace MongoExample.Infrastructure.Contexts;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;
    public readonly IMongoCollection<PostDbModel> Posts;
    public readonly IMongoCollection<BlogDbModel> Blogs;
    public readonly IMongoCollection<CommentDbModel> Comments;
    public readonly IMongoCollection<UserDbModel> Users;

    public MongoDbContext(string connectionString, string databaseName)
    {
        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(databaseName);
        Posts = _database.GetCollection<PostDbModel>("Posts");
        Blogs = _database.GetCollection<BlogDbModel>("Blogs");
        Comments = _database.GetCollection<CommentDbModel>("Comments");
        Users = _database.GetCollection<UserDbModel>("Users");
    }
    
}