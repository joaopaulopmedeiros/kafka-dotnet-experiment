namespace Ecommerce.Core.Events;

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
