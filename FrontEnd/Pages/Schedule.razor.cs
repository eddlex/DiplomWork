using System.Text.RegularExpressions;
using BackEnd.Models.Input;
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
    private ISubjectService? SubjectService { get; set; }


    private List<ScheduleDto?>? ScheduleDto { get; set; }
    private List<ScheduleBl>? ScheduleBl { get; set; }
    private List<DepartmentBl>? Departments { get; set; }


    public List<SubjectBl>? SubjectsBl { get; set; }
    public List<SubjectDto>? SubjectsDto { get; set; } = new();

    
    
    #region ScheduleRow
    private List<ScheduleRowBl>? ScheduleRowBl { get; set; }


    private async Task GetScheduleRows(int? id = null)
    {
        if (this.SubjectService != null)
        {
            id ??= this.ScheduleBl?.OrderBy(r => r?.Id).First()?.Id;
            _currentSelectedScheduleId = id.Value;
            var departmentId = this.ScheduleBl?.First(r => r.Id == id).DepartmentId;
            
            this.SubjectsBl = await this.SubjectService.GetSubjects(departmentId.Value);
            
            this.ScheduleRowBl = (await this.SubjectService.GetSubjectsScheduleRow(id.Value)) ?? new();
            
            selectedRows?.Clear();
            var tmpCount = default(int);
            foreach (var item in this.ScheduleRowBl)
            {
                var subject = this.SubjectsBl?.FirstOrDefault(r => r.Id == item.SubjectId);
                if (subject != null)
                {
                    this.selectedRows?.Add(new()
                    {
                        Id = item.SubjectId,
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
                    if (!this.ScheduleRowBl.Select(r => r.SubjectId).Contains(item.Id))
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

    private async Task EvaluateModel()
    {
        var result = await this.SubjectService?.EvaluateModel();

        if (result)
            Snackbar.ShowSuccess(Constants.Success.ModelEval);
        else
        {
            Snackbar.ShowExeption(Constants.Error.SomethingWrong);
        }
    }
    private async Task TrainModel()
    {
        var result = await this.SubjectService?.TrainModel();

        if (result)
            Snackbar.ShowSuccess(Constants.Success.ModelTrain);
        else
        {
            Snackbar.ShowExeption(Constants.Error.SomethingWrong);
        }
    }
    private async Task ScheduleModel(int id)
    {
        if (this.selectedRows.Exists(r => ScheduleRowBl.Any(l=>l.SubjectId == r.Id && l.CalculatedHours ==-1)))
        {
            var result = await this.SubjectService?.ScheduleModel(id);

            if (result is not null && result.Count > 0)
            {
                Snackbar.ShowSuccess(Constants.Success.ModelTrain);
                foreach (var row in ScheduleRowBl)
                {
                    row.CalculatedHours = result.FirstOrDefault(r => r.SubjectId == row.SubjectId).CalculatedHours;
                }
            }
            else
            {
                Snackbar.ShowExeption(Constants.Error.SomethingWrong);
            }
        }
        
        
        var options = new DialogOptions
        {
            CloseOnEscapeKey = true,
            MaxWidth = MaxWidth.Large,
            Position = DialogPosition.Center,
        };

        var parameters = new DialogParameters();
        
        parameters.Add("Schedule", ScheduleRowBl);
        parameters.Add("Subject", selectedRows);
        
        var s = await (await DialogService.ShowAsync<ScheduleRowsDialog>("Արդյունք", parameters, options)).Result;
        

    }


    private async Task AddScheduleRow(ScheduleRowBl row)
    {
        if (this.SubjectService != null)
        {
            row = await this.SubjectService.AddSubjectsScheduleRow(row);
        }
    }

    private async Task DeleteScheduleRow(ScheduleRowBl item)
    {
        if (this.SubjectService != null && await DialogService.DeleteConfirmationPopUp())
        {
            var result = await this.SubjectService.DelSubjectsScheduleRow(item);

            if (result.HasValue && result.Value)
            {
                ScheduleRowBl?.Remove(item);
            }

        }
    }

    #endregion

    protected override async Task OnInitializedAsync()
    {
        if (
            this.DepartmentService != null &&
            this.SubjectService != null)
        {
            //this.FormBl = await this.FormService.Get<FormBl?>();
          //  this.RecipientsGroups = await this.RecipientService.GetRecipientsGroups();
          
            this.Departments = await this.DepartmentService.GetDepartments();
            this.ScheduleDto = new();
            this.ScheduleBl = await this.SubjectService.GetSubjectsSchedulesCalculations();

            if (this.ScheduleBl is { Count: > 0 })
            {
                await GetScheduleRows();
                this.ScheduleBl?.ForEach(e => this.ScheduleDto.Add(new()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Hours = e.Hours,
                    Semester = e.Semester,
                    Department = this.Departments?.FirstOrDefault(d => d.Id == e.DepartmentId)?.Name,
                }));
            }
        }
    }

    private async Task EditRow(int id)
    {
        if (this.SubjectService != null)
        {
            var editedRowBl = this.ScheduleBl?.Find(r => r.Id == id);
            var editedRowDto = this.ScheduleDto?.Find(r => r?.Id == id);

            var recipient = await OpenDialog<ScheduleDialog>(editedRowBl);
            if (recipient != default && editedRowBl is not null)
            {
                var result = await this.SubjectService.EditSubjectScheduleCalculation(recipient);

                this.ScheduleDto?.Remove(editedRowDto);
                this.ScheduleBl?.Remove(editedRowBl);
                this.ScheduleBl?.Add(result);
                this.ScheduleDto?.Add(new ScheduleDto()
                {
                    Id = result.Id,
                    Name = result.Name,
                    Hours = result.Hours,
                    Semester = result.Semester,
                    Department = this.Departments?.FirstOrDefault(d => d.Id == result.DepartmentId)?.Name,
                });
            }
        }
    }

    private async Task DeleteRow(int id)
    {
        if (this.RecipientService != null && await DialogService.DeleteConfirmationPopUp())
        {
            var result = await this.SubjectService?.DeleteSubjectScheduleCalculation(ScheduleBl?.Find(r => r.Id == id));

            if (result.HasValue && result.Value)
            {
                ScheduleDto?.Remove(ScheduleDto?.FirstOrDefault(row => row?.Id == id));
                ScheduleBl?.Remove(ScheduleBl?.FirstOrDefault(row => row?.Id == id));
            }

        }
    }

    private async Task AddRow()
    {
        var smtpBl = await OpenDialog<ScheduleDialog>();
        if (smtpBl != default && this.SubjectService != null)
        {
            var result = await this.SubjectService.AddSubjectScheduleCalculation(smtpBl);

            this.ScheduleBl?.Add(result);
            this.ScheduleDto?.Add(new()
            {
                Id = result.Id,
                Department = this.Departments?.FirstOrDefault(d => d.Id == result.DepartmentId)?.Name,
                Name = result.Name,
                Hours = result.Hours,
                Semester = result.Semester,
            });

        }
    }

    private async Task<ScheduleBl?> OpenDialog<T>(ScheduleBl? row = default)
    {
        var options = new DialogOptions
        {
            CloseOnEscapeKey = true,
            MaxWidth = MaxWidth.Large,
            Position = DialogPosition.Center,
        };

        var parameters = new DialogParameters<T>();

        var dialog = new ScheduleDialog()
        {
            Department = new Select<DepartmentBl>("Select Department", "DepartmentId", this.Departments), 
        };

        if (row is not null)
        {
            dialog.Department.SelectedValue = row.DepartmentId;
          
            dialog.Hours = row.Hours;
            dialog.Name = row.Name;
            dialog.Semester = row.Semester;
        }

        parameters.Add("ObjectType", dialog);

        var result = await (await DialogService.ShowAsync<DialogComponent<T>>("Add Form", parameters, options)).Result;
        if (!result.Canceled &&
            dialog.Department.SelectedValue is not null)
        {
            return new()
            {
                DepartmentId = dialog.Department.SelectedValue.Value,
                Semester = dialog.Semester,
                Hours = dialog.Hours,
                Name = dialog.Name,
                Id = row?.Id ?? 0
            };
        }

        return default;
    }
}