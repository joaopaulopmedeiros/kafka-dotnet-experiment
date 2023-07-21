namespace Ecommerce.Consumer.Handlers;

public class CompraHandler : IIntegrationEventHandler<CompraEvent>
{
    public async Task Handle(CompraEvent @event)
    {
        await Task.Delay(100);
        Console.WriteLine("hello world");
    }
}
