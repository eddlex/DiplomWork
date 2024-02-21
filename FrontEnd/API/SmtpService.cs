using FrontEnd.Interface;
using FrontEnd.Model;
using FrontEnd.Model.BL;

namespace FrontEnd.API;

public class SmtpService :  ISmtpService
{
    private readonly IHttpService httpService;

    public SmtpService(IHttpService httpService)
    {
        this.httpService = httpService;
    }
    
    public async Task<List<SmtpConfigBl>?> GetSmtpConfigurations()
    {
        var result = await this.httpService.Execute<List<SmtpConfigBl>, object>(HttpMethod.Get, "Smtp");
        return result;
    }
    
    public async Task<int> DeleteSmtpConfiguration(SmtpConfigBl model)
    {
        var result = await this.httpService.Execute<int, SmtpConfigBl>(HttpMethod.Delete, "Smtp", model);
        return result;
    }

    // public async Task<Recipient?> AddRecipient(Recipient model)
    // {
    //     var result = await this.httpService.Execute<Recipient?, Recipient>(HttpMethod.Post, "Recipient", model);
    //     return result;
    // }
    //
    // public async Task<Recipient?> EditRecipient(Recipient model)
    // {
    //     var result = await this.httpService.Execute<Recipient?, Recipient>(HttpMethod.Put, "Recipient", model);
    //     return result;
    // }
    //

    // public async Task<List<RecipientGroup>?> GetRecipientsGroups()
    // {
    //     var result = await this.httpService.Execute<List<RecipientGroup>, object>(HttpMethod.Get, "Recipient/Groups");
    //     return result;
    // }
    
    
   
}