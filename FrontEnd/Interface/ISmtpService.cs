using FrontEnd.Model;
using FrontEnd.Model.BL;

namespace FrontEnd.Interface;

public interface ISmtpService
{
     Task<List<SmtpConfigBl>?> GetSmtpConfigurations();
     Task<int> DeleteSmtpConfiguration(SmtpConfigBl model);

}