using System.Runtime.CompilerServices;
using FrontEnd.Helpers;
using FrontEnd.Interface;
using FrontEnd.Model;

namespace FrontEnd.API;

public class WeightService : BaseService,  IWeightService
{
    
    public WeightService(IHttpService httpService) : base(httpService, "Weight")
    {
    }
    public async Task<List<Weight>?> GetWeights()
    {
       var weights =  await this.Get<Weight>();
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



