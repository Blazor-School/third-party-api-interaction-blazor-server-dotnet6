namespace ThirdPartyApiInteraction.Utils;

public class SecondMiddleware : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        Console.WriteLine($"{nameof(SecondMiddleware)} interferes BEFORE sending request");
        var response = await base.SendAsync(request, cancellationToken);
        Console.WriteLine($"{nameof(SecondMiddleware)} interferes AFTER sending request");

        return response;
    }
}