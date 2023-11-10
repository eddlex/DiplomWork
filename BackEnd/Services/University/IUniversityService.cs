using BackEnd.Models.Input;

namespace BackEnd.Services.University
{
    public interface IUniversityService
    {
        Task<List<Models.Output.University>> GetUniversities();
        Task<bool> AddUniversity(UniversityPost university);
        Task<bool> DelUniversity(int id);
    }
}
