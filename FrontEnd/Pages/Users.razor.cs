
using FrontEnd.Interface;
using FrontEnd.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;


namespace FrontEnd.Pages;

public partial class Users
{
    [Inject]
    private IUserService? UserService { get; set; } 
    private List<User?> GridUsers { get; set;}

    protected override async Task OnInitializedAsync()
    {
         this.GridUsers = await this.UserService.GetUsers();
    }

}