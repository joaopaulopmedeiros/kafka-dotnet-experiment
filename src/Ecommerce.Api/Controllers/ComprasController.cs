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
        [FromHeader(Name = "X-Utms")] string utm,
        [FromBody] CompraRequest payload,
        [FromServices] CompraService service
    )
    {
        var response = await service.ProcessAsync(payload, utm);
        return Accepted(response);
    }
}
