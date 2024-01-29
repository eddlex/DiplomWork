using System.Net;
using Blazored.SessionStorage;
// using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using FrontEnd;
using FrontEnd.API;
using FrontEnd.Interface;
using Microsoft.AspNetCore.Components.Authorization;
// using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using MudBlazor.Services;


var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();



builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddSingleton<ISnackbar, SnackbarService>();
builder.Services.AddScoped<HttpClient>();



builder.Services.AddScoped<IHttpService, HttpService>();
builder.Services.AddScoped<IAuthorizationService, AuthorizationService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUniversityService, UniversityService>();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationProvider>();


//builder.Services.AddScoped<IConfigurationService, ConfigurationService>();

//builder.Services.AddScoped<IHttpService, HttpService>();


var app = builder.Build().RunAsync();


