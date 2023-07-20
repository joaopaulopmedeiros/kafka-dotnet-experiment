namespace Ecommerce.Core.Kafka;

public class KafkaConsumerConfiguration
{
    public string BootstrapServers { get; set; }
    public string GroupId { get; set; }
    public string Topic { get; set; }
}
