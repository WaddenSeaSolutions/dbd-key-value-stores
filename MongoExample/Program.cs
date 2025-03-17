using MongoExample.Application.Services;
using MongoExample.Infrastructure.Repositories.MongoDB;
using MongoExample.Infrastructure.Repositories.Redis;

var builder = WebApplication.CreateBuilder(args);

// Register repositories
builder.Services.AddScoped<MongoDBPostRepository>();
builder.Services.AddScoped<RedisPostRepository>();

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