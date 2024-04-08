using FrontEnd.Interface;
using FrontEnd.Model.BL;

namespace FrontEnd.API;

public class SubjectService : BaseService , ISubjectService
{
    public SubjectService(IHttpService httpService) : base(httpService, "Subject")
    {
    }

    public async Task<List<SubjectBl>?> GetSubjects(int departmentId)
    {
        var result = await this.Get<SubjectBl>(departmentId);
        return result;
    }
    
    
    public async Task<List<SubjectBl>?> GetSubjects()
    {
        var result = await this.Get<SubjectBl>();
        return result;
    }
    
    
    public async Task<SubjectBl?> AddSubject(SubjectBl model)
    {
        var result = await this.Add<SubjectBl, SubjectBl>(model);
        return result;
    }

    public async Task<bool?> DelSubject(SubjectBl model)
    {
        var result = await this.Delete<bool, SubjectBl>(model);
        return result;
    }

    public async Task<SubjectBl?> EditSubject(SubjectBl model)
    {
        var result = await this.Edit<SubjectBl, SubjectBl>(model);
        return result;
    }
}