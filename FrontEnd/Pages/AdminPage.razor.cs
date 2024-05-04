using Blazored.SessionStorage;
using FrontEnd.Helpers;
using FrontEnd.Interface;
using FrontEnd.Model.BL;
using Microsoft.AspNetCore.Components;
namespace FrontEnd.Pages;

public partial class AdminPage
{
    
    [Inject]
    private ISubjectService? SubjectService { get; set; }    
    
        
    [Inject]
    private  ISessionStorageService? SessionStorageService { get; set; }
    
    
    public List<SubjectBl> SubjectsBl { get; set; }


    protected override async Task OnInitializedAsync()
    {
        if (this.SubjectService != null && this.SessionStorageService != null)
        {
            var dep = (await this.SessionStorageService.GetItem("UserSession")).DepartmentId;
            this.SubjectsBl = await this.SubjectService?.GetSubjects(dep);
            if (this.SubjectsBl is { Count:  0 })
            {
                throw Alert.Create(Constants.Error.NotExistAnyDepartment);
            }
        } 
    }
    
    
    private async Task AddFormRow((int oldIndex, int newIndex) valueTuple)
    {
        
        if (this.SubjectService != null)
        {
            await this.SubjectService.GetSubjects();
        }
    }
}