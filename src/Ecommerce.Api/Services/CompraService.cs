namespace Ecommerce.Api.Services;

public class CompraService
{
    /// <summary>
    /// Mapeia requisição em evento de compra e envia para tópico kafka
    /// onde será processado em background de forma assíncrona.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public async Task ProcessAsync(CompraRequest request)
    {
        await Task.Delay(100);
    }
}
