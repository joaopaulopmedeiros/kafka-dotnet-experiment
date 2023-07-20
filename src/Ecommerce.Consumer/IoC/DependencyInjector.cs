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

        services.AddSingleton<CompraHandler>();

        var kafkaConfiguration = new KafkaConsumerConfiguration
        {
            BootstrapServers = configuration.GetValue<string>("Kafka:BootstrapServers"),
            GroupId = configuration.GetValue<string>("Kafka:GroupId"),
            Topic = configuration.GetValue<string>("Kafka:Topics:Compra")
        };

        services.AddHostedService(x => new KafkaConsumer(kafkaConfiguration));

        return services;
    }
}
