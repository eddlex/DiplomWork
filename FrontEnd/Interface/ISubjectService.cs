using FrontEnd.Model;
using FrontEnd.Model.BL;

namespace FrontEnd.Interface;

public interface ISubjectService
{
    public Task<List<SubjectBl>?> GetSubjects(int departmentId);
    public Task<List<SubjectBl>?> GetSubjects();
    public Task<SubjectBl?> AddSubject(SubjectBl model);
    public Task<bool?> DelSubject(SubjectBl model);
    public Task<SubjectBl?> EditSubject(SubjectBl model);

}