using AutoMapper;
using FrontEnd.Helpers;
using FrontEnd.Interface;
using FrontEnd.Model;
using Microsoft.AspNetCore.Components;
using FrontEnd.API;

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

    public static MapperConfiguration RegisterMapperConfig = new MapperConfiguration(cfg =>

                                cfg.CreateMap<RegistrationDto, RegistrationPost>());

    Mapper mapper = new Mapper(RegisterMapperConfig);

    private async void Register()
    {
        await form.Validate();
        if (this.UserService is null || this.DepartmentService == null || !form.IsValid)
            return;

        ModelPost = mapper.Map<RegistrationPost>(Model);
        if (await this.UserService.RegisterUser(ModelPost))
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
            this.ModelPost.Suscribe(this.Departments);
        }
    } 
    
  
        
}
    
  
