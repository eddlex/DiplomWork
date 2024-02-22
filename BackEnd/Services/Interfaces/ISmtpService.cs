using BackEnd.Services.Services;
using BackEnd.Models.Input;
using BackEnd.Models.Output;

namespace BackEnd.Services.Interfaces
{
    public interface ISmtpService
    {
        Task<int> DeleteSmtpConfig(SmtpConfigDelete model);
        Task<T1> EditSmtpConfig<T1, T2>(T2 model);
        Task<List<SmtpConfig?>> GetSmtpConfig();
        Task<T1> AddSmtpConfig<T1, T2>(T2 model);
    }
}
