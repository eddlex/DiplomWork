using FrontEnd.Model;
using FrontEnd.Model.BL;

namespace FrontEnd.Interface;

public interface IRecipientService
{
    public Task<List<Recipient>?> GetRecipient();
    public Task<Recipient?> AddRecipient(Recipient model);
    public Task<List<RecipientGroup>?> GetRecipientsGroups();

}