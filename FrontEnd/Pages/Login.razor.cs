using FrontEnd.Interface;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using static MudBlazor.CategoryTypes;

namespace FrontEnd.Pages
{
    public partial class Login
    {
        //int failedAttempts = 0;

        [Inject]
        private IAuthorizationService? Authorization { get; set; }
        
        [Inject]
        private NavigationManager? NavigationManager { get; set; }
        
        private async void Authorize()
        {
            if (this.Authorization != null && await Authorization.AuthorizeClient(model))
            { 
                this.NavigationManager?.NavigateTo("/AdminPage");
            }
        }
    }
}