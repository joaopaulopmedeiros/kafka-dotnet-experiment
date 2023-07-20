namespace Ecommerce.Core.Kafka;

public interface IProducer
{
    Task ProduceAsync(IntegrationEvent @event, string topicName);
}
