using MongoExample.Application.Interfaces;
using MongoExample.Application.Services;
using MongoExample.Infrastructure.Contexts;
using MongoExample.Infrastructure.Repositories.MongoDB;
using MongoExample.Infrastructure.Repositories.Redis;

var builder = WebApplication.CreateBuilder(args);

// Register repositories
builder.Services.AddScoped<IPostServiceArgs>(services =>
{
    var mongoDbContext = new MongoDbContext("mongodb://localhost:27017", "mongo-example");
    var redisDbContext = new RedisDbContext("localhost:6379");
    var mongoDbPostRepository = new MongoDBPostRepository(mongoDbContext);
    var redisPostRepository = new RedisPostRepository(redisDbContext, TimeSpan.FromHours(1));

    return new PostServiceArgs
    {
        PostPersistenceRepository = mongoDbPostRepository,
        PostCacheRepository = redisPostRepository
    };
});

// Register services
builder.Services.AddScoped<PostService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();