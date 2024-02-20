using FrontEnd.Helpers;
using FrontEnd.Interface;
using FrontEnd.Model;
using Microsoft.AspNetCore.Components.Authorization;
namespace FrontEnd.API;

public class AuthorizationService : IAuthorizationService
{
    private CustomAuthenticationProvider  AuthenticationStateProvider { get; set; }
    private readonly IHttpService httpService;
    public AuthorizationService(AuthenticationStateProvider authenticationStateProvider,
                                IHttpService  httpService)
    {
        AuthenticationStateProvider = (CustomAuthenticationProvider)authenticationStateProvider;
        this.httpService = httpService;

    }
    
    public async Task<bool> AuthorizeClient(AuthorizationPost input)
    { 
        input.Password = input.Password.ComputeSHA512Hash();
        var token = await httpService.Execute<string, AuthorizationPost>(HttpMethod.Post, "Security/Authorize", input);
      // var token = "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCIsImN0eSI6IkpXVCJ9.eyJVc2VySWQiOiIwIiwiVW5pdmVyc2l0eUlkIjoiMCIsInJvbGUiOiIwIiwianRpIjoiOGJjOTg3NzItZDM1OC00ODE1LWJjZmItNTFkZWNjYmMzYzFkIiwibmJmIjoxNzA2NDYyNzM0LCJleHAiOjE3MDY0NjYzMzQsImlhdCI6MTcwNjQ2MjczNCwiaXNzIjoibW9oYW1hZGxhd2FuZC5jb20iLCJhdWQiOiJtb2hhbWFkbGF3YW5kLmNvbSJ9.ENbYLl1eSufNCD0J1B81Vur-Devsn9wGOMY5T-FlaBhRTIPI9-rOSPlb-_Eaox9fJlwOLpCTEUaaXax8eDFA9w";
       
  
        if (!await AuthenticationStateProvider.UpdateAuthenticationStateAsync(new UserSession(token)))
             throw Alert.Create(Constants.Error.WrongPasswordOrUserName);
        return true;
    }


  


   
}