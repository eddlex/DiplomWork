using FrontEnd.Model;

namespace FrontEnd.Interface;

public interface IMailService
{
    Task<bool> SendMail(FormBl model);
}