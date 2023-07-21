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

        string? bootstrapServers = configuration.GetValue<string>("Kafka:BootstrapServers");
        string? groupId = configuration.GetValue<string>("Kafka:GroupId");
        string? topicoCompra = configuration.GetValue<string>("Kafka:Topics:Compra");
        string? topicoProdutoRecomendadoClick = configuration.GetValue<string>("Kafka:Topics:ProdutoRecomendadoClick");

        services.AddEventStreamHandler<CompraEvent, CompraHandler>(new KafkaConsumerConfiguration<CompraEvent>(bootstrapServers, groupId, topicoCompra));
        services.AddEventStreamHandler<ProdutoRecomendadoClickEvent, ProdutoRecomendadoClickHandler>(new KafkaConsumerConfiguration<ProdutoRecomendadoClickEvent>(bootstrapServers, groupId, topicoProdutoRecomendadoClick));

        return services;
    }
}
