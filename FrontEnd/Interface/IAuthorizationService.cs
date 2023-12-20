using FrontEnd.Model;

namespace FrontEnd.Interface;

public interface IAuthorizationService
{
    public Task<string> AuthorizeClient(AuthorizationPost input);
    
}