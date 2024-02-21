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
    private ISmtpService? SmtpService { get; set; }

    [Inject]
    private IDepartmentService? DepartmentService { get; set; }

    private List<SMTPConfigDto?>? SmtpConfigDto { get; set; }
    private List<SmtpConfigBl>? SmtpConfigBl { get; set; }
    private List<Department>? Departments { get; set; }

    protected override async Task OnInitializedAsync()
    {
        if (this.SmtpService != null &&
            this.DepartmentService != null)
        {
            this.SmtpConfigBl = await this.SmtpService.GetSmtpConfigurations();
            this.Departments = await this.DepartmentService.GetDepartments();
            this.SmtpConfigDto = new();
            if (this.SmtpConfigBl is { Count: > 0 })
            {
            
                this.SmtpConfigBl.ForEach(e => this.SmtpConfigDto.Add(new SMTPConfigDto()
                {
                    Id = e.Id,
                    Department = this.Departments?.FirstOrDefault(d => d.Id == e.DepartmentId)?.Name,
                    SmtpServer = e.SmtpServer,
                    Port = e.Port,
                    UserName = e.UserName,
                    Password = e.Password,
                    EnableSSL = e.EnableSSL
                }));
            }
        }
    }

    private async Task EditRow(int id)
    {
        //if (this.RecipientService != null)
        //{
        //    var editedRowBl = this.RecipientBl?.Find(r => r.Id == id);
        //    var editedRowDto = this.RecipientDto?.Find(r => r?.Id == id);



        //    var recipient = await OpenDialog(editedRowBl);
        //    if (recipient != default && editedRowBl is not null)
        //    {
        //        var result = await this.RecipientService.EditRecipient(recipient);
        //        if (result != null)
        //        {
        //            this.RecipientDto?.Remove(editedRowDto);
        //            this.RecipientBl?.Remove(editedRowBl);
        //            this.RecipientBl?.Add(result);

        //            this.RecipientDto?.Add(new RecipientDto()
        //            {
        //                Id = result.Id,
        //                Name = result.Name,
        //                Description = result.Description,
        //                Department = this.Departments?.FirstOrDefault(d => d.Id == result.DepartmentId)?.Name,
        //                Group = this.RecipientsGroups?.FirstOrDefault(d => d.Id == result.GroupId)?.Name,
        //                Mail = result.Mail
        //            });
        //        }
        //    }
        //}
    }


    private async Task DeleteRow(int id)
    {
        if (this.SmtpService != null && await DialogService.DeleteConfirmationPopUp())
        {
            var result = await this.SmtpService.DeleteSmtpConfiguration(SmtpConfigBl?.Find(r => r.Id == id));
            
            SmtpConfigBl?.Remove(SmtpConfigBl?.FirstOrDefault(row => row.Id == result));
            
        }
    }


    
    private async Task AddRow()
    {
        var recipient = await OpenDialog();
        //if (recipient != default && this.RecipientService != null)
        //{
        //    var result = await this.RecipientService.AddRecipient(recipient);
        //    if (result != null)
        //    {
        //        this.RecipientDto?.Add(new RecipientDto()
        //        {
        //            Id = result.Id,
        //            Name = result.Name,
        //            Description = result.Description,
        //            Department = this.Departments?.FirstOrDefault(d => d.Id == result.DepartmentId)?.Name,
        //            Group = this.RecipientsGroups?.FirstOrDefault(d => d.Id == result.GroupId)?.Name,
        //            Mail = result.Mail
        //        });
        //    }
        //}
    }

    private async Task<SmtpConfigBl?> OpenDialog(SmtpConfigBl? row = default)
    {
        return new();
        //var options = new DialogOptions
        //{
        //    CloseOnEscapeKey = true,
        //    MaxWidth = MaxWidth.Large,
        //    Position = DialogPosition.Center,
        //};

        //var parameters = new DialogParameters<RecipientDialog>();



        //var dialog = new RecipientDialog()
        //{
        //    Department = new Select<Department>("Select Department", "DepartmentId", this.Departments),
        //    Group = new Select<RecipientGroup>("Select Group", "GroupId", this.RecipientsGroups)
        //};

        //if (row is not null)
        //{
        //    dialog.Name = row.Name;
        //    dialog.Mail = row.Mail;
        //    dialog.Description = row.Description;
        //    dialog.Department.SelectedValue = row.DepartmentId;
        //    dialog.Group.SelectedValue = row.GroupId;
        //}

        //parameters.Add("ObjectType", dialog);

        //var result = await (await DialogService.ShowAsync<DialogComponent<RecipientDialog>>("Add Recipient", parameters, options)).Result;
        //if (!result.Canceled)
        //{
        //    return new Recipient()
        //    {
        //        DepartmentId = dialog.Department.SelectedValue.Value,
        //        GroupId = dialog.Group.SelectedValue.Value,
        //        Mail = dialog.Mail,
        //        Description = dialog.Description,
        //        Name = dialog.Name
        //    };
        //}

        //return default;
    }
}