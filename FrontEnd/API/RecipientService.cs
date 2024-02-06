using FrontEnd.Interface;
using FrontEnd.Model;

namespace FrontEnd.API;

public class RecipientService :  IRecipientService
{
    private readonly IHttpService httpService;

    public RecipientService(IHttpService httpService)
    {
        this.httpService = httpService;
    }
    
    public async Task<List<Recipient>?> GetRecipient()
    {
        var result = await this.httpService.Execute<List<Recipient>, object>(HttpMethod.Get, "Recipient");
        return result;
    }
    
}