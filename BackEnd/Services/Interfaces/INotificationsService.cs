namespace BackEnd.Services.Interfaces
{
    public interface INotificationsService
    {
        Task SendPhoneVerificationCode(int ClientId);
        Task<bool> SendForms(int groupId);
    }
}
