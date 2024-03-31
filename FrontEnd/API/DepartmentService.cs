using System.Runtime.CompilerServices;
using FrontEnd.Helpers;
using FrontEnd.Interface;
using FrontEnd.Model;

namespace FrontEnd.API;

public class DepartmentService :  BaseService,  IDepartmentService
{
    public DepartmentService(IHttpService httpService) : base(httpService, "Department")
    {
    }
    public async Task<List<Department>?> GetDepartments()
    {
       var departments =  await this.Get<Department>();
       if (departments is null or { Count: 0 })
       {
           throw Helpers.Alert.Create(Constants.Error.NotExistAnyDepartment);
       }

       return departments;
    }
    
    public async Task<List<Department>?> GetDepartmentsByRole()
    {
        var session = await this.GetSession() ?? throw Helpers.Alert.Create(Constants.Error.SessionNotFound);
        var departments = await GetDepartments();
        
        if (session.RoleId != 2 )
        {
            departments = departments?.Where(p=> p.Id == session.DepartmentId).ToList();
        }
        return departments;
    }
    
    
    public async Task<Department?> AddDepartment(Department model)
    {
        var session = await this.GetSession() ?? throw Helpers.Alert.Create(Constants.Error.SessionNotFound);
        if (session.RoleId != 2 )
            throw Helpers.Alert.Create(Constants.Error.WrongPermissions);

        var department = await this.Add<Department?, Department>(model);
        return department;
    }
    
    
    public async Task<bool> DeleteDepartment(int id)
    {
        var session = await this.GetSession() ?? throw Helpers.Alert.Create(Constants.Error.SessionNotFound);
        if (session.RoleId != 2 )
            throw Helpers.Alert.Create(Constants.Error.WrongPermissions);

        var result = await this.Delete<bool, int>(id);
        return result;
    }
}



