using MongoExample.Application.Services;
using MongoExample.Domain.Interfaces;
using MongoExample.Infrastructure.Contexts;
using MongoExample.Infrastructure.Repositories.MongoDB;
using MongoExample.Infrastructure.Repositories.Redis;

var builder = WebApplication.CreateBuilder(args);

// Register repositories
builder.Services.AddScoped<IPostRepository, MongoDBPostRepository>(services =>
{
    var dbContext = new MongoDbContext("mongodb://localhost:27017", "mongo-example");
    return new MongoDBPostRepository(dbContext);
});
builder.Services.AddScoped<IPostRepository, RedisPostRepository>(
    services
        =>
    {
        var dbContext = new RedisDbContext("localhost:6379");
        return new RedisPostRepository(dbContext, TimeSpan.FromHours(1));
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