namespace Ecommerce.Api.Mappings;

public class ProdutoRecomendadoProfile : Profile
{
    public ProdutoRecomendadoProfile()
    {
        CreateMap<ProdutoRecomendadoClickRequest, ProdutoRecomendadoClickEvent>();
    }
}
