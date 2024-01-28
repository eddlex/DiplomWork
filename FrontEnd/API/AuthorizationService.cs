using FrontEnd.Helpers;
using FrontEnd.Interface;
using FrontEnd.Model;
using Microsoft.AspNetCore.Components.Authorization;
namespace FrontEnd.API;

public class AuthorizationService :  HttpService, IAuthorizationService
{
    private CustomAuthenticationProvider  AuthenticationStateProvider { get; set; }
    public AuthorizationService(HttpClient httpClient, 
                                AuthenticationStateProvider authenticationStateProvider):base(httpClient)
    {
        AuthenticationStateProvider = (CustomAuthenticationProvider)authenticationStateProvider;
        
    }
    
    public async Task<bool> AuthorizeClient(AuthorizationPost input)
    {
       var token = await Execute<string, AuthorizationPost>(HttpMethod.Post, "Security/Authorize", input);
       //var token =  "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJVc2VySWQiOiIxIiwiVW5pdmVyc2l0eUlkIjoiMiIsIlJvbGUiOjB9.RDZxg6YjjOh6Gtw8rlc7MAhF6zPryLHG_jcu5eOpRbPhk8YeBoh7Pg-qMOF7LkMQqwNNa4z3HwdAa_rihgOEKg";
  
        if (string.IsNullOrWhiteSpace(token))
            throw new AlertException(Constants.Errors.TokenNotFound);

        if (!await AuthenticationStateProvider.UpdateAuthenticationStateAsync(new UserSession(token)))
             throw new AlertException(Constants.Errors.WrongPasswordOrUserName);
        return true;
    }


   
}