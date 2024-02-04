using BackEnd.Models.Output;
using UserPost = BackEnd.Models.Input.UserPost;

namespace BackEnd.Services.Interfaces
{
    public interface IUserService
    {
        Task<Models.Output.UserPost?> LogIn(Models.Input.UserPost user);
       // Task<IResult> GenerateToken(UserPost user);
        Task<string> GenerateToken(UserPost user);

        public Task<List<UserGet?>> GetUsers();
    }



}
