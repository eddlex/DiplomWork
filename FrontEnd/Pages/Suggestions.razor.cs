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

public partial class Suggestions
{
    [Inject]
    private ISuggestionService? suggestionService { get; set; }

    private List<Suggestion>? suggestions { get; set; }
    private List<Suggestion>? similarSuggestions { get; set; }




    //private async Task GetFormRows(int? id = null)
    //{
    //    if (this.FormService != null &&
    //        this.SubjectService != null)
    //    {
    //        id ??= this.FormBl?.OrderBy(r => r?.Id).First()?.Id;
    //        _currentSelectedFormId = id.Value;
    //        var departmentId = this.FormBl?.First(r => r.Id == id).DepartmentId;
    //        this.SubjectsBl = await this.SubjectService.GetSubjects(departmentId.Value);
    //        this.FormRowBl = await this.FormService.Get<FormRowBl>(id, "Row") ?? new();
    //        selectedSubjects?.Clear();
    //        var tmpCount = default(int);
    //        foreach (var item in this.FormRowBl)
    //        {
    //            var subject = this.SubjectsBl?.FirstOrDefault(r => r.Id == item.SubjectId);
    //            if (subject != null)
    //            {
    //                this.selectedSubjects?.Add(new()
    //                {
    //                    Id = item.Id,
    //                    Title = subject.Title,
    //                    Order = tmpCount++,
    //                    Outcome = subject.Outcome
    //                });
    //            }
    //        }

    //        if (SubjectsBl != null)
    //        {
    //            this.SubjectsDto?.Clear();
    //            foreach (var item in this.SubjectsBl)
    //            {
    //                if (!this.FormRowBl.Select(r => r.SubjectId).Contains(item.Id))
    //                {
    //                    this.SubjectsDto?.Add(new()
    //                    {
    //                        Id = item.Id,
    //                        Title = item.Title,
    //                        Outcome = item.Outcome
    //                    });
    //                }
    //            }
    //        }
    //        else
    //        {
    //            Alert.Create(Helpers.Constants.Error.SubjectNotExist);
    //        }
    //    }
    //}


    protected override async Task OnInitializedAsync()
    {

        if (this.suggestionService != null)
        {
            this.suggestions = await this.suggestionService.GetSuggestions();
        }

        similarSuggestions = new List<Suggestion>();
    }

    public async Task GetSimilars(int? suggId = null)
    {
        if (this.suggestionService != null)
        {
            var result = await this.suggestionService.GetSimilars(suggId);
            similarSuggestions = result.ToList();
        }
    }

    private async Task DeleteRow(int id)
    {
        if (this.suggestionService != null && await DialogService.DeleteConfirmationPopUp())
        {
            var result = await this.suggestionService.Delete(id);

            if (result && this.suggestions is { Count: > 0 })
            {
                this.suggestions.Remove(this.suggestions.First(r => r.Id == id));
            }
        }
    }
}