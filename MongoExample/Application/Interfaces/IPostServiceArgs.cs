using MongoExample.Domain.Interfaces;

namespace MongoExample.Application.Interfaces;

public interface IPostServiceArgs
{
    IPostRepository PostPersistenceRepository { get; set; }
    IPostRepository PostCacheRepository { get; set; }
}