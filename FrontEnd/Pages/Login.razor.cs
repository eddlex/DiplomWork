
using System.Runtime.InteropServices;
using System.Security.Claims;
using FrontEnd.API;
using FrontEnd.Interface;
using FrontEnd.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using MudBlazor;


namespace FrontEnd.Pages;

public partial class Login
{
    [Inject]
    private IAuthorizationService Authorization { get; set; }
    
    
    [Inject]
    private ISnackbar Snackbar { get; set; }
    
    
    
    private async void Authorize()
    {
        //throw new Exception("hello");
        if (model.Password.Length < 5  || model.LogIn.Length < 5) 
            return;

        var token =  await this.Authorization.AuthorizeClient(model);

        
        await AuthenticationState;
        
        //var aaa = await authentcationState;
        navMeneger.NavigateTo("/Login");

        // await JSRuntime.InvokeVoidAsync("alert", s);
        //await js.Alert(s);

    }
    
    
    [CascadingParameter]
    private Task<AuthenticationState> AuthenticationState { get; set; }

    public ClaimsPrincipal AuthenticatedUser { get; set; }
    //public AccessToken AccessToken { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        
        
        
        //var accessTokenResult = await AuthorizationService();
       //
       //
       //  if (!accessTokenResult.TryGetToken(out var token))
       //  {
       //      throw new InvalidOperationException(
       //          "Failed to provision the access token.");
       //  }

        //AccessToken = token;

       // AuthenticatedUser = state.User;
    }
    

}