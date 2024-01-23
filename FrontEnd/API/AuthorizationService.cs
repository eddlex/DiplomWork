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
    public async Task<string> AuthorizeClient(AuthorizationPost input)
    {
       // var token = await Execute<string, AuthorizationPost>(HttpMethod.Post, "Security/Authorize", input);
       var s = new UserSession(1, 1, 1, "11111");
       await AuthenticationStateProvider.UpdateAuthenticationStateAsync(s);
       //var a =  await this.AuthenticationStateProvider.GetToken();
       
       return "aaaa";
    }


   
}