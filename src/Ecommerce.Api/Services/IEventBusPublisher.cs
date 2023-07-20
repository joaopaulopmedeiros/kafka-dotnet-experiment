namespace Ecommerce.Api.Services;

public interface IEventBusPublisher
{
    Task PublishAsync(IntegrationEvent @event, string topicName);
}

public class KafkaEventBusPublisher : IEventBusPublisher
{
    private readonly IProducer<string, IntegrationEvent> _producer;

    public KafkaEventBusPublisher(string bootstrapServers)
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

    public async Task PublishAsync(IntegrationEvent @event, string topicName)
    {
        var header = new Headers
        {
            { "contrato", Encoding.UTF8.GetBytes(@event.GetType().AssemblyQualifiedName.ToString()) }
        };

        var message = new Message<string, IntegrationEvent>
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

public class StandardJsonSerializer : ISerializer<IntegrationEvent?>, IDeserializer<IntegrationEvent?>
{
    private readonly JsonSerializerOptions DefaultOptions;

    public StandardJsonSerializer()
    {
        DefaultOptions = new JsonSerializerOptions();
    }

    public static StandardJsonSerializer Use() => new();

    public byte[] Serialize(IntegrationEvent? data, SerializationContext context) => JsonSerializer.SerializeToUtf8Bytes(data, GetMessageType(context), DefaultOptions);

    public IntegrationEvent? Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
        => (IntegrationEvent?)JsonSerializer.Deserialize(data, GetMessageType(context), DefaultOptions);

    private static Type GetMessageType(SerializationContext context) => Type.GetType(Encoding.UTF8.GetString(context.Headers[0].GetValueBytes()))!;
}