namespace Ecommerce.Core.Kafka;

public class StandardJsonSerializer<TContract> : ISerializer<TContract?>, IDeserializer<TContract?>
    where TContract : IntegrationEvent
{
    private readonly JsonSerializerOptions DefaultOptions;

    public StandardJsonSerializer()
    {
        DefaultOptions = new JsonSerializerOptions();
    }

    public static StandardJsonSerializer<TContract> Use() => new();

    public byte[] Serialize(TContract? data, SerializationContext context) => JsonSerializer.SerializeToUtf8Bytes(data, GetMessageType(context), DefaultOptions);

    public TContract? Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
        => (TContract?)JsonSerializer.Deserialize(data, GetMessageType(context), DefaultOptions);

    private static Type GetMessageType(SerializationContext context) => Type.GetType(Encoding.UTF8.GetString(context.Headers[0].GetValueBytes()))!;
}
