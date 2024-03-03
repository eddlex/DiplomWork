using BackEnd.Models.Output;

namespace BackEnd.Services.Interfaces
{
    public interface IMailService
    {
        // Task SendPhoneVerificationCode(int ClientId);
        Task<bool> SendMail(Form model);
    }
}
