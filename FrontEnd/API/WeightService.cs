using System.Runtime.CompilerServices;
using FrontEnd.Helpers;
using FrontEnd.Interface;
using FrontEnd.Model;

namespace FrontEnd.API;

public class WeightService : IWeightService
{
    private readonly IHttpService httpService;

    public WeightService(IHttpService httpService)
    {
        this.httpService = httpService;
    }
    public async Task<List<Weight>?> GetWeights()
    {
       var weights =  await this.httpService.Execute<List<Weight>, object>(HttpMethod.Get, "Weight");
       if (weights is null or { Count: 0 })
       {
           throw Helpers.Alert.Create(Constants.Error.NotExistAnyWeight);
       }

       return weights;
    }
    
    //public async Task<List<Department>?> GetDepartmentsByRole()
    //{
    //    var session = await this.httpService.GetSession() ?? throw Helpers.Alert.Create(Constants.Error.SessionNotFound);
    //    var departments = await GetDepartments();
        
    //    if (session.RoleId != 2 )
    //    {
    //        departments = departments?.Where(p=> p.Id == session?.DepartmentId).ToList();
    //    }
    //    return departments;
    //}
}



