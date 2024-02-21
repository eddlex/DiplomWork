using FrontEnd.Model;
using FrontEnd.Model.BL;

namespace FrontEnd.Interface;

public interface ISmtpService
{
    public Task<List<SMTPConfig>?> GetSmtpConfigurations();

}