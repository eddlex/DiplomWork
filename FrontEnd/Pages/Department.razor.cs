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

public partial class Department
{
    
    [Inject]
    private IDepartmentService? DepartmentService { get; set; }

    
    private List<DepartmentBl>? Departments { get; set; }

    protected override async Task OnInitializedAsync()
    {
        if (this.DepartmentService != null )
        {
            this.Departments = await this.DepartmentService.GetDepartments();
            if (this.Departments is { Count:  0 })
            {
                throw Alert.Create(Constants.Error.NotExistAnyDepartment);
            }
        } 
    }
    
    private async Task DeleteDepartment(int id)
    {
        if (this.DepartmentService != null && await DialogService.DeleteConfirmationPopUp())
        {
            var result = await this.DepartmentService.DeleteDepartment(id);
            if (result && this.Departments is { Count: > 0 })
            {
                this.Departments.Remove(this.Departments.First(r => r.Id == id));
            }
        }
    }
    
    
  
    private async Task AddDepartment()
    {
       var dialog = await OpenDialog();
       if (dialog != default && this.DepartmentService != null)
       {
           var result = await this.DepartmentService.AddDepartment(dialog);
           if (result != null)
           {
               this.Departments?.Add(result);
           }
       }
    }
    
    
    private async Task EditDepartment(DepartmentBl model)
    {
        var dialog = await OpenDialog(model);
        if (dialog != default && this.DepartmentService != null)
        {
            var result = await this.DepartmentService.EditDepartment(dialog);
            if (result != null)
            {
                model.Description = result.Description;
                model.Name = result.Name;
            }
        }
    }

    private async Task<DepartmentBl?> OpenDialog(DepartmentBl? row = default)
    {
        var options = new DialogOptions 
        {
            CloseOnEscapeKey = true,
            MaxWidth = MaxWidth.Large,
            Position = DialogPosition.Center,
        };
        
        var parameters = new DialogParameters<DepartmentDialog>();
        
        var dialog = new DepartmentDialog();

        if (row is not null)
        {
            dialog.Name = row.Name;
            dialog.Description = row.Description;
        }

        parameters.Add("ObjectType", dialog);
         
        var result = await(await DialogService.ShowAsync<DialogComponent<DepartmentDialog>>("Add Department", parameters, options)).Result;
        if (!result.Canceled && dialog is { Description: not null, Name: not null })
        {
            return new DepartmentBl(row?.Id ?? 0, dialog.Description, dialog.Name);
        }

        return default;
    }
}