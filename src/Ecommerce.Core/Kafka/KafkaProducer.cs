namespace Ecommerce.Core.Kafka;

public class KafkaProducer : IProducer
{
    private readonly IProducer<string, IntegrationEvent> _producer;

    public KafkaProducer(string bootstrapServers)
    {
        ProducerConfig configuration = new()
        {
            BootstrapServers = bootstrapServers,
            CompressionType = CompressionType.Lz4,
        };

        _producer = new ProducerBuilder<string, IntegrationEvent>(configuration)
            .SetValueSerializer(StandardJsonSerializer.Use())
            .Build();
    }

    public async Task ProduceAsync(IntegrationEvent @event, string topicName)
    {
        Headers header = new()
        {
            { "contrato", Encoding.UTF8.GetBytes(@event.GetType().AssemblyQualifiedName.ToString()) }
        };

        Message<string, IntegrationEvent> message = new()
        {
            Key = @event.Key,
            Value = @event,
            Headers = header
        };

        DeliveryResult<string, IntegrationEvent> producerResult = await _producer.ProduceAsync(topicName, message);

        if (producerResult.Status == PersistenceStatus.NotPersisted)
        {
            throw new InvalidOperationException("Failed to produce messages!");
        }

        _producer.Flush(TimeSpan.FromSeconds(10));
    }
}
