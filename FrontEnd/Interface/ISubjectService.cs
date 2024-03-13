using FrontEnd.Model;
using FrontEnd.Model.BL;

namespace FrontEnd.Interface;

public interface ISubjectService
{
    public Task<List<SubjectBl>?> GetSubjects();
}