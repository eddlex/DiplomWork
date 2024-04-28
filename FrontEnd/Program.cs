using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using FrontEnd;
using FrontEnd.API;
using FrontEnd.Helpers;
using FrontEnd.Interface;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using MudBlazor.Services;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Builder;


var builder = WebAssemblyHostBuilder.CreateDefault(args);



//builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

//var supportedCultures = new[]
//{
//    new CultureInfo("eng"),
//    new CultureInfo("arm")
//};

//builder.Services.Configure<RequestLocalizationOptions>(options =>
//{
//    options.DefaultRequestCulture = new RequestCulture("arm");
//    options.SupportedCultures = supportedCultures;
//    options.SupportedUICultures = supportedCultures;
//    options.RequestCultureProviders.Remove((IRequestCultureProvider)typeof(AcceptLanguageHeaderRequestCultureProvider));
//});

builder.Services.AddAuthorizationCore();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddSingleton<ISnackbar, SnackbarService>();
builder.Services.AddScoped<HttpClient, HttpClient>();



builder.Services.AddScoped<IHttpService, HttpService>();
builder.Services.AddScoped<IAuthorizationService, AuthorizationService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IRecipientService, RecipientService>();
builder.Services.AddScoped<IDialogService, DialogService>();
builder.Services.AddScoped<IExeptionService, ExeptionService>();
builder.Services.AddScoped<ISmtpService, SmtpService>();
builder.Services.AddScoped<IWeightService, WeightService>();
builder.Services.AddScoped<IRatingService, RatingService>();


builder.Services.AddScoped<IBaseService, FormService>();
builder.Services.AddScoped<ISubjectService, SubjectService>();
builder.Services.AddScoped<IMailService, MailService>();

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationProvider>();


//builder.Services.AddScoped<IConfigurationService, ConfigurationService>();

//builder.Services.AddScoped<IHttpService, HttpService>();


var app = builder.Build().RunAsync();


