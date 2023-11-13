using System.Data.SqlClient;

namespace BackEnd.Services.Interfaces
{
    public interface IFormService
    {
        Task<List<Models.Output.Form>> GetForms(int? GroupId = null);
    }
}
