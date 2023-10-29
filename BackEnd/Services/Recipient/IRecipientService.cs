using BackEnd.Models;
using System.Data.SqlClient;

namespace BackEnd.Services.Form
{
    public interface IRecipientService
    {
        Task<List<RecipientGroup>> GetRecipientGroups(int? Id = null);
    }
}
