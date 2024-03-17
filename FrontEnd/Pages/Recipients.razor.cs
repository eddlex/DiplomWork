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

    [Inject]
    private IWeightService? WeightService { get; set; }


    private List<RecipientDto?>? RecipientDto { get; set; }
    private List<Recipient>? RecipientBl { get; set; }
    private List<Department>? Departments { get; set; }
    private List<RecipientGroup>? RecipientsGroups { get; set; }
    private List<Weight>? Weights { get; set; }


    protected override async Task OnInitializedAsync()
    {
        if (this.RecipientService != null && 
            this.DepartmentService != null &&
            this.WeightService != null)
        {
           this.RecipientBl = await this.RecipientService.GetRecipient();
           this.RecipientsGroups = await this.RecipientService.GetRecipientsGroups();
           this.Departments = await this.DepartmentService.GetDepartments();
           this.Weights = await this.WeightService.GetWeights();

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
                   Weight = this.Weights?.FirstOrDefault(d => d.Id == e.WeightId)?.Name,
                   Mail = e.Mail
               }));
           }                
        } 
    }

    private async Task EditRecipient(int id)
    {
        if (this.RecipientService != null)
        {
            var editedRowBl = this.RecipientBl?.Find(r => r.Id == id);
            var editedRowDto = this.RecipientDto?.Find(r => r?.Id == id);        
            
            
            var recipient = await OpenDialog(editedRowBl);
            if (recipient != default && editedRowBl is not null )
            {
                var result = await this.RecipientService.EditRecipient(recipient);
                if (result != null)
                {
                    this.RecipientDto?.Remove(editedRowDto);
                    this.RecipientBl?.Remove(editedRowBl);
                    this.RecipientBl?.Add(result);
                    
                    this.RecipientDto?.Add(new RecipientDto()
                    {
                        Id = result.Id,
                        Name = result.Name,
                        Description = result.Description,
                        Department = this.Departments?.FirstOrDefault(d => d.Id == result.DepartmentId)?.Name,
                        Group = this.RecipientsGroups?.FirstOrDefault(d => d.Id == result.GroupId)?.Name,
                        Weight = this.Weights?.FirstOrDefault(d => d.Id == result.WeightId)?.Name,
                        Mail = result.Mail
                    });
                }
            }
        }
    }
    
    
    private async Task DeleteRecipient(int id)
    {
        if (this.RecipientService != null && await DialogService.DeleteConfirmationPopUp())
        {
            var result = await this.RecipientService.DelRecipient(RecipientBl.Find(r => r.Id == id));
            if (result.HasValue)
            {
                RecipientDto?.Remove(RecipientDto.FirstOrDefault(row => row?.Id == result.Value));
            }
        }
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
                   Weight = this.Weights?.FirstOrDefault(d => d.Id == result.WeightId)?.Name,
                   Mail = result.Mail
               });
           }
       }
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
            Group = new Select<RecipientGroup>("Select Group", "GroupId", this.RecipientsGroups),
            Weight = new Select<Weight>("Select Weight", "WeightId", this.Weights)
        };

        if (row is not null)
        {
            dialog.Name = row.Name;
            dialog.Mail = row.Mail;
            dialog.Description = row.Description;
            dialog.Department.SelectedValue = row.DepartmentId;
            dialog.Group.SelectedValue = row.GroupId;
            dialog.Weight.SelectedValue = row.WeightId;
        }

        parameters.Add("ObjectType", dialog);
         
        var result = await(await DialogService.ShowAsync<DialogComponent<RecipientDialog>>("Add Recipient", parameters, options)).Result;
        if (!result.Canceled && dialog.Department.SelectedValue != null && dialog.Group.SelectedValue != null && dialog.Weight.SelectedValue != null)
        {
            return new Recipient()
            {
                DepartmentId = dialog.Department.SelectedValue.Value,
                GroupId = dialog.Group.SelectedValue.Value,
                WeightId = dialog.Weight.SelectedValue.Value,
                Mail = dialog.Mail,
                Description = dialog.Description,
                Name = dialog.Name,
                Id = row?.Id ?? 0
            };
        }

        return default;
    }
}