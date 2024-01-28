using FrontEnd.Model;

namespace FrontEnd.Interface;

public interface IUserService
{
    public Task<bool> RegisterUser(RegistrationPost input);
}