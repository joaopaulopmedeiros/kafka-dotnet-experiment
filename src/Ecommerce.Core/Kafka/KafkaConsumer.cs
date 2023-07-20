namespace Ecommerce.Core.Kafka;

public class KafkaConsumer : BackgroundService
{
    private readonly KafkaConsumerConfiguration _configuration;

    public KafkaConsumer(KafkaConsumerConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Console.WriteLine("a");
        await Task.Delay(1000);
    }
}
