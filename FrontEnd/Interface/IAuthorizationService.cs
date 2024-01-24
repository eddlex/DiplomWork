using FrontEnd.Model;

namespace FrontEnd.Interface;

public interface IAuthorizationService
{
    public Task<bool> AuthorizeClient(AuthorizationPost input);
    
}