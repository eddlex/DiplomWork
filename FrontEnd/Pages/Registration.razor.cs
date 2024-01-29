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
     
    private async void Register()
    {
        if (this.UserService is null)
        {
            return;
        }
        
        if (await this.UserService.RegisterUser(model))
        {
            this.NavigationManager?.NavigateTo("/");
        }
    }
}