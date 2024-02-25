using FrontEnd.Interface;
using FrontEnd.Model;
using FrontEnd.Model.BL;

namespace FrontEnd.API;

public class RecipientService : BaseService, IRecipientService
{
    
    public RecipientService(IHttpService httpService) :base(httpService, "Recipient")
    {
        
    }
    
    public async Task<List<Recipient>?> GetRecipient()
    {
        var result = await this.Get<Recipient>();
        return result;
    }

    public async Task<Recipient?> AddRecipient(Recipient model)
    {
        var result = await this.Add<Recipient?, Recipient>(model);
        return result;
    }

    public async Task<Recipient?> EditRecipient(Recipient model)
    {
        var result = await this.Edit<Recipient?, Recipient>(model);
        return result;
    }
    
    public async Task<int?> DelRecipient(Recipient model)
    {
        var result = await this.Delete<int?, Recipient?>(model);
        return result;
    }
    public async Task<List<RecipientGroup>?> GetRecipientsGroups()
    {
        var result = await this.Get<RecipientGroup>(method:"Group");
        return result;
    }

    public async Task<RecipientGroup?> AddRecipientGroup(RecipientGroup model)
    {
        var result = await this.Add<RecipientGroup, RecipientGroup>(model, method:"Group");
        return result;
    }
    
    public async Task<int?> DeleteRecipientGroup(RecipientGroup model)
    {
        var result = await this.Delete<int, RecipientGroup>(model, method:"Group");
        return result ;
    }
}