using BackEnd.Models.Input;
using System.Data.SqlClient;
using BackEnd.Models.Output;

namespace BackEnd.Services.Interfaces
{
    public interface IRecipientService
    {
        Task<List<RecipientGroupGet?>> GetRecipientGroups(int? Id = null);
        Task<bool> DelRecipientGroups(List<int> ides);
        Task<bool> UpdateRecipientGroups(List<RecipientGroupPut> groups);

        Task<List<Recipient>> GetRecipients();
        
        Task<Recipient?> AddRecipient(Recipient model);
        Task<int?> DeleteRecipient(Recipient model);
    }
}
