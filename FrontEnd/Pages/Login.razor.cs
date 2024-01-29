using FrontEnd.Interface;
using Microsoft.AspNetCore.Components;

namespace FrontEnd.Pages
{
    public partial class Login
    {
        [Inject]
        private IAuthorizationService? Authorization { get; set; }
        
        [Inject]
        private NavigationManager? NavigationManager { get; set; }
        
        private async void Authorize()
        {
            if (this.Authorization != null && await Authorization.AuthorizeClient(model))
            { 
                this.NavigationManager?.NavigateTo("/");
            }
        }
    }
}