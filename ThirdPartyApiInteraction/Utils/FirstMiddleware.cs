namespace ThirdPartyApiInteraction.Utils;

public class FirstMiddleware : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        Console.WriteLine($"{nameof(FirstMiddleware)} interferes BEFORE sending request");
        var response = await base.SendAsync(request, cancellationToken);
        Console.WriteLine($"{nameof(FirstMiddleware)} interferes AFTER sending request");

        return response;
    }
}
