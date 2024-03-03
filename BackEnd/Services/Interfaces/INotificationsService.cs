using BackEnd.Models.Output;

namespace BackEnd.Services.Interfaces
{
    public interface INotificationsService
    {
        Task SendPhoneVerificationCode(int ClientId);
        Task<bool> SendForms(Form model);
    }
}
