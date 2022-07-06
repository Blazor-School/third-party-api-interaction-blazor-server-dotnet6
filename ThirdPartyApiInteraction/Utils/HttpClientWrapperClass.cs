namespace ThirdPartyApiInteraction.Utils;

public class HttpClientWrapperClass
{
    private readonly HttpClient _httpClient;

    public HttpClientWrapperClass(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetWeatherDataAsync()
    {
        var response = await _httpClient.GetAsync("/weatherforecast");
        string result = await response.Content.ReadAsStringAsync();

        return result;
    }
}