using FrontEnd.Model;
using FrontEnd.Model.BL;

namespace FrontEnd.Interface;

public interface ISmtpService
{
     Task<List<T>?> GetSmtpConfigurations<T>();
     Task<T1?> DeleteSmtpConfiguration<T1, T2>(T2 model);
     Task<T1> AddSmtpConfiguration<T1, T2>(T2 model);
     Task<T1> EditSmtpConfiguration<T1, T2>(T2 model);

}