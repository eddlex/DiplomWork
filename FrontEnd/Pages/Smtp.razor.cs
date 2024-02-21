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

public partial class Smtp
{
    [Inject]
    private IDepartmentService? DepartmentService { get; set; } 


    private List<RecipientDto?>? SmtpDto { get; set; }
    private List<Recipient>? SmtpBl { get; set; }
    private List<Department>? Departments { get; set; }
   
    
    protected override async Task OnInitializedAsync()
    {
        if (this.DepartmentService != null)
        {

           this.Departments = await this.DepartmentService.GetDepartments();
           this.SmtpDto = new();
           
           if (this.SmtpBl is { Count: > 0 })
           {
               
               this.SmtpBl.ForEach(e => this.SmtpDto.Add(new RecipientDto()
               {
                   Id = e.Id,
                   Name = e.Name,
                   Description = e.Description,
                   Department = this.Departments?.FirstOrDefault(d => d.Id == e.DepartmentId)?.Name,
       
                   Mail = e.Mail
               }));
           }
           
           
           
        } 
    }

    private async Task EditSmtp(int id)
    {
        

    }
    
    
    private async Task DeleteSmtp(int id)
    {
        
    }
    
    
    private async Task<bool> ConfirmDelete()
    {
        var parameters = new DialogParameters<DeleteDialog>();
        parameters.Add(x => x.ContentText, "Do you really want to delete this row? This process cannot be undone.");
        parameters.Add(x => x.ButtonText, "Delete");
        parameters.Add(x => x.Color, Color.Error);

        var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.ExtraSmall };

        return !(await(await DialogService.ShowAsync<DeleteDialog>("Delete", parameters, options)).Result).Canceled;
        
    }
    private async Task AddSmtp()
    {
       // var recipient = await OpenDialog();
       // if (recipient != default && this.RecipientService != null)
       // {
       //     var result = await this.RecipientService.AddRecipient(recipient);
       //     if (result != null)
       //     {
       //         this.RecipientDto?.Add(new RecipientDto()
       //         {
       //             Id = result.Id,
       //             Name = result.Name,
       //             Description = result.Description,
       //             Department = this.Departments?.FirstOrDefault(d => d.Id == result.DepartmentId)?.Name,
       //             Group = this.RecipientsGroups?.FirstOrDefault(d => d.Id == result.GroupId)?.Name,
       //             Mail = result.Mail
       //         });
       //     }
       // }
    }

    private async Task<Recipient?> OpenDialog(Recipient? row = default)
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
        };

        if (row is not null)
        {
            dialog.Name = row.Name;
            dialog.Mail = row.Mail;
            dialog.Description = row.Description;
            dialog.Department.SelectedValue = row.DepartmentId;
            dialog.Group.SelectedValue = row.GroupId;
        }
         
        parameters.Add("ObjectType", dialog);
         
        var result = await(await DialogService.ShowAsync<DialogComponent<RecipientDialog>>("Add Recipient", parameters, options)).Result;
        if (!result.Canceled)
        {
            return new Recipient()
            {
                DepartmentId = dialog.Department.SelectedValue.Value,
                GroupId = dialog.Group.SelectedValue.Value,
                Mail = dialog.Mail,
                Description = dialog.Description,
                Name = dialog.Name
            };
        }

        return default;
    }
}