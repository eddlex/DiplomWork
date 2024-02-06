using FrontEnd.Interface;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using static MudBlazor.CategoryTypes;

namespace FrontEnd.Pages
{
    public partial class Login
    {
        int failedAttempts = 0;

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

            else
            {
                ++failedAttempts;
                if (failedAttempts >= 3)
                {
                    await js.InvokeVoidAsync("setLinkRed");
                //    // Update the style of the "Forgot password?" link to red
                //    // You can do this by setting a CSS class
                //    // You might need to add an ID or a class to the <a> tag for easy selection
                //    // For example:
                //    // failedAttemptsLinkClass = "red-link";
                }

            }
        }
    }
}