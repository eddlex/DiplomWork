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
        await form.Validate();
        if (this.UserService is null || this.DepartmentService == null || !form.IsValid)
            return;
        
        if (await this.UserService.RegisterUser(Model))
        {
            this.NavigationManager?.NavigateTo("/");
        }
    }


    private Select<Department>? Departments { get; set; } = new("Select Department", nameof(RegistrationPost.DepartmentId));
    protected override async  Task OnInitializedAsync()
    {
        if (this.DepartmentService != null) 
        {
            this.Departments?.ConvertListToEnum(await this.DepartmentService.GetDepartments());
            this.Model.Suscribe(this.Departments);
        }
    } 
    
  
        
}
    
  
