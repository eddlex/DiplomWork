using FrontEnd.Helpers;
using FrontEnd.Interface;
using FrontEnd.Model;

namespace FrontEnd.API;

public class UserService : HttpService , IUserService
{
    public UserService(HttpClient httpClient):base(httpClient)
    {
    }
    
    
    public async Task<bool> RegisterUser(RegistrationPost input)
    {
        input.Password.ComputeSHA512Hash();
        var result = await Execute<bool, RegistrationPost>(HttpMethod.Post, "User/Register", input);
        
        return result;
    }
}