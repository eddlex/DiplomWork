using FrontEnd.Interface;
using FrontEnd.Model;
using FrontEnd.Model.DTO;
using Microsoft.AspNetCore.Components;

namespace FrontEnd.Pages
{
    public partial class Login
    {
        [Inject]
        private IAuthorizationService? Authorization { get; set; }
        
        [Inject]
        private NavigationManager? NavigationManager { get; set; }

        AuthorizationPost modelPost = new();

        AuthorizationDto model = new();

        private async void Authorize()
        {           
            modelPost = GenericAutoMapper<AuthorizationDto, AuthorizationPost>.Map(model);
            if (this.Authorization != null && await Authorization.AuthorizeClient(modelPost))
            { 
                this.NavigationManager?.NavigateTo("/AdminPage");
            }
        }
    }
}