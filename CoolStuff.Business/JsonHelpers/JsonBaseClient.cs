using System.Net;
using System.Net.Http.Headers;

namespace CoolStuff.Business.JsonHelpers;

public class JsonBaseClient : IDisposable
{
    protected readonly HttpClient HTTPClient;

    protected JsonBaseClient(string baseUrl)
    {
        var handler = new HttpClientHandler
        {
            AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
        };
        HTTPClient = new HttpClient(handler)
        {
            BaseAddress = new Uri(baseUrl)
        };

        HTTPClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        
    }

    protected async Task<string> PostAsync(string url, HttpContent content)
    {
        var responseMessage = await HTTPClient.PostAsync(url, content);
        return await VerifySuccessAsync(responseMessage);
    }

    protected async Task<string> GetAsync(string url)
    {
        var responseMessage = await HTTPClient.GetAsync(url);
        return await VerifySuccessAsync(responseMessage);
    }

    private static async Task<string> VerifySuccessAsync(HttpResponseMessage responseMessage)
    {
        if (responseMessage.Content == null)
            throw new SimpleHttpResponseException(responseMessage.StatusCode, "No content");

        var content = await responseMessage.Content.ReadAsStringAsync();
        if (responseMessage.IsSuccessStatusCode) return content;

        responseMessage.Content.Dispose();

        throw new SimpleHttpResponseException(responseMessage.StatusCode, content);
    }

    public void Dispose()
    {
        HTTPClient?.Dispose();
    }
}