namespace Ecommerce.Core.Kafka;

public static class DependencyInjector
{
    public static IServiceCollection AddEventStreamProducer(this IServiceCollection services, string bootstrapServers)
    {
        services.AddSingleton<IProducer, KafkaProducer>(x => new KafkaProducer(bootstrapServers));
        return services;
    }

    public static IServiceCollection AddEventStreamHandler<TContract, THandler>(this IServiceCollection services, KafkaConsumerConfiguration<TContract> configuration)
        where TContract : IntegrationEvent
        where THandler : class, IIntegrationEventHandler<TContract>
    {
        services.AddSingleton(configuration);
        services.AddSingleton<IIntegrationEventHandler<TContract>, THandler>();
        services.AddHostedService<KafkaConsumer<TContract, IIntegrationEventHandler<TContract>>>();
        return services;
    }
}