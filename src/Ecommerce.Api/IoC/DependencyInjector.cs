namespace Ecommerce.Api.IoC;

public static class DependencyInjector
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddScoped<CompraService>();
        services.AddAutoMapper(typeof(CompraProfile));
        return services;
    }
}
