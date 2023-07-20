namespace Ecommerce.Api.Requests;

public class CompraRequest
{
    public string? IdSku { get; set; }
    public double Valor { get; set; }
}

public class CompraEvent
{
    public string Key { get; private set; } = Guid.NewGuid().ToString();
    public string? IdSku { get; set; }
    public double Valor { get; set; }
}