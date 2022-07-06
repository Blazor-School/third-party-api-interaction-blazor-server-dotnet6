namespace ThirdPartyApiInteraction.Utils;

public class InterfereByHttpClientWrapperClass
{
    private readonly HttpClient _httpClient;

    public InterfereByHttpClientWrapperClass(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetWeatherDataAsync()
    {
        Console.WriteLine($"{nameof(InterfereByHttpClientWrapperClass)} interferes BEFORE sending request");
        var response = await _httpClient.GetAsync("/weatherforecast");
        string result = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"{nameof(InterfereByHttpClientWrapperClass)} interferes AFTER sending request");

        return result;
    }
}
