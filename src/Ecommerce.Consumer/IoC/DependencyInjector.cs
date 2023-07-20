namespace Ecommerce.Consumer.IoC;

public static class DependencyInjector
{
   public static IServiceCollection AddConsumerServices(this IServiceCollection services)
    {
        services.AddKafkaEventBusConsumer<CompraHandler>(new KafkaConsumerConfiguration { });
        return services;
    }
}
