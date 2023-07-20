namespace Ecommerce.Api.Services;

public class CompraService
{
    private readonly IMapper _mapper;
    private readonly IEventBus _eventBus;

    public CompraService(IMapper mapper, IEventBus eventBus)
    {
        _mapper = mapper;
        _eventBus= eventBus;
    }

    /// <summary>
    /// Mapeia requisição em evento de compra e envia para tópico kafka
    /// onde será processado em background de forma assíncrona.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public async Task<CompraResponse> ProcessAsync(CompraRequest request)
    {
        CompraEvent @event = _mapper.Map<CompraEvent>(request);
        await _eventBus.PublishAsync(@event);
        return new CompraResponse(@event.Key);
    }
}
