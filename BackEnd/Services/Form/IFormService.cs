using System.Data.SqlClient;

namespace BackEnd.Services.Form
{
    public interface IFormService
    {
        Task<List<Models.Output.Form>> GetForms(int? GroupId = null);
    }
}
