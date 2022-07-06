namespace ThirdPartyApiInteraction.Utils;

public static class HttpClientExtension
{
    public static async Task<string> GetWeatherAsync(this HttpClient httpClient)
    {
        Console.WriteLine($"{nameof(HttpClientExtension)} interferes BEFORE sending request");
        var response = await httpClient.GetAsync("/weatherforecast");
        Console.WriteLine($"{nameof(HttpClientExtension)} interferes AFTER sending request");
        string result = await response.Content.ReadAsStringAsync();

        return result;
    }
}
