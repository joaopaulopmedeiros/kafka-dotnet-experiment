namespace Ecommerce.Core.Events;

public class ProdutoRecomendadoClickEvent : IntegrationEvent
{
    public override string Type => "produtos-recomendados-click";
    public string IdSku { get; set; }
}
