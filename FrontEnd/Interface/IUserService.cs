using FrontEnd.Model;

namespace FrontEnd.Interface;

public interface IUserService
{
    public Task<bool> RegisterUser(RegistrationPost input);
    public Task<List<User?>> GetUsers();
    public Task<User?> EditUser(User model);
    public Task<int?> DeleteUser(User model);

}