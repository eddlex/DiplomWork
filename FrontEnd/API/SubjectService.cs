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
}