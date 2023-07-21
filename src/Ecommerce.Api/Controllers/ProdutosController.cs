namespace Ecommerce.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    /// <summary>
    /// Processamento de eventos de click em produtos recomendados
    /// </summary>
    /// <returns></returns>
    [SwaggerResponse((int)HttpStatusCode.Accepted)]
    [HttpPost("Recomendados/Click")]
    public async Task<IActionResult> PostAsync
    (
        [FromBody] ProdutoRecomendadoClickRequest payload,
        [FromServices] ProdutoRecomendadoService service
    )
    {
        var response = await service.ProcessClickAsync(payload);
        return Accepted(response);
    }
}
