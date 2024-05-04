using Blazored.SessionStorage;
using FrontEnd.Helpers;
using FrontEnd.Interface;
using FrontEnd.Model.BL;
using Microsoft.AspNetCore.Components;
namespace FrontEnd.Pages;

public partial class AdminPage
{
    [Inject]
    private ISemesterService? SemesterService { get; set; }

    [Inject]
    private ISubjectService? SubjectService { get; set; }    
    
        
    [Inject]
    private  ISessionStorageService? SessionStorageService { get; set; }


    protected override async Task OnInitializedAsync()
    {
        if (this.SubjectService != null && this.SessionStorageService != null && this.SemesterService != null)
        {
            var dep = (await this.SessionStorageService.GetItem("UserSession")).DepartmentId;
            this.SubjectsBl = await this.SubjectService?.GetSubjects(dep);
            if (this.SubjectsBl is { Count:  0 })
            {
                throw Alert.Create(Constants.Error.SomethingWrong);
            }
            this.semesters = await this.SemesterService.GetSemesters();
            if (this.semesters is { Count: 0 })
            {
                throw Alert.Create(Constants.Error.SomethingWrong);
            }
        } 
    }


    private void AddSemesterSubject((int oldIndex, int newIndex) indices)
    {
        var item = allSubjects?[indices.oldIndex];

        if (item == null)
            return;

        selectedSubjects?.Insert(indices.newIndex, item);
        allSubjects?.Remove(allSubjects[indices.oldIndex]);

        for (var i = 0; i < selectedSubjects?.Count; ++i)
        {
            selectedSubjects[i].Order = i;
        }

        //var itemBl = AddFormRow(new FormRowBl()
        //{
        //    FormId = _currentSelectedFormId,
        //    SubjectId = item.Id,
        //    Order = item.Order
        //});
    }

    public void DeleteSemesterSubject((int oldIndex, int newIndex) indices)
    {
        var item = selectedSubjects?[indices.oldIndex];

        if (item == null)
            return;

        allSubjects?.Insert(indices.newIndex, item);

        selectedSubjects?.Remove(selectedSubjects[indices.oldIndex]);

        for (var i = 0; i < selectedSubjects?.Count; ++i)
        {
            selectedSubjects[i].Order = i;
        }

        //var itemBl = DeleteFormRow(new FormRowBl()
        //{
        //    Id = item.Id,
        //    FormId = _currentSelectedFormId,
        //});
    }

}