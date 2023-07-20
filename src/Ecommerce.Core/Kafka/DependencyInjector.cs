namespace Ecommerce.Core.Kafka;

public static class DependencyInjector
{
    public static IServiceCollection AddKafkaEventBusPublisher(this IServiceCollection services, string bootstrapServers)
    {
        services.AddSingleton<IProducer, KafkaProducer>(x => new KafkaProducer(bootstrapServers));
        return services;
    }
}
