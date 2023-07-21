namespace Ecommerce.Core.Kafka;

public class KafkaConsumerConfiguration<TContract>
{
    public KafkaConsumerConfiguration(string bootstrapServers, string groupId, string topicName)
    {
        BootstrapServers = bootstrapServers;
        GroupId = groupId;
        TopicName = topicName;
    }

    public string BootstrapServers { get; set; }
    public string GroupId { get; set; }
    public string TopicName { get; set; }
}
