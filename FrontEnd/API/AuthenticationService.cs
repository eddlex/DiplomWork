using System.Security.Claims;
using Blazored.SessionStorage;
using FrontEnd.Helpers;
using FrontEnd.Model;
using Microsoft.AspNetCore.Components.Authorization;

namespace FrontEnd.API;

public class CustomAuthenticationProvider : AuthenticationStateProvider
{
    private readonly ISessionStorageService sessionStorageService;
    private ClaimsPrincipal anonymous = new(new ClaimsIdentity());

    public CustomAuthenticationProvider(ISessionStorageService sessionStorageService)
    {
        this.sessionStorageService = sessionStorageService;
    }
    
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try
        {
            var userSession = await sessionStorageService.GetItem<UserSession>("UserSession");
            if (userSession == null)
                return new AuthenticationState(anonymous);
            var claimsPrincipal = new ClaimsPrincipal(
                new ClaimsIdentity(
                    new List<Claim>
                    {
                        new Claim("UserId", userSession.UserId.ToString()),
                        new Claim("PermissionId", userSession.PermissionId.ToString()),
                        new Claim("UniversityId", userSession.UniversityId.ToString()),
                        new Claim("Token", userSession.Token)
                        
                    })
            );
            
             return new AuthenticationState(claimsPrincipal);
        }
        catch
        {
            return new AuthenticationState(anonymous);
        }
        
    }

    public async Task<bool> UpdateAuthenticationStateAsync(UserSession? userSession)
    {
        // ClaimsPrincipal claimsPrincipal;
        if (userSession is not null)
        {
        //     claimsPrincipal = new ClaimsPrincipal(
        //         new ClaimsIdentity(
        //             new List<Claim>
        //             {
        //                 new Claim("UserId", userSession.UserId.ToString()),
        //                 new Claim("PermissionId", userSession.PermissionId.ToString()),
        //                 new Claim("UniversityId", userSession.UniversityId.ToString())
        //             }
        //         )
        //     );
        //     
        //    var claims = new List<Claim>
        //             {
        //                 new Claim("UserId", userSession.UserId.ToString()),
        //                 new Claim("PermissionId", userSession.PermissionId.ToString()),
        //                 new Claim("UniversityId", userSession.UniversityId.ToString())
        //             };
                
           //await sessionStorageService.SaveItem<ClaimsPrincipal>("UserSession", claimsPrincipal);
           await sessionStorageService.SaveItem("UserSession", userSession);
        }
        else
        {
          // claimsPrincipal = anonymous;
           await sessionStorageService.RemoveItemAsync("UserSession");
        }
        
        var claimsPrincipal = new ClaimsPrincipal(
            new ClaimsIdentity(
                new List<Claim>
                {
                    new Claim("UserId", userSession.UserId.ToString()),
                    new Claim("PermissionId", userSession.PermissionId.ToString()),
                    new Claim("UniversityId", userSession.UniversityId.ToString()),
                    new Claim("Token", userSession.Token)
                }
            )
        );
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        return true;
    }


    public async Task<string> GetToken()
    {
        try
        {
          //  var userSession = await sessionStorageService.GetItem<UserSession>("UserSession");
            var userSession = await sessionStorageService.GetItem<UserSession>("UserSession");
            
            return userSession?.Token?? string.Empty;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);

        }
    }
    
    
}