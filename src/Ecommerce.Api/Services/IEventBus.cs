namespace Ecommerce.Api.Services;

public interface IEventBus
{
    Task PublishAsync<T>(T @event) where T : class;
}

public class KafkaEventBus : IEventBus
{
    public async Task PublishAsync<T>(T @event) where T : class
    {
        await Task.Delay(100);
    }
}
