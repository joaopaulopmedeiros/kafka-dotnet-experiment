namespace Ecommerce.Api.Services;

public class CompraService
{
    private readonly IMapper _mapper;

    public CompraService(IMapper mapper)
    {
        _mapper = mapper;
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
        await Task.Delay(100);
        return new CompraResponse(@event.Key);
    }
}
