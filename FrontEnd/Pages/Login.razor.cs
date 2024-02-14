using AutoMapper;
using FrontEnd.Interface;
using FrontEnd.Model;
using FrontEnd.Model.DTO;
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