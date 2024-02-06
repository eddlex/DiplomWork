
using FrontEnd.Interface;
using FrontEnd.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;


namespace FrontEnd.Pages;

public partial class RecipientDialog
{
    //[Inject]
    //private IUserService? UserService { get; set; } 
    //private List<Recipient?> GridUsers { get; set;}

    //protected override async Task OnInitializedAsync()
    //{
    //     this.GridUsers = await this.UserService.GetUsers();
    //}
    private List<Recipient> RecipientsGrid = new List<Recipient>();
}