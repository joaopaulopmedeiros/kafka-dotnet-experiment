namespace Ecommerce.Consumer.Handlers;

public class ProdutoRecomendadoClickHandler : IIntegrationEventHandler<ProdutoRecomendadoClickEvent>
{
    private readonly ILogger<ProdutoRecomendadoClickHandler> _logger;

    public ProdutoRecomendadoClickHandler(ILogger<ProdutoRecomendadoClickHandler> logger)
    {
        _logger = logger;
    }

    public async Task HandleAsync(ProdutoRecomendadoClickEvent @event)
    {
        await Task.Delay(50);
        _logger.LogInformation("{Message}", "Click em produto recomendado processado com sucesso");
    }
}
