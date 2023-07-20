namespace Ecommerce.Api.IoC;

public static class DependencyInjector
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<CompraService>();
        services.AddAutoMapper(typeof(CompraProfile));
        services.AddSingleton<IEventBusPublisher, KafkaEventBusPublisher>(x => new KafkaEventBusPublisher(configuration.GetValue<string>("Kafka:BootstrapServers")));
        return services;
    }
}
