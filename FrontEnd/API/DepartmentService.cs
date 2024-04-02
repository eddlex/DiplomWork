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
    public async Task<List<DepartmentBl>?> GetDepartments()
    {
       var departments =  await this.Get<DepartmentBl>();
       if (departments is null or { Count: 0 })
       {
           throw Helpers.Alert.Create(Constants.Error.NotExistAnyDepartment);
       }

       return departments;
    }
    
    public async Task<List<DepartmentBl>?> GetDepartmentsByRole()
    {
        var session = await this.GetSession() ?? throw Helpers.Alert.Create(Constants.Error.SessionNotFound);
        var departments = await GetDepartments();
        
        if (session.RoleId != 2 )
        {
            departments = departments?.Where(p=> p.Id == session.DepartmentId).ToList();
        }
        return departments;
    }
    
    
    public async Task<DepartmentBl?> AddDepartment(DepartmentBl model)
    {
        var session = await this.GetSession() ?? throw Helpers.Alert.Create(Constants.Error.SessionNotFound);
        if (session.RoleId != 2 )
            throw Helpers.Alert.Create(Constants.Error.WrongPermissions);

        var department = await this.Add<DepartmentBl?, DepartmentBl>(model);
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
    
    public async Task<DepartmentBl?> EditDepartment(DepartmentBl model)
    {
        var session = await this.GetSession() ?? throw Helpers.Alert.Create(Constants.Error.SessionNotFound);
        if (session.RoleId != 2 )
            throw Helpers.Alert.Create(Constants.Error.WrongPermissions);

        var result = await this.Edit<DepartmentBl?, DepartmentBl>(model);
        
        return result;
    }
}



