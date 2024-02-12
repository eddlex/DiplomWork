using System.Runtime.CompilerServices;
using FrontEnd.Helpers;
using FrontEnd.Interface;
using FrontEnd.Model;

namespace FrontEnd.API;

public class DepartmentService :  IDepartmentService
{
    private readonly IHttpService httpService;

    public DepartmentService(IHttpService httpService)
    {
        this.httpService = httpService;
    }
    public async Task<List<Department>?> GetDepartments()
    {
       var departments =  await this.httpService.Execute<List<Department>, object>(HttpMethod.Get, "Department");
       if (departments is null or { Count: 0 })
       {
           throw Helpers.Exception.Create(Constants.Error.NotExistAnyDepartment);
       }

       return departments;
    }
    
    public async Task<List<Department>?> GetDepartmentsByRole()
    {
        var session = this.httpService.Session ?? throw Helpers.Exception.Create(Constants.Error.SessionNotFound);
        var departments = await GetDepartments();
        
        if (session.RoleId != 2 )
        {
            departments = departments?.Where(p=> p.Id == session?.DepartmentId).ToList();
        }
        return departments;
    }
}



