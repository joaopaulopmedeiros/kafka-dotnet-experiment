namespace Ecommerce.Consumer.Handlers;

public class CompraHandler : IIntegrationEventHandler<CompraEvent>
{
    private readonly ILogger<CompraHandler> _logger;

    public CompraHandler(ILogger<CompraHandler> logger)
    {
        _logger = logger;
    }

    public async Task HandleAsync(CompraEvent @event)
    {
        await Task.Delay(100);
        _logger.LogInformation("{Message}", "Compra processada com sucesso");
    }
}
