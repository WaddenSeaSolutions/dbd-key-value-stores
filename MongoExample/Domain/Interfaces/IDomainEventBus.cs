public interface IDomainEventBus
{
    Task PublishAsync<T>(T domainEvent) where T : class;
}

public class DomainEventBus : IDomainEventBus
{
    private readonly List<Func<object, Task>> _subscribers = new();
    
    public async Task PublishAsync<T>(T domainEvent) where T : class
    {
        foreach (var subscriber in _subscribers)
        {
            await subscriber(domainEvent);
        }
    }

    public void Subscribe<T>(Func<T, Task> handler) where T : class
    {
        _subscribers.Add(async (e) => await handler((T)e));
    }
}