using System.Text.RegularExpressions;
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

public partial class Form
{
    [Inject]
    private IRecipientService? RecipientService { get; set; } 
    
    [Inject]
    private IDepartmentService? DepartmentService { get; set; } 
    [Inject]
    private IBaseService? FormService { get; set; }


    private List<FormDto?>? FormDto { get; set; }
    private List<FormBl>? FormBl { get; set; }
    
    
    
    private List<Department>? Departments { get; set; }
    private List<RecipientGroup>? RecipientsGroups { get; set; }
    
    

    protected override async Task OnInitializedAsync()
    {
        if (this.FormService != null && 
            this.DepartmentService != null &&
            this.RecipientService != null)
        {
           this.FormBl = await this.FormService.Get<FormBl>();
           this.RecipientsGroups = await this.RecipientService.GetRecipientsGroups();
           this.Departments = await this.DepartmentService.GetDepartments();
           this.FormDto = new();
           if (this.FormBl is { Count: > 0 })
           {
               this.FormBl.ForEach(e => this.FormDto.Add(new()
               {
                   Id = e.Id,
                   Name = e.Name,
                   Description = e.Description,
                   Department = this.Departments?.FirstOrDefault(d => d.Id == e.DepartmentId)?.Name,
                   Group = this.RecipientsGroups?.FirstOrDefault(d => d.Id == e.GroupId)?.Name
               }));
           }
           
           
           
        } 
    }

    private async Task EditRow(int id)
    {
        // if (this.RecipientService != null)
        // {
        //     var editedRowBl = this.RecipientBl?.Find(r => r.Id == id);
        //     var editedRowDto = this.RecipientDto?.Find(r => r?.Id == id);
        //
        //     
        //     
        //     var recipient = await OpenDialog(editedRowBl);
        //     if (recipient != default && editedRowBl is not null )
        //     {
        //         var result = await this.RecipientService.EditRecipient(recipient);
        //         if (result != null)
        //         {
        //             this.RecipientDto?.Remove(editedRowDto);
        //             this.RecipientBl?.Remove(editedRowBl);
        //             this.RecipientBl?.Add(result);
        //             
        //             this.RecipientDto?.Add(new RecipientDto()
        //             {
        //                 Id = result.Id,
        //                 Name = result.Name,
        //                 Description = result.Description,
        //                 Department = this.Departments?.FirstOrDefault(d => d.Id == result.DepartmentId)?.Name,
        //                 Group = this.RecipientsGroups?.FirstOrDefault(d => d.Id == result.GroupId)?.Name,
        //                 Mail = result.Mail
        //             });
        //         }
        //     }
        // }
    }
    
    
    private async Task DeleteRow(int id)
    {
        // if (this.RecipientService != null && await DialogService.DeleteConfirmationPopUp())
        // {
        //     var result = await this.RecipientService.DelRecipient(RecipientBl.Find(r => r.Id == id));
        //     if (result.HasValue)
        //     {
        //         RecipientDto?.Remove(RecipientDto.FirstOrDefault(row => row?.Id == result.Value));
        //     }
        // }
    }
    
    
  
    private async Task AddRow()
    {
        var smtpBl = await OpenDialog<FormDialog>();
        if (smtpBl != default && this.FormService != null)
        {
            var result = await this.FormService.Add<FormBl, FormBl>(smtpBl);
            
            this.FormBl?.Add(result);
            this.FormDto?.Add(new ()
            {
                Id = result.Id,
                Department = this.Departments?.FirstOrDefault(d => d.Id == result.DepartmentId)?.Name,
                Group = this.RecipientsGroups?.FirstOrDefault(d => d.Id == result.GroupId)?.Name,
                Name = result.Name,
                Description = result.Description
            });
            
        }
    }

    private async Task<FormBl?> OpenDialog<T>(FormBl? row = default)
    {
        var options = new DialogOptions
        {
            CloseOnEscapeKey = true,
            MaxWidth = MaxWidth.Large,
            Position = DialogPosition.Center,
        };

        var parameters = new DialogParameters<T>();
        
        var dialog = new FormDialog()
        {
            Department = new Select<Department>("Select Department", "DepartmentId", this.Departments),
            Group = new Select<RecipientGroup>("Select Group", "GroupId", this.RecipientsGroups),
        };

        if (row is not null)
        {
            dialog.Department.SelectedValue = row.DepartmentId;
            dialog.Group.SelectedValue = row.GroupId;
            dialog.Description = row.Description;
            dialog.Name = row.Name;
        }

        parameters.Add("ObjectType", dialog);

        var result = await (await DialogService.ShowAsync<DialogComponent<T>>("Add Form", parameters, options)).Result;
        if (!result.Canceled &&
            dialog.Department.SelectedValue is not null &&
            dialog.Group.SelectedValue != null)
        { 
            return new() 
            {
                DepartmentId = dialog.Department.SelectedValue.Value,
                GroupId = dialog.Group.SelectedValue.Value,
                Name = dialog.Name,
                Description = dialog.Description,
                Id = row?.Id ?? 0
            };
        }

        return default;
    }
}