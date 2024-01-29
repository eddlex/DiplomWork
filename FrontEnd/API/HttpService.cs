using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Text.Json;
using FrontEnd.Helpers;
using FrontEnd.Interface;
using Exception = System.Exception;

namespace FrontEnd.API;

public class HttpService : IHttpService
{
    private HttpClient HttpClient { get; set; }
    public HttpService(HttpClient httpClient)
    {
        this.HttpClient = httpClient;
    }

    public async Task<T1?> Execute<T1, T2>(HttpMethod method, string apiUrl, T2? requestBody = default)
    {
        try
        {
            var request = new HttpRequestMessage
            {
                Method = method,
                RequestUri = new Uri(ConfigurationService.URL + apiUrl)
            };

            request.Headers.Add("Accept", "application/json");

            if (requestBody != null)
            {
                request.Content = new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json");
            }

            var response = await this.HttpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<T1>(result);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                var parsedJson = JsonSerializer.Deserialize<Dictionary<string, string>>(await response.Content.ReadAsStringAsync());
                if (parsedJson != null && parsedJson.TryGetValue("ErrorMessage", out var extractedValue))
                {
                    throw new AlertException(extractedValue);
                }
            }
          
            throw new AlertException(Constants.Error.BackEnd);
        }
        catch (Exception ex)
        {
            throw new AlertException(ex.Message);
        }
    }
}