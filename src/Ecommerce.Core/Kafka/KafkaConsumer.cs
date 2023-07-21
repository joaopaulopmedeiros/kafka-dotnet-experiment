namespace Ecommerce.Core.Kafka;

public class KafkaConsumer<TContract, THandler> : BackgroundService 
    where TContract : IntegrationEvent 
    where THandler : IIntegrationEventHandler<TContract>
{
    private readonly ILogger<KafkaConsumer<TContract, THandler>> _logger;
    private readonly IConsumer<Ignore, TContract> _consumer;
    private readonly THandler _handler;

    public KafkaConsumer
    (
        KafkaConsumerConfiguration configuration, 
        THandler handler,
        ILogger<KafkaConsumer<TContract, THandler>> logger
    )
    {
        _handler = handler;

        _logger = logger;

        ConsumerConfig kafkaConfig = new()
        {
            BootstrapServers = configuration.BootstrapServers,
            GroupId = configuration.GroupId,
            EnableAutoOffsetStore = true,
            EnableAutoCommit = true,
            StatisticsIntervalMs = 60000,
            SessionTimeoutMs = 60000,
            AutoOffsetReset = AutoOffsetReset.Earliest,
            EnablePartitionEof = false,
        };

        _consumer = new ConsumerBuilder<Ignore, TContract>(kafkaConfig)
            .SetValueDeserializer(StandardJsonSerializer<TContract>.Use())
            .SetErrorHandler((_, e) => _logger.LogError("{Message}", e.Reason))
            .SetStatisticsHandler((_, json) => _logger.LogInformation("{Message}", $"Statistics: {json}"))
            .Build();

        _consumer.Subscribe(configuration.Topic);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    try
                    {
                        var consumeResult = _consumer.Consume(stoppingToken);

                        if (consumeResult.IsPartitionEOF) continue;

                        if (consumeResult.Message.Value is null) continue;

                        try
                        {
                            await _handler.HandleAsync(consumeResult.Message.Value);
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError("{Message}", ex.Message);
                        }
                    }
                    catch (ConsumeException e)
                    {
                        _logger.LogError("{Message}", $"Consume error: {e.Error.Reason}");
                    }
                }
            }
        }
        catch (OperationCanceledException)
        {
            _logger.LogWarning("{Message}", "Closing consumer.");
            _consumer.Close();
        }
    }
}
