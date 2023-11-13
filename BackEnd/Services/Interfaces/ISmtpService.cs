using BackEnd.Services.Services;

namespace BackEnd.Services.Interfaces
{
    public interface ISmtpService
    {
        Task<bool> DelSmtpConfig(int ConfigId);
        Task<bool> UpdateSmtpConfig(SmtpConfig config);
        Task<SmtpConfig> GetSmtpConfig(int id);
    }
}
