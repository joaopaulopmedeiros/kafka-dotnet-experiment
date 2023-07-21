namespace Ecommerce.Consumer.IoC;

public static class DependencyInjector
{
    public static IServiceCollection AddConsumerServices(this IServiceCollection services)
    {
        var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        var builder = new ConfigurationBuilder()
            .AddJsonFile($"appsettings.json", true, true)
            .AddJsonFile($"appsettings.{environmentName}.json", true, true)
            .AddEnvironmentVariables();

        var configuration = builder.Build();

        var kafkaConfiguration = new KafkaConsumerConfiguration
        {
            BootstrapServers = configuration.GetValue<string>("Kafka:BootstrapServers"),
            GroupId = configuration.GetValue<string>("Kafka:GroupId"),
            Topic = configuration.GetValue<string>("Kafka:Topics:Compras")
        };

        services.AddEventStreamHandler<CompraEvent, CompraHandler>(kafkaConfiguration);

        return services;
    }
}
