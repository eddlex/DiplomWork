
using FrontEnd.Interface;
using FrontEnd.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;


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
}