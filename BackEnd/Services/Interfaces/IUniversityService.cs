using BackEnd.Models.Input;
using BackEnd.Models.Output;

namespace BackEnd.Services.Interfaces
{
    public interface IUniversityService
    {
        Task<List<University?>> GetUniversities();
        Task<bool> AddUniversity(UniversityPost university);
        Task<bool> DelUniversity(int id);
    }
}
