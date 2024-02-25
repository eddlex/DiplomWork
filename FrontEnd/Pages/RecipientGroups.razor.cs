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

public partial class RecipientGroups
{
    [Inject]
    private IRecipientService? RecipientService { get; set; } 
    
    [Inject]
    private IDepartmentService? DepartmentService { get; set; } 

    private List<RecipientGroupDto?>? RecipientGroupDto { get; set; }
    private List<RecipientGroup>? RecipientGroupBl { get; set; }
    private List<Department>? Departments { get; set; }
    //private List<RecipientGroup>? RecipientsGroups { get; set; }
    
    
    protected override async Task OnInitializedAsync()
    {
        if (this.RecipientService != null && 
            this.DepartmentService != null)
        {
           this.RecipientGroupBl = await this.RecipientService.GetRecipientsGroups();
           //this.RecipientGroupDto = await this.RecipientService.GetRecipientsGroups();
           this.Departments = await this.DepartmentService.GetDepartments();
           this.RecipientGroupDto = new();
           if (this.RecipientGroupBl is { Count: > 0 })
           {
               
               this.RecipientGroupBl.ForEach(e => this.RecipientGroupDto.Add(new RecipientGroupDto()
               {
                   Id = e.Id,
                   Name = e.Name,
                   Description = e.Description,
                   Department = this.Departments?.FirstOrDefault(d => d.Id == e.DepartmentId)?.Name              
               }));
           }                  
        } 
    }

    private async Task EditRecipientGroup(int id)
    {
    //    if (this.RecipientService != null)
    //    {
    //        var editedRowBl = this.RecipientGroupBl?.Find(r => r.Id == id);
    //        var editedRowDto = this.RecipientGroupDto?.Find(r => r?.Id == id);
        
            
            
    //        var recipient = await OpenDialog(editedRowBl);
    //        if (recipient != default && editedRowBl is not null )
    //        {
    //            var result = await this.RecipientService.EditRecipient(recipient);
    //            if (result != null)
    //            {
    //                this.RecipientGroupDto?.Remove(editedRowDto);
    //                this.RecipientGroupBl?.Remove(editedRowBl);
    //                this.RecipientGroupBl?.Add(result);
                    
    //                this.RecipientGroupDto?.Add(new RecipientGroupDto()
    //                {
    //                    Id = result.Id,
    //                    Name = result.Name,
    //                    Description = result.Description,
    //                    Department = this.Departments?.FirstOrDefault(d => d.Id == result.DepartmentId)?.Name
    //                });
    //            }
    //        }
    //    }
    }
    
    
    private async Task DeleteRecipientGroup(int id)
    {
    //    if (this.RecipientService != null && await DialogService.DeleteConfirmationPopUp())
    //    {
    //        var result = await this.RecipientService.DelRecipient(RecipientGroupBl.Find(r => r.Id == id));
    //        if (result.HasValue)
    //        {
    //            RecipientGroupDto?.Remove(RecipientGroupDto.FirstOrDefault(row => row?.Id == result.Value));
    //        }
    //    }
    }
    
  
    private async Task AddRow()
    {
        var recipient = await OpenDialog();
        if (recipient != default && this.RecipientService != null)
        {
            var result = await this.RecipientService.AddRecipientGroup(recipient);
            if (result != null)
            {
                this.RecipientGroupDto?.Add(new RecipientGroupDto()
                {
                    Id = result.Id,
                    Name = result.Name,
                    Description = result.Description,
                    Department = this.Departments?.FirstOrDefault(d => d.Id == result.DepartmentId)?.Name
                });
            }
        }
    }

    private async Task<RecipientGroup?> OpenDialog(RecipientGroup? row = default)
    {
        var options = new DialogOptions 
        {
            CloseOnEscapeKey = true,
            MaxWidth = MaxWidth.Large,
            Position = DialogPosition.Center,
        };
        
        var parameters = new DialogParameters<RecipientDialog>();
        
        var dialog = new RecipientGroupDialog()
        {
            Department = new Select<Department>("Select Department", "DepartmentId", this.Departments),
        };

        if (row is not null)
        {
            dialog.Name = row.Name;
            dialog.Description = row.Description;
            dialog.Department.SelectedValue = row.DepartmentId;
        }
         
        parameters.Add("ObjectType", dialog);
         
        var result = await(await DialogService.ShowAsync<DialogComponent<RecipientGroupDialog>>("Add RecipientGroup", parameters, options)).Result;
        if (!result.Canceled && dialog.Department.SelectedValue != null)
        {
            return new RecipientGroup()
            {
                DepartmentId = dialog.Department.SelectedValue.Value,
                Description = dialog.Description,
                Name = dialog.Name,
                Id = row?.Id ?? 0
            };
        }

        return default;
    }
}