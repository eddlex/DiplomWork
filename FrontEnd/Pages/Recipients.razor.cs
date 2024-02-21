using FrontEnd.Helpers;
using FrontEnd.Interface;
using FrontEnd.Model;
using FrontEnd.Model.BL;
using FrontEnd.Model.Dialog;
using FrontEnd.Model.DTO;
using FrontEnd.Shared.Dialog;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace FrontEnd.Pages;

public partial class Recipients
{
    [Inject]
    private IRecipientService? RecipientService { get; set; } 
    
    [Inject]
    private IDepartmentService? DepartmentService { get; set; } 


    private List<RecipientDto?>? RecipientDto { get; set; }
    private List<Recipient>? RecipientBl { get; set; }
    private List<Department>? Departments { get; set; }
    private List<RecipientGroup>? RecipientsGroups { get; set; }
    
    

    protected override async Task OnInitializedAsync()
    {
        if (this.RecipientService != null && 
            this.DepartmentService != null)
        {
           this.RecipientBl = await this.RecipientService.GetRecipient();
           this.RecipientsGroups = await this.RecipientService.GetRecipientsGroups();
           this.Departments = await this.DepartmentService.GetDepartments();
           this.RecipientDto = new();
           if (this.RecipientBl is { Count: > 0 })
           {
               
               this.RecipientBl.ForEach(e => this.RecipientDto.Add(new RecipientDto()
               {
                   Id = e.Id,
                   Name = e.Name,
                   Description = e.Description,
                   Department = this.Departments?.FirstOrDefault(d => d.Id == e.DepartmentId)?.Name,
                   Group = this.RecipientsGroups?.FirstOrDefault(d => d.Id == e.GroupId)?.Name,
                   Mail = e.Mail
               }));
           }
           
           
           
        } 
    }


    private async Task DeleteRecipient(int id)
    {
        if (this.RecipientService != null && await DeleteUser())
        {
            var result = await this.RecipientService.DelRecipient(RecipientBl.Find(r => r.Id == id));
            if (result.HasValue)
            {
                RecipientDto?.Remove(RecipientDto.FirstOrDefault(row => row?.Id == result.Value));
            }
        }
    }
    
    
    private async Task<bool> DeleteUser()
    {
        var parameters = new DialogParameters<DeleteDialog>();
        parameters.Add(x => x.ContentText, "Do you really want to delete this row? This process cannot be undone.");
        parameters.Add(x => x.ButtonText, "Delete");
        parameters.Add(x => x.Color, Color.Error);

        var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.ExtraSmall };

        return !(await(await DialogService.ShowAsync<DeleteDialog>("Delete", parameters, options)).Result).Canceled;
        
    }
    private async Task AddRecipient()
    {
       var recipient = await OpenDialog();
       if (recipient != default && this.RecipientService != null)
       {
           var result = await this.RecipientService.AddRecipient(recipient);
           if (result != null)
           {
               this.RecipientDto?.Add(new RecipientDto()
               {
                   Id = result.Id,
                   Name = result.Name,
                   Description = result.Description,
                   Department = this.Departments?.FirstOrDefault(d => d.Id == result.DepartmentId)?.Name,
                   Group = this.RecipientsGroups?.FirstOrDefault(d => d.Id == result.GroupId)?.Name,
                   Mail = result.Mail
               });
           }
       }
    }

    private async Task<Recipient?> OpenDialog()
    {
        var options = new DialogOptions 
        {
            CloseOnEscapeKey = true,
            MaxWidth = MaxWidth.Large,
            Position = DialogPosition.Center,
        };
        
        var parameters = new DialogParameters<RecipientDialog>();

        var dialog = new RecipientDialog()
        {
            Department = new Select<Department>("Select Department", "DepartmentId", this.Departments),
            Group = new Select<RecipientGroup>("Select Group", "GroupId", this.RecipientsGroups)
        };
         
        parameters.Add("ObjectType", dialog);
         
        var result = await(await DialogService.ShowAsync<DialogComponent<RecipientDialog>>("Add Recipient", parameters, options)).Result;
        if (!result.Canceled)
        {
            return new Recipient()
            {
                DepartmentId = dialog.Department.SelectedValue,
                GroupId = dialog.Group.SelectedValue,
                Mail = dialog.Mail,
                Description = dialog.Description,
                Name = dialog.Name
            };
        }

        return default;
    }
}