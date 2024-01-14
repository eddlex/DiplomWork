
using FrontEnd.Interface;
using FrontEnd.Model;
using Microsoft.AspNetCore.Components;
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
        object s = "121112131";
        s =  await this.Authorization.AuthorizeClient(model);
       


        // await JSRuntime.InvokeVoidAsync("alert", s);
        //await js.Alert(s);

    }
    

}