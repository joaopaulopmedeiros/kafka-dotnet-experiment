namespace Ecommerce.Core.Events;

public abstract class IntegrationEvent
{
    public string Key { get; private set; } = Guid.NewGuid().ToString();
    public virtual string Type { get; private set; }
    public DateTime Timestamp { get; private set; } = DateTime.UtcNow;
}
