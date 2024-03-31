using FrontEnd.Model;

namespace FrontEnd.Interface;

public interface IDepartmentService
{
    public Task<List<DepartmentBl>?> GetDepartments(); 
    public Task<List<DepartmentBl>?> GetDepartmentsByRole();
    public Task<DepartmentBl?> AddDepartment(DepartmentBl model);
    public Task<bool> DeleteDepartment(int id);
    
}