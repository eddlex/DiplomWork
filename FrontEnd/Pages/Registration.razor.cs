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
    private IDepartmentService? DepartmentService { get; set; } 
    [Inject]
    private NavigationManager? NavigationManager { get; set; }

    private RegistrationPost Model { get; set; } = new();
     
    private async void Register()
    {
        if (this.UserService is null || this.DepartmentService == null)
        {
            return;
        }
        
        if (await this.UserService.RegisterUser(Model))
        {
            this.NavigationManager?.NavigateTo("/");
        }
    }


    private Dictionary<int, string>? Departments { get; set; } = new();
    protected override async  Task OnInitializedAsync()
    {
        if (this.DepartmentService != null)
        {
            var result = await this.DepartmentService.GetDepartments();
            if (result != null)
            {
                foreach (var e in result)
                {
                    Departments?.Add(e.Id, e.Name);
                }
            }
        }
    }
}