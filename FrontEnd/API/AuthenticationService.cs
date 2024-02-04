using System.Security.Claims;
using Blazored.SessionStorage;
using FrontEnd.Helpers;
using FrontEnd.Model;
using Microsoft.AspNetCore.Components.Authorization;
using Exception = System.Exception;

namespace FrontEnd.API;

public class CustomAuthenticationProvider : AuthenticationStateProvider
{
    private readonly ISessionStorageService sessionStorageService;
    
    public CustomAuthenticationProvider(ISessionStorageService sessionStorageService)
    {
        this.sessionStorageService = sessionStorageService;
    }
    
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try
        {
            var userSession = await sessionStorageService.GetItem("UserSession");
            if (userSession == null)
                return new AuthenticationState(new(new ClaimsIdentity()));
            var claimsPrincipal = new ClaimsPrincipal(
                new ClaimsIdentity(
                    new List<Claim>
                    {
                        new Claim("UserId", userSession.UserId.ToString()),
                        new Claim(ClaimTypes.Role, userSession.RoleId.ToString()),
                        new Claim("UniversityId", userSession.UniversityId.ToString()),
                        new Claim("Token", userSession.Token)
                        
                    })
            );
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
            return new AuthenticationState(claimsPrincipal);
        }
        catch(Exception ex)
        {
           // throw new AlertException(ex.Message);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()))));
            return new AuthenticationState(new(new ClaimsIdentity()));
        }
        
    }

    public async Task<bool> UpdateAuthenticationStateAsync(UserSession? userSession)
    {
        if (userSession is not null)
        {
            await sessionStorageService.SaveItem("UserSession", userSession);
            var claimsPrincipal = new ClaimsPrincipal(
                new ClaimsIdentity(
                    new List<Claim>
                    {
                        new Claim("UserId", userSession.UserId.ToString()),
                        new Claim("UniversityId", userSession.UniversityId.ToString()),
                        new Claim(ClaimTypes.Role, userSession.RoleId.ToString()),
                        new Claim("Token", userSession.Token)
                    }
                )
            );
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }
        else
        {
            await sessionStorageService.RemoveItemAsync("UserSession");
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal())));
        }
        
        return true;
    }


    public async Task<UserSession?> GetSession()
    {
        try
        {
          //  var userSession = await sessionStorageService.GetItem<UserSession>("UserSession");
            var userSession = await sessionStorageService.GetItem("UserSession");

            return userSession;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
    
        }
    }
    
    
}