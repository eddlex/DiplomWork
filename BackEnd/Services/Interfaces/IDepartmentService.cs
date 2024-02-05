using BackEnd.Models.Input;
using BackEnd.Models.Output;

namespace BackEnd.Services.Interfaces
{
    public interface IDepartmentService
    {
        Task<List<Department?>> GetDepartments();
        Task<bool> AddUniversity(DepartmentPost department);
        Task<bool> DelUniversity(int id);
    }
}
