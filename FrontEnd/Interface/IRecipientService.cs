using FrontEnd.Model;
using FrontEnd.Model.BL;

namespace FrontEnd.Interface;

public interface IRecipientService
{
    public Task<List<Recipient>?> GetRecipient();
    public Task<List<RecipientGroup>?> GetRecipientsGroups();

}