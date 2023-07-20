namespace Ecommerce.Api.Requests;

public class CompraRequest
{
    public string IdSku { get; set; }
    public double Valor { get; set; }
}

public class CompraEvent : IntegrationEvent
{
    public override string Type => "compra"; 
    public Utm? Utm { get; set; }
    public string IdSku { get; set; }
    public double Valor { get; set; }

    public void UseUtm(Utm utm) => Utm = utm;
}

public class Utm
{
    public string Source { get; set; }
    public string Medium { get; set; }
    public string Campaign { get; set; }
}

public abstract class IntegrationEvent
{
    public string Key { get; private set; } = Guid.NewGuid().ToString();
    public virtual string Type { get; private set;  }
    public DateTime Timestamp { get; private set; } = DateTime.UtcNow;
}