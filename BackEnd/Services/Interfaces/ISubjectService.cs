using BackEnd.Models.Output;

namespace BackEnd.Services.Interfaces
{
    public interface ISubjectService
    {
        Task<List<Subject>> GetSubjects(int id);
        Task<Subject?> AddGetSubject(Recipient model);
        Task<int?> DeleteSubject(Recipient model);
        Task<Recipient?> EditGetSubject(Recipient model);
    }
}
