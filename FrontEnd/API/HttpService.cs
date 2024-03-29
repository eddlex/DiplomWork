﻿using System.Net;
using FrontEnd.Helpers;
using FrontEnd.Interface;
using FrontEnd.Model;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using MudBlazor;
using Newtonsoft.Json;
using Exception = System.Exception;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace FrontEnd.API;

public class HttpService : IHttpService
{
    private readonly HttpClient httpClient;
    private readonly CustomAuthenticationProvider authenticationStateProvider;
    private readonly IExeptionService exeptionService;

    public int failedAttempts = 0;
    //IJSRuntime js;
    public HttpService(HttpClient httpClient,
                       AuthenticationStateProvider authenticationStateProvider,
                       IExeptionService exeptionService)
    {
        this.httpClient = httpClient;
        this.authenticationStateProvider = (CustomAuthenticationProvider)authenticationStateProvider;
        this.exeptionService = exeptionService;
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
            var url = ConfigurationService.URL + apiUrl;

            if (requestBody != null && method == HttpMethod.Get)
                url += $"?id={requestBody}";
            var request = new HttpRequestMessage
            {
                Method = method,
                RequestUri = new Uri(url)
            };

            var session = await this.authenticationStateProvider.GetSession();
            if (session != null && !string.IsNullOrWhiteSpace(session.Token))
            {
                request.Headers.Authorization = new("Bearer", session.Token);
            }
            
            request.Headers.Add("Accept", "application/json");

            if (requestBody != null && method != HttpMethod.Get)
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
                   throw exeptionService.Create(extractedValue);
                }
            }
          
            throw exeptionService.Create(Constants.Error.BackEnd);
        }
        catch (Exception ex)
        {
            //if (++failedAttempts >= 3 && ex.Message == "UserName or password is wrong")
            //    await js.InvokeVoidAsync("setLinkRed");
            //return false;
            throw exeptionService.Create(ex.Message);
        }
    }
}