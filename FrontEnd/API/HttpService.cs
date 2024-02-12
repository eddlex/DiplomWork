using System.Net;
using FrontEnd.Helpers;
using FrontEnd.Interface;
using FrontEnd.Model;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using Exception = System.Exception;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace FrontEnd.API;

public class HttpService : IHttpService
{
    private readonly HttpClient httpClient;
    private readonly CustomAuthenticationProvider authenticationStateProvider;

    public int failedAttempts = 0;
    //IJSRuntime js;
    public HttpService(HttpClient httpClient, AuthenticationStateProvider authenticationStateProvider)
    {
        this.httpClient = httpClient;
        this.authenticationStateProvider = (CustomAuthenticationProvider)authenticationStateProvider;
        //this.js = IJSRuntime;
    }

    public async Task<UserSession?> GetSession()
    {
        return await this.authenticationStateProvider.GetSession(); 
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

            var session = await this.authenticationStateProvider.GetSession();
            if (session != null && !string.IsNullOrWhiteSpace(session.Token))
            {
                request.Headers.Authorization = new("Bearer", session.Token);
            }
            
            request.Headers.Add("Accept", "application/json");

            if (requestBody != null)
            {

                request.Content = new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json");
			}

            var response = await this.httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
               
              
                var r  = JsonConvert.DeserializeObject<T1>(result);
                return r;
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
            //if (++failedAttempts >= 3 && ex.Message == "UserName or password is wrong")
            //    await js.InvokeVoidAsync("setLinkRed");
            //return false;
            throw new AlertException(ex.Message);
        }
    }
}