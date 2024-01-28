using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using FrontEnd.Helpers;
using FrontEnd.Interface;
using MudBlazor;

namespace FrontEnd.API;

public class HttpService : IHttpService
{
    private HttpClient HttpClient { get; set; }
    public HttpService(HttpClient httpClient)
    {
        this.HttpClient = httpClient;
    }

    public async Task<T1?> Execute<T1, T2>(HttpMethod method, string apiUrl, T2 requestBody)
    {
        try
        {
            // Create HttpRequestMessage
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
            
            throw new AlertException(Constants.Errors.SomethingWrong);
        }
        catch (Exception ex)
        {
            throw new AlertException(ex.Message);
            
            
        }
    }
}