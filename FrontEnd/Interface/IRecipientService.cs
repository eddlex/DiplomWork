using FrontEnd.Model;

namespace FrontEnd.Interface;

public interface IRecipientService
{
    public Task<List<Recipient>?> GetRecipient();

}