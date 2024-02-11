using FrontEnd.Helpers;
using FrontEnd.Interface;
using FrontEnd.Model;
using Microsoft.AspNetCore.Components;

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
            return;

        await form.Validate();
        
        if (form.IsValid)
        {
            
            if (await this.UserService.RegisterUser(Model))
            {
                this.NavigationManager?.NavigateTo("/");
            }
        }
    }


    private Select Departments { get; set; } = new("Select Department",
                                                nameof(RegistrationPost.DepartmentId));
    protected override async  Task OnInitializedAsync()
    {
        this.Model.Suscribe(this.Departments);
        if (this.DepartmentService != null)
        {
            var result = await this.DepartmentService.GetDepartments();
            if (result != null)
            {
                foreach (var e in result)
                {
                    Departments?.Add(e.Name, e.Id);
                }
            }
        }
    }
}