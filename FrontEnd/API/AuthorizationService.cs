using System.Net.Http.Json;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using FrontEnd.Helpers;
using FrontEnd.Interface;
using FrontEnd.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;

namespace FrontEnd.API;

public class AuthorizationService :  HttpService, IAuthorizationService
{
    
    public AuthorizationService(HttpClient httpClient):base(httpClient)
    { 
    }
    public async Task<string> AuthorizeClient(AuthorizationPost input)
    {
        var token = await Execute<string, AuthorizationPost>(HttpMethod.Post, "Security/Authorize", input);


        return token;
    }


   
}