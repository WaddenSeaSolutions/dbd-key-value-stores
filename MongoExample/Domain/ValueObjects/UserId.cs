using MongoDB.Bson;

namespace MongoExample.Domain.ValueObjects;

public readonly record struct UserId(ObjectId Value);