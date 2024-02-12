
using FrontEnd.Interface;
using FrontEnd.Model;
using FrontEnd.Model.DTO;
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
    
    [Inject]
    private IDepartmentService? DepartmentService { get; set; } 


    private List<RecipientDto>? RecipientDto { get; set; }


    protected override async Task OnInitializedAsync()
    {
        if (this.RecipientService != null && 
            this.DepartmentService != null)
        {
           var recipientBl = await this.RecipientService.GetRecipient();
           var recipientsGroups = await this.RecipientService.GetRecipientsGroups();
           var departments = await this.DepartmentService.GetDepartments();
           if (recipientBl is { Count: > 0 })
           {
               this.RecipientDto = new();
               recipientBl.ForEach(e => this.RecipientDto.Add(new RecipientDto()
               {
                   Id = e.Id,
                   Name = e.Name,
                   Description = e.Description,
                   Department = departments?.FirstOrDefault(d => d.Id == e.DepartmentId)?.Name,
                   Group = recipientsGroups?.FirstOrDefault(d => d.Id == e.GroupId)?.Name,
                   Mail = e.Mail
               }));
           }
           
           
           
        } 
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