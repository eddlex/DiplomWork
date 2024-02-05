using FrontEnd.Model;

namespace FrontEnd.Interface;

public interface IDepartmentService
{
    public Task<List<Department>?> GetDepartments();
}