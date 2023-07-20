namespace Ecommerce.Api.Mappings;

public class CompraProfile : Profile
{
    public CompraProfile()
    {
        CreateMap<CompraRequest, CompraEvent>();
    }
}
