namespace Ecommerce.Consumer.Handlers;

public class CompraHandler
{
    public async Task HandleAsync()
    {
        await Task.Delay(1000);
        Console.WriteLine("handled...");
    }
}
