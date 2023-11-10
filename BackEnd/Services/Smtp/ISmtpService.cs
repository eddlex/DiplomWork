namespace BackEnd.Services.SMTPConfig
{
    public interface ISmtpService
    {
        Task<bool> DelSmtpConfig(int ConfigId);
        Task<bool> UpdateSmtpConfig(SmtpConfig config);
        Task<SmtpConfig> GetSmtpConfig(int id);
    }
}
