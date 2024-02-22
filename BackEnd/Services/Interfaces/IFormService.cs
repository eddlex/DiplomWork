using System.Data.SqlClient;
using BackEnd.Models.Input;
using BackEnd.Models.Output;

namespace BackEnd.Services.Interfaces
{
    public interface IFormService
    {
        Task<List<Models.Output.Form>> GetForms();
        Task<Form> AddForm(FormPost model);
    }
}
