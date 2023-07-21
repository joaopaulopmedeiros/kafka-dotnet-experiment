namespace Ecommerce.Api.IoC;

public static class DependencyInjector
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<CompraService>();
        services.AddScoped<ProdutoRecomendadoService>();
        services.AddAutoMapper(typeof(CompraProfile), typeof(ProdutoRecomendadoProfile));
        services.AddEventStreamProducer(configuration.GetValue<string>("Kafka:BootstrapServers"));
        return services;
    }
}
