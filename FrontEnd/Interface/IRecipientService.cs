using FrontEnd.Model;
using FrontEnd.Model.BL;

namespace FrontEnd.Interface;

public interface IRecipientService
{
    public Task<List<Recipient>?> GetRecipient();
    public Task<Recipient?> AddRecipient(Recipient model);

    public Task<int?> DelRecipient(Recipient model);
    public Task<Recipient?> EditRecipient(Recipient model);
    
    public Task<List<RecipientGroup>?> GetRecipientsGroups();
    public Task<RecipientGroup?> AddRecipientGroup(RecipientGroup model);
    public Task<int?> DeleteRecipientGroup(RecipientGroup model);
    public Task<RecipientGroup> EditRecipientGroup(RecipientGroup model);

}