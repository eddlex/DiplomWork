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
    private IUniversityService? UniversityService { get; set; } 
    [Inject]
    private NavigationManager? NavigationManager { get; set; }

    private RegistrationPost Model { get; set; } = new();
     
    private async void Register()
    {
        if (this.UserService is null || this.UniversityService == null)
        {
            return;
        }
        
        if (await this.UserService.RegisterUser(Model))
        {
            this.NavigationManager?.NavigateTo("/");
        }
    }


    private Dictionary<int, string>? University { get; set; } = new();
    protected override async  Task OnInitializedAsync()
    {
        if (this.UniversityService != null)
        {
            var result = await this.UniversityService.GetUniversities();
            if (result != null)
            {
                foreach (var e in result)
                {
                    University?.Add(e.Id, e.Name);
                }
            }
        }
    }
}