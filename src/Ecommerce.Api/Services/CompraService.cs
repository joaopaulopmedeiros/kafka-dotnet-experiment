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
    /// <param name="payload"></param>
    /// <param name="utm"></param>
    /// <returns></returns>
    public async Task<CompraResponse> ProcessAsync(CompraRequest payload, string utm)
    {
        CompraEvent @event = _mapper.Map<CompraEvent>(payload);

        @event.UseUtm(UtmHelper.Mount(utm));

        await _eventBus.PublishAsync(@event);

        return new CompraResponse(@event.Key);
    }
}
