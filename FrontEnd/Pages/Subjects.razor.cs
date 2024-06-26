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

public partial class Subjects
{
    [Inject]
    private ISubjectService? SubjectService { get; set; } 
    
    [Inject]
    private IDepartmentService? DepartmentService { get; set; }

    // [Inject]
    // private IWeightService? WeightService { get; set; } OutcomeService


    private List<SubjectDtoForPage?>? SubjectDto { get; set; }
    private List<SubjectBl>? SubjectBl { get; set; }
    private List<DepartmentBl>? Departments { get; set; }

    private List<OutcomeType>? OutcomeTypes { get; set; } = new();


    protected override async Task OnInitializedAsync()
    {
        
        OutcomeTypes?.Add(new OutcomeType(0, "Գիտելիք"));
        OutcomeTypes?.Add(new OutcomeType(1, "Կարողություն"));
        OutcomeTypes?.Add(new OutcomeType(2, "Հմտություն"));


        if (this.DepartmentService != null &&
            this.SubjectService != null)
        {
           this.SubjectBl = await this.SubjectService.GetSubjects();
           this.Departments = await this.DepartmentService.GetDepartments();
          

           this.SubjectDto = new();
           if (this.SubjectBl is { Count: > 0 })
           {
               
               this.SubjectBl?.ForEach(e => this.SubjectDto.Add(new SubjectDtoForPage()
               {
                   Id = e.Id,
                   Title = e.Title,
                   Outcome = e.Outcome,
                   OutcomeType =  this.OutcomeTypes?.FirstOrDefault(d => d.Id == e.OutcomeTypeId)?.Title,
                   Department = this.Departments?.FirstOrDefault(d => d.Id == e.DepartmentId)?.Name,
                   HoursPerSem = e.HoursPerSem,
                   SuggestedHours = e.SuggestedHours
               }));                             
           }                
        } 
    }

    private async Task EditSubject(int id)
    {
        if (this.SubjectService != null)
        {
            var editedRowBl = this.SubjectBl?.Find(r => r.Id == id);
            var editedRowDto = this.SubjectDto?.Find(r => r?.Id == id);        
            
            
            var subject = await OpenDialog(editedRowBl);
            if (subject != default && editedRowBl is not null )
            {
                var result = await this.SubjectService.EditSubject(subject);
                if (result != null)
                {
                    this.SubjectDto?.Remove(editedRowDto);
                    this.SubjectBl?.Remove(editedRowBl);
                    this.SubjectBl?.Add(result);
                    
                    this.SubjectDto?.Add(new ()
                    {
                        Id = result.Id,
                        Title = result.Title,
                        Outcome = result.Outcome,
                        OutcomeType = this.OutcomeTypes?.FirstOrDefault(d => d.Id == result.OutcomeTypeId)?.Title,
                        Department = this.Departments?.FirstOrDefault(d => d.Id == result.DepartmentId)?.Name,
                        HoursPerSem = result.HoursPerSem,
                        SuggestedHours = editedRowBl.HoursPerSem
                    });
                }
            }
        }
    }
    
    
    private async Task DeleteSubject(int id)
    {
        if (this.SubjectService != null && await DialogService.DeleteConfirmationPopUp())
        {
            var result = await this.SubjectService.DelSubject(this.SubjectBl.Find(r => r.Id == id));
            if (result.HasValue)
            {
                this.SubjectDto?.Remove(SubjectDto.FirstOrDefault(row => row?.Id == id));
                this.SubjectBl?.Remove(SubjectBl.FirstOrDefault(row => row?.Id == id));
            }
        }
    }   
    
  
    private async Task AddSubject()
    {
       var subject = await OpenDialog();
       if (subject != default && this.SubjectService != null)
       {
           var result = await this.SubjectService.AddSubject(subject);
           if (result != null)
           {
               this.SubjectBl?.Add(result);
               this.SubjectDto?.Add(new ()
               {
                   Id = result.Id,
                   Title = result.
                   Outcome = result.Outcome,
                   OutcomeType = this.OutcomeTypes?.FirstOrDefault(d => d.Id == result.OutcomeTypeId)?.Title,
                   Department = this.Departments?.FirstOrDefault(d => d.Id == result.DepartmentId)?.Name,
                   HoursPerSem = result.HoursPerSem,
                   SuggestedHours = result.SuggestedHours                   
               });
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

    private async Task<SubjectBl?> OpenDialog(SubjectBl? row = default)
    {
        var options = new DialogOptions 
        {
            CloseOnEscapeKey = true,
            MaxWidth = MaxWidth.Large,
            Position = DialogPosition.Center,
        };
        
        var parameters = new DialogParameters<SubjectDialog>();
        
        var dialog = new SubjectDialog()
        {
            Department = new Select<DepartmentBl>("Ամբիոն", "DepartmentId", this.Departments),
            OutcomeType = new Select<OutcomeType>("Վերջնարդյունքի տիպ", "OutcomeTypeId", this.OutcomeTypes)

        };
        
        if (row is not null)
        {
            dialog.Title = row.Title;
            dialog.Outcome = row.Outcome;
            dialog.OutcomeType.SelectedValue = row.OutcomeTypeId;
            dialog.Department.SelectedValue = row.DepartmentId;
            dialog.HoursPerSem = row.HoursPerSem;
        }

        parameters.Add("ObjectType", dialog);
         
        var result = await(await DialogService.ShowAsync<DialogComponent<SubjectDialog>>("Ավելացնել առարկա", parameters, options)).Result;
        if (!result.Canceled && dialog.Department.SelectedValue != null && dialog.OutcomeType.SelectedValue != null && dialog.Department.SelectedValue != null)
        {
            return new SubjectBl()
            {
                DepartmentId = dialog.Department.SelectedValue.Value,
                OutcomeTypeId = dialog.OutcomeType.SelectedValue.Value,
                Outcome = dialog.Outcome,
                Title = dialog.Title,
                Id = row?.Id ?? 0,
                HoursPerSem = dialog.HoursPerSem,
                SuggestedHours = row?.SuggestedHours
            };
        }

        return default;
    }
}