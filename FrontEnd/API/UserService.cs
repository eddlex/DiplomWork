using System.Data.SqlClient;
using FrontEnd.Helpers;
using FrontEnd.Interface;
using FrontEnd.Model;

namespace FrontEnd.API;

public class UserService : BaseService, IUserService
{
    
    // public UserService(HttpClient httpClient):base(httpClient)
    // {
    // }
    private readonly IHttpService httpService;

    public UserService(IHttpService httpService) :base
        (httpService, "User")
    {

    }

    public async Task<bool> RegisterUser(RegistrationPost input)
    {
        
        input.Password = input.Password.ComputeSHA512Hash();
        var result = await this.httpService.Execute<bool, RegistrationPost>(HttpMethod.Post, "User/Register", input);
        
        return true;
    }

    public async Task<List<User?>> GetUsers()
    {
        //var result = await this.httpService.Execute<List<User>, object>(HttpMethod.Get, "User");
        var result = await this.Get<User>();
        return result;
    }


    public async Task<User?> EditUser(User model)
    {
        var result = await this.Edit<User?, User>(model);
        return result;
    }

    public async Task<int?> DeleteUser(User model)
    {
        var result = await this.Delete<int?, User?>(model);
        return result;
    }
}