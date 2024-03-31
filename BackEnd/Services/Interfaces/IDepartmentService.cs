using BackEnd.Models.Input;
using BackEnd.Models.Output;

namespace BackEnd.Services.Interfaces
{
    public interface IDepartmentService
    {
        Task<List<Department?>> GetDepartments();
        Task<Department?> AddDepartment(DepartmentPost department);
        Task<bool> DelDepartment(int id);
    }
}
