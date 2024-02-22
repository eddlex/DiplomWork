using FrontEnd.Interface;

namespace FrontEnd.API;

public class FormService :  BaseService
{
    public FormService(IHttpService httpService) : base(httpService, "Form")
    {
    }
}