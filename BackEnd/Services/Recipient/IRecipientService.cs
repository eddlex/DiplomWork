using BackEnd.Models.Input;
using System.Data.SqlClient;

namespace BackEnd.Services.Form
{
    public interface IRecipientService
    {
        Task<List<RecipientGroup>> GetRecipientGroups(int? Id = null);
        Task<bool> DelRecipientGroups(List<int> ides);
    }
}
