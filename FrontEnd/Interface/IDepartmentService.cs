using FrontEnd.Model;

namespace FrontEnd.Interface;

public interface IDepartmentService
{
    public Task<List<Department>?> GetDepartments(); 
    public Task<List<Department>?> GetDepartmentsByRole();
    
}