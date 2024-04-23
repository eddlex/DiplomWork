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

public partial class Schedule
{
    [Inject]
    private IRecipientService? RecipientService { get; set; }




    [Inject]
    private IDepartmentService? DepartmentService { get; set; }
    [Inject]
    private IBaseService? FormService { get; set; }
    [Inject]
    private ISubjectService? SubjectService { get; set; }
    [Inject]
    private IMailService? MailService { get; set; }


    private List<FormDto?>? FormDto { get; set; }
    private List<FormBl?>? FormBl { get; set; }
    private List<DepartmentBl>? Departments { get; set; }
    private List<RecipientGroup>? RecipientsGroups { get; set; }

    public List<SubjectBl>? SubjectsBl { get; set; }
    public List<SubjectDto>? SubjectsDto { get; set; } = new();

    #region FormRow
    private List<FormRowBl>? FormRowBl { get; set; }


    private async Task GetFormRows(int? id = null)
    {
        if (this.FormService != null &&
            this.SubjectService != null)
        {
            id ??= this.FormBl?.OrderBy(r => r?.Id).First()?.Id;
            _currentSelectedFormId = id.Value;
            var departmentId = this.FormBl?.First(r => r.Id == id).DepartmentId;
            this.SubjectsBl = await this.SubjectService.GetSubjects(departmentId.Value);
            this.FormRowBl = await this.FormService.Get<FormRowBl>(id, "Row") ?? new();
            selectedSubjects?.Clear();
            var tmpCount = default(int);
            foreach (var item in this.FormRowBl)
            {
                var subject = this.SubjectsBl?.FirstOrDefault(r => r.Id == item.SubjectId);
                if (subject != null)
                {
                    this.selectedSubjects?.Add(new()
                    {
                        Id = item.Id,
                        Title = subject.Title,
                        Order = tmpCount++,
                        Outcome = subject.Outcome
                    });
                }
            }

            if (SubjectsBl != null)
            {
                this.SubjectsDto?.Clear();
                foreach (var item in this.SubjectsBl)
                {
                    if (!this.FormRowBl.Select(r => r.SubjectId).Contains(item.Id))
                    {
                        this.SubjectsDto?.Add(new()
                        {
                            Id = item.Id,
                            Title = item.Title,
                            Outcome = item.Outcome
                        });
                    }
                }
            }
            else
            {
                Alert.Create(Helpers.Constants.Error.SubjectNotExist);
            }
        }
    }

    private async Task AddFormRow(FormRowBl row)
    {
        if (this.FormService != null)
        {
            row = await this.FormService.Add<FormRowBl, FormRowBl>(row, "Row");
        }
    }

    private async Task DeleteFormRow(FormRowBl item)
    {
        if (this.RecipientService != null && await DialogService.DeleteConfirmationPopUp())
        {
            var result = await this.FormService?.Delete<int, FormRowBl>(item, "Row");


            this.FormRowBl?.Remove(FormRowBl?.Find(f => f.Id == result));
            FormRowBl?.Remove(item);
        }
    }

    #endregion

    protected override async Task OnInitializedAsync()
    {

        if (this.FormService != null &&
            this.DepartmentService != null &&
            this.RecipientService != null &&
            this.SubjectService != null)
        {
            this.FormBl = await this.FormService.Get<FormBl?>();
            this.RecipientsGroups = await this.RecipientService.GetRecipientsGroups();
            this.Departments = await this.DepartmentService.GetDepartments();
            this.FormDto = new();

            if (this.FormBl is { Count: > 0 })
            {
                await GetFormRows();
                this.FormBl?.ForEach(e => this.FormDto.Add(new()
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
        if (this.FormService != null)
        {
            var editedRowBl = this.FormBl?.Find(r => r.Id == id);
            var editedRowDto = this.FormDto?.Find(r => r?.Id == id);



            var recipient = await OpenDialog<FormDialog>(editedRowBl);
            if (recipient != default && editedRowBl is not null)
            {
                var result = await this.FormService.Edit<FormBl, FormBl>(recipient);

                this.FormDto?.Remove(editedRowDto);
                this.FormBl?.Remove(editedRowBl);
                this.FormBl?.Add(result);
                this.FormDto?.Add(new FormDto()
                {
                    Id = result.Id,
                    Name = result.Name,
                    Description = result.Description,
                    Department = this.Departments?.FirstOrDefault(d => d.Id == result.DepartmentId)?.Name,
                    Group = this.RecipientsGroups?.FirstOrDefault(d => d.Id == result.GroupId)?.Name,

                });
            }
        }
    }

    private async Task SendEmail(int id)
    {
        var result = await this.MailService?.SendMail(this.FormBl?.Find(f => f.Id == id));

        if (result)
            Snackbar.ShowSuccess(Constants.Success.FormSubmit);
        else
        {
            Snackbar.ShowExeption(Constants.Error.SomethingWrong);
        }
    }

    private async Task DeleteRow(int id)
    {
        if (this.RecipientService != null && await DialogService.DeleteConfirmationPopUp())
        {
            var result = await this.FormService?.Delete<int, FormBl>(FormBl?.Find(r => r.Id == id));

            FormDto?.Remove(FormDto?.FirstOrDefault(row => row?.Id == result));
            FormBl?.Remove(FormBl?.FirstOrDefault(row => row?.Id == result));
        }
    }

    private async Task AddRow()
    {
        var smtpBl = await OpenDialog<FormDialog>();
        if (smtpBl != default && this.FormService != null)
        {
            var result = await this.FormService.Add<FormBl, FormBl>(smtpBl);

            this.FormBl?.Add(result);
            this.FormDto?.Add(new()
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
            Department = new Select<DepartmentBl>("Select Department", "DepartmentId", this.Departments),
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