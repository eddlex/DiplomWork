using FrontEnd.Model;

namespace FrontEnd.Interface;

public interface IWeightService
{
    public Task<List<Weight>?> GetWeights(); 
    //public Task<List<Department>?> GetDepartmentsByRole();
    
}