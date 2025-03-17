namespace MongoExample.Domain.ValueObjects;

using MongoDB.Bson;

public readonly record struct CommentId(ObjectId Value);