﻿using FrontEnd.Helpers;
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


    private List<RecipientDto>? RecipientDto { get; set; }
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
           if (this.RecipientBl is { Count: > 0 })
           {
               this.RecipientDto = new();
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
    
    
    private async Task AddRecipient()
    {
       var recipient = await OpenDialog();
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