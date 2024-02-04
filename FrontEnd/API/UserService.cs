using FrontEnd.Helpers;
using FrontEnd.Interface;
using FrontEnd.Model;

namespace FrontEnd.API;

public class UserService :  IUserService
{
    
    // public UserService(HttpClient httpClient):base(httpClient)
    // {
    // }
    private readonly IHttpService httpService;

    public UserService(IHttpService httpService)
    {
        this.httpService = httpService;
    }
    
    public async Task<bool> RegisterUser(RegistrationPost input)
    {
        input.Password = input.Password.ComputeSHA512Hash();
        var result = await this.httpService.Execute<bool, RegistrationPost>(HttpMethod.Post, "User/Register", input);
        
        return true;
      //  return result;
    }

    public Task<List<User?>> GetUsers()
    {
        throw new NotImplementedException();
    }
}