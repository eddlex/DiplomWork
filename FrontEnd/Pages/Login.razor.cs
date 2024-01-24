
using System.Runtime.InteropServices;
using System.Security.Claims;
using FrontEnd.API;
using FrontEnd.Interface;
using FrontEnd.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using MudBlazor;




namespace FrontEnd.Pages
{
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

            if (await this.Authorization.AuthorizeClient(model))
            { 
                
              //  await AuthStateProvider.GetAuthenticationStateAsync();
                navMeneger.NavigateTo("/AdminPage");
            }
        
    
        
        

   

        }
    
    
   

        // protected override async Task OnInitializedAsync()
        // {
        //     await base.OnInitializedAsync();
        // }
        //

    }
}