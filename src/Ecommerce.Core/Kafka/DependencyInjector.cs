namespace Ecommerce.Core.Kafka;

public static class DependencyInjector
{
    public static IServiceCollection AddEventStreamProducer(this IServiceCollection services, string bootstrapServers)
    {
        services.AddSingleton<IProducer, KafkaProducer>(x => new KafkaProducer(bootstrapServers));
        return services;
    }
}
