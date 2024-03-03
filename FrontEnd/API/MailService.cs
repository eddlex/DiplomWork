using FrontEnd.Interface;
using FrontEnd.Model;


namespace FrontEnd.API;

public class MailService : BaseService, IMailService
{
    public MailService(IHttpService httpService) : base(httpService, "Mail")
    {
    }

    public async Task<bool> SendMail(FormBl model)
    {
       var result =  await this.Add<bool, FormBl>(model);
       return result;
    }
}