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
    public async Task<IActionResult> PostAsync()
    {
        await Task.Delay(10);
        return Accepted();
    }
}
