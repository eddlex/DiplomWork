using AutoMapper;
using FrontEnd.Interface;
using FrontEnd.Model;
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

        AuthorizationPost modelpost = new();
        AuthorizationDto model = new();

        public static MapperConfiguration LoginMapperConfig = new MapperConfiguration(cfg =>

                                cfg.CreateMap<AuthorizationDto, AuthorizationPost>());

        private async void Authorize()
        {           
            Mapper mapper = new Mapper(LoginMapperConfig);
            modelpost = mapper.Map<AuthorizationPost>(model);
            if (this.Authorization != null && await Authorization.AuthorizeClient(modelpost))
            { 
                this.NavigationManager?.NavigateTo("/AdminPage");
            }
        }
    }
}