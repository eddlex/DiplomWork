using FrontEnd.Interface;
using FrontEnd.Model;
using FrontEnd.Model.BL;

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

    public async Task<Recipient?> AddRecipient(Recipient model)
    {
        var result = await this.httpService.Execute<Recipient?, Recipient>(HttpMethod.Post, "Recipient", model);
        return result;
    }
    public async Task<List<RecipientGroup>?> GetRecipientsGroups()
    {
        var result = await this.httpService.Execute<List<RecipientGroup>, object>(HttpMethod.Get, "Recipient/Groups");
        return result;
    }
    
    
   
}