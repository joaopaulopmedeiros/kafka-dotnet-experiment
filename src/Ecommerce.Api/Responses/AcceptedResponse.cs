namespace Ecommerce.Api.Responses;

public class AcceptedResponse
{
    public AcceptedResponse(string key, string message)
    {
        Key = key;
        Message = message;
    }

    public string Key { get; private set; }
    public string Message { get; private set; }
}
