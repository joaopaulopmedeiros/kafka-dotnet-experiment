namespace Ecommerce.Core.Kafka;

public static class DependencyInjector
{
    public static IServiceCollection AddEventStreamProducer(this IServiceCollection services, string bootstrapServers)
    {
        services.AddSingleton<IProducer, KafkaProducer>(x => new KafkaProducer(bootstrapServers));
        return services;
    }

    public static IServiceCollection AddEventStreamHandler<CompraEvent, CompraHandler>(this IServiceCollection services, KafkaConsumerConfiguration configuration)
        where CompraEvent : IntegrationEvent
        where CompraHandler : class, IIntegrationEventHandler<CompraEvent>
    {
        services.AddSingleton(configuration);
        services.AddSingleton<IIntegrationEventHandler<CompraEvent>, CompraHandler>();
        services.AddHostedService<KafkaConsumer<CompraEvent, IIntegrationEventHandler<CompraEvent>>>();
        return services;
    }
}