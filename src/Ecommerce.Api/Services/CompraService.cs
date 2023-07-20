namespace Ecommerce.Api.Services;

public class CompraService
{
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;
    private readonly IEventBusPublisher _EventBusPublisher;

    public CompraService(IMapper mapper, IConfiguration configuration, IEventBusPublisher EventBusPublisher)
    {
        _mapper = mapper;
        _configuration = configuration;
        _EventBusPublisher= EventBusPublisher;
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

        string topicName = _configuration.GetValue<string>("Kafka:Topics:Compras");

        await _EventBusPublisher.PublishAsync(@event, topicName);

        return new CompraResponse(@event.Key);
    }
}
