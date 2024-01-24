using System.Net.Http.Json;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using FrontEnd.Helpers;
using FrontEnd.Interface;
using FrontEnd.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using MudBlazor;

namespace FrontEnd.API;

public class AuthorizationService :  HttpService, IAuthorizationService
{
    private List<UserSession> Sessions { get; set; }
    
    [Inject]
    private CustomAuthenticationProvider  AuthenticationStateProvider { get; set; }
    public AuthorizationService(HttpClient httpClient, 
                                AuthenticationStateProvider authenticationStateProvider):base(httpClient)
    {
        AuthenticationStateProvider = (CustomAuthenticationProvider)authenticationStateProvider;
        Sessions = new List<UserSession>();
        Sessions.Add(new UserSession(0, 0, 0, "s"));


    }
    
    public UserSession? GetClientSession(int userId)
    {
        return this.Sessions.FirstOrDefault(s => s.UserId == userId);
    }
    public async Task<bool> AuthorizeClient(AuthorizationPost input)
    {
       // var token = await Execute<string, AuthorizationPost>(HttpMethod.Post, "Security/Authorize", input);

        var token = "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJVc2VySWQiOiIxIiwiVW5pdmVyc2l0eUlkIjoiMiIsIlBlcm1pc3Npb25JZCI6M30.qedLD2ghRWYta_TSv7-GV37InOOvcLyYg-r-VSzVZsGqLTAzendRKJPvx3G86JIttYTi9p4p11bvZtXeYernXQ";
  
        if (string.IsNullOrWhiteSpace(token))
            throw new AlertException(Constants.Errors.TokenNotFound);

        return await AuthenticationStateProvider.UpdateAuthenticationStateAsync(new UserSession(token));
       
    }


   
}