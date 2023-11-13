using BackEnd.Models.Input;

namespace BackEnd.Services.Interfaces
{
    public interface IUserService
    {
        Task<Models.Output.UserPost> LogIn(Models.Input.UserPost user);
        Task<IResult> GenerateToken(UserPost user);
    }



}
