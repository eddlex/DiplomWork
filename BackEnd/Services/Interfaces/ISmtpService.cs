using BackEnd.Services.Services;
using BackEnd.Models.Input;
using BackEnd.Models.Output;

namespace BackEnd.Services.Interfaces
{
    public interface ISmtpService
    {
        Task<bool> DelSmtpConfig(int PermissionId, int ConfigId);
        Task<bool> UpdateSmtpConfig(int PermissionId, SmtpConfigPut config);
        Task<SmtpConfig> GetSmtpConfig(int PermissionId, int id);
    }
}
