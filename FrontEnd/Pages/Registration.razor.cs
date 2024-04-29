using AutoMapper;
using FrontEnd.Helpers;
using FrontEnd.Interface;
using FrontEnd.Model;
using Microsoft.AspNetCore.Components;
using FrontEnd.API;
using FrontEnd.Model.DTO;
using System.Reflection;

namespace FrontEnd.Pages;

public partial class Registration 
{
    [Inject] 
    private IUserService? UserService { get; set; } 
    [Inject] 
    private IDepartmentService? DepartmentService { get; set; } 
    [Inject]
    private NavigationManager? NavigationManager { get; set; }

    private RegistrationDto Model { get; set; } = new();
    private RegistrationPost ModelPost { get; set; } = new();
    
    private async void Register()
    {
        await form.Validate();
        if (this.UserService is null || this.DepartmentService == null || !form.IsValid)
            return;

        //ModelPost = mapper.Map<RegistrationPost>(Model);
        ModelPost = GenericAutoMapper<RegistrationDto, RegistrationPost>.Map(Model);

        if (await this.UserService.RegisterUser(ModelPost))
        {
            this.NavigationManager?.NavigateTo("/");
        }
    }


    private Select<DepartmentBl>? Departments { get; set; } = new("Ամբիոն", nameof(RegistrationPost.DepartmentId));
    protected override async  Task OnInitializedAsync()
    {
        if (this.DepartmentService != null) 
        {
            this.Departments?.ConvertListToEnum(await this.DepartmentService.GetDepartments());
            this.Model.Suscribe(this.Departments);
        }
    } 
    
  
        
}
    
  
