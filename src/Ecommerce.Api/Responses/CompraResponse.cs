namespace Ecommerce.Api.Responses;

public class CompraResponse
{
    public CompraResponse(string key)
    {
        Key = key;
    }

    public string Key { get; private set; } 
    public string Message { get; private set; } = "evento de compra em processamento.";
}
