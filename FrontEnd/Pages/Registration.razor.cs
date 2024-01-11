using FrontEnd.Interface;
using FrontEnd.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;


namespace FrontEnd.Pages;

public partial class Registration
{
    //[Inject]
    //private IAuthorizationService Regist { get; set; }


    [Inject]
    protected IJSRuntime js { get; set; }

    private RegistrationPost _model = new();

    //private async void Register()
    //{
    //    object s = "121112131";
    //    try
    //    {
    //        s =  await this.Regist.RegisterClient(_model);
    //    }
    //    finally
    //    {
    //        s = "error";
    //    }

    //    // await JSRuntime.InvokeVoidAsync("alert", s);
    //    //await js.Alert(s);
    //    _model.LogIn = "jwjjwesadjsdjf";
    //}
}