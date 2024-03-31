using FrontEnd.Model;

namespace FrontEnd.Interface;

public interface IDepartmentService
{
    public Task<List<Department>?> GetDepartments(); 
    public Task<List<Department>?> GetDepartmentsByRole();
    public Task<Department?> AddDepartment(Department model);
    public Task<bool> DeleteDepartment(int id);
    
}