
using FrontEnd.Interface;
using FrontEnd.Model;
using FrontEnd.Shared.Dialog;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;
using MudBlazor.Extensions;


namespace FrontEnd.Pages;

public partial class Recipients
{
    [Inject]
    private IRecipientService? RecipientService { get; set; } 


    private List<Recipient>? GridRecipient { get; set; }


    protected override async  Task OnInitializedAsync()
    {
        if (this.RecipientService != null)
            this.GridRecipient = await this.RecipientService.GetRecipient();
    }
    
    
    private async Task OpenDialog()
    {
        var options = new DialogOptions 
        {
            CloseOnEscapeKey = true,
            MaxWidth = MaxWidth.Large,
            Position = DialogPosition.Center,
        };
        
         var parameters = new DialogParameters<Recipient>();

         var r = new Recipient()
         {
            Id = 10
         };
         parameters.Add("ObjectType", r);
         
       //var result = await(await DialogService.ShowAsync<DialogComponent<Recipient>>("Add Recipient", parameters, options)).Result;
        var result = await(await DialogService.ShowAsync<DialogComponent<Recipient>>("Add Recipient", parameters, options)).Result;
        if (!result.Canceled)
        {
            var recipient = result.Data.As<Recipient>();
        }
        
    }
}