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
       return await this.httpService.Execute<List<Department>, object>(HttpMethod.Get, "Department");
    }
}



