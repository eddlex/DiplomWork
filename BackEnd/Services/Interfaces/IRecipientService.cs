using BackEnd.Models.Input;
using System.Data.SqlClient;
using BackEnd.Models.Output;

namespace BackEnd.Services.Interfaces
{
    public interface IRecipientService
    {
        Task<List<RecipientGroupGet?>> GetRecipientGroups(int? Id = null);
        Task<RecipientGroup?> AddRecipientGroup(RecipientGroupPost model);
        Task<int?> DeleteRecipientGroup(RecipientGroupDelete model);
        Task<RecipientGroup?> EditRecipientGroup(RecipientGroupPut model);

        
        Task<List<Recipient>> GetRecipients();
        Task<Recipient?> AddRecipient(Recipient model);
        Task<int?> DeleteRecipient(Recipient model);
        Task<Recipient?> EditRecipient(Recipient model);
    }
}
