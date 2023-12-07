namespace BackEnd.Services.Interfaces
{
    public interface INotificationsService
    {
        Task SendPhoneVerificationCode(int ClientId);
        Task SendForms(int groupId);
    }
}
