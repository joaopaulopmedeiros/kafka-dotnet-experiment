namespace Ecommerce.Core.Kafka;

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
