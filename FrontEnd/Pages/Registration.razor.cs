using FrontEnd.API;
using FrontEnd.Interface;
using FrontEnd.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;


namespace FrontEnd.Pages;

public partial class Registration
{
    [Inject] 
    private IUserService? UserService { get; set; } 
    [Inject]
    private NavigationManager? NavigationManager { get; set; }
    
     private RegistrationPost model = new();
 
    // public Registration(IUserService userService, NavigationManager navigationManager)
    // {
    //     this.UserService = (UserService)userService;
    //     this.NavigationManager = navigationManager;
    //    
    // }
    
    
    private async void Register()
    {
         var result = await this.UserService?.RegisterUser(model);
         if (result)
             this.NavigationManager?.NavigateTo("/");
    }
}