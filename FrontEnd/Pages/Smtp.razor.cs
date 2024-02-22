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
    private List<SmtpConfigBl?>? SmtpConfigBl { get; set; }
    private List<Department>? Departments { get; set; }

    protected override async Task OnInitializedAsync()
    {
        if (this.SmtpService != null &&
            this.DepartmentService != null)
        {
            this.SmtpConfigBl = await this.SmtpService.GetSmtpConfigurations<SmtpConfigBl>();
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
            var result = await this.SmtpService.DeleteSmtpConfiguration<int, SmtpConfigBl?>(SmtpConfigBl?.Find(r => r.Id == id));
            SmtpConfigBl?.Remove(SmtpConfigBl?.FirstOrDefault(row => row?.Id == result));
            SmtpConfigDto?.Remove(SmtpConfigDto?.FirstOrDefault(row => row?.Id == result));
        }
    }


    
    private async Task AddRow()
    {
        var smtpBl = await OpenDialog<SmtpDialog>();
        if (smtpBl != default && this.SmtpService != null)
        {
            var result = await this.SmtpService.AddSmtpConfiguration<SmtpConfigBl, SmtpConfigBl>(smtpBl);
            
            this.SmtpConfigBl?.Add(result);
            this.SmtpConfigDto?.Add(new SMTPConfigDto()
            {
                Id = result.Id,
                Department = this.Departments?.FirstOrDefault(d => d.Id == result.DepartmentId)?.Name,
                SmtpServer = result.SmtpServer,
                Port = result.Port,
                UserName = result.UserName,
                Password = result.Password,
                EnableSSL = result.EnableSSL 
            });
            
        }
    }

    private async Task<SmtpConfigBl?> OpenDialog<T>(SmtpConfigBl? row = default)
    {
        var options = new DialogOptions
        {
            CloseOnEscapeKey = true,
            MaxWidth = MaxWidth.Large,
            Position = DialogPosition.Center,
        };

        var parameters = new DialogParameters<T>();
        
        var dialog = new SmtpDialog()
        {
            Department = new Select<Department?>("Select Department", "DepartmentId", this.Departments)
        };

        if (row is not null)
        {
            dialog.Department.SelectedValue = row.DepartmentId;
            dialog.EnableSSL = row.EnableSSL;
            dialog.Password = row.Password;
            dialog.UserName = row.UserName;
            dialog.Port = row.Port;
            dialog.SmtpServer = row.SmtpServer;
        }

        parameters.Add("ObjectType", dialog);

        var result = await (await DialogService.ShowAsync<DialogComponent<T>>("Add Smtp Configuration", parameters, options)).Result;
        if (!result.Canceled && dialog.Department.SelectedValue is not null)
        {
            return new SmtpConfigBl()
            {
                DepartmentId = dialog.Department.SelectedValue.Value,
                EnableSSL = dialog.EnableSSL,
                Password = dialog.Password,
                UserName = dialog.UserName,
                Port = dialog.Port,
                SmtpServer = dialog.SmtpServer
            };
        }

        return default;
    }
}