namespace Ecommerce.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ComprasController : ControllerBase
{
    /// <summary>
    /// Processamento de eventos de compra
    /// </summary>
    /// <returns></returns>
    [SwaggerResponse((int)HttpStatusCode.Accepted)]
    [HttpPost]
    public async Task<IActionResult> PostAsync
    (
        [FromBody] CompraRequest request,
        [FromServices] CompraService service
    )
    {
        await service.ProcessAsync(request);
        return Accepted();
    }
}
