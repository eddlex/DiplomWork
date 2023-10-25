using System.Data.SqlClient;

namespace BackEnd.Services.Form
{
    public interface IFormService
    {
        Task<List<Models.Form.Form>> GetForms(int GroupId);
    }
}
