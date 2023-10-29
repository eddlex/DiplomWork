using System.Data.SqlClient;

namespace BackEnd.Services.Form
{
    public interface IFormService
    {
        Task<List<Models.Input.Form>> GetForms(int? GroupId = null);
    }
}
