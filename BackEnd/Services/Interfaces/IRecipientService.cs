using BackEnd.Models.Input;
using System.Data.SqlClient;

namespace BackEnd.Services.Interfaces
{
    public interface IRecipientService
    {
        Task<List<RecipientGroupGet>> GetRecipientGroups(int? Id = null);
        Task<bool> DelRecipientGroups(List<int> ides);
        Task<bool> UpdateRecipientGroups(List<RecipientGroupPut> groups);
    }
}
