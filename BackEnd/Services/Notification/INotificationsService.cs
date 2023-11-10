

namespace BackEnd.Services.Notification
{
    public interface INotificationsService
    {
        Task SendPhoneVerificationCode(int ClientId);
        Task SendMessage();
    }
}
