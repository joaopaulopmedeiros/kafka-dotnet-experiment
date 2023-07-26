namespace Ecommerce.Api.Services;

public class ProdutoRecomendadoService
{
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;
    private readonly IProducer _producer;

    public ProdutoRecomendadoService(IMapper mapper, IConfiguration configuration, IProducer producer)
    {
        _mapper = mapper;
        _configuration = configuration;
        _producer = producer;
    }

    public async Task<AcceptedResponse> ProcessClickAsync(ProdutoRecomendadoClickRequest payload)
    {
        ProdutoRecomendadoClickEvent @event = _mapper.Map<ProdutoRecomendadoClickEvent>(payload);

        string topicName = _configuration.GetValue<string>("Kafka:Topics:ProdutoRecomendadoClick");
        
        await _producer.ProduceAsync(@event, topicName);
        
        return new AcceptedResponse(@event.Key, "evento de click de produto recomendado em processamento");
    }
}
