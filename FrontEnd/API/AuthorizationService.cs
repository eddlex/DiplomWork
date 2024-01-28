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
      // var token = "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCIsImN0eSI6IkpXVCJ9.eyJVc2VySWQiOiIwIiwiVW5pdmVyc2l0eUlkIjoiMCIsInJvbGUiOiIwIiwianRpIjoiOGJjOTg3NzItZDM1OC00ODE1LWJjZmItNTFkZWNjYmMzYzFkIiwibmJmIjoxNzA2NDYyNzM0LCJleHAiOjE3MDY0NjYzMzQsImlhdCI6MTcwNjQ2MjczNCwiaXNzIjoibW9oYW1hZGxhd2FuZC5jb20iLCJhdWQiOiJtb2hhbWFkbGF3YW5kLmNvbSJ9.ENbYLl1eSufNCD0J1B81Vur-Devsn9wGOMY5T-FlaBhRTIPI9-rOSPlb-_Eaox9fJlwOLpCTEUaaXax8eDFA9w";
       
  
        if (string.IsNullOrWhiteSpace(token))
            throw new AlertException(Constants.Errors.WrongPasswordOrUserName);

        if (!await AuthenticationStateProvider.UpdateAuthenticationStateAsync(new UserSession(token)))
             throw new AlertException(Constants.Errors.WrongPasswordOrUserName);
        return true;
    }


  


   
}