using FrontEnd.Model;

namespace FrontEnd.Interface;

public interface IBaseService
{
    Task<List<T>?> Get<T>(object? id = null, string method = "");
     Task<TRes?> Delete<TRes, TReq>(TReq model, string method = "");
     Task<TRes> Add<TRes, TReq>(TReq model, string method = "");
     Task<TRes> Edit<TRes, TReq>(TReq model, string method = "");
     string Controller { get; set; }

     Task<UserSession?> GetSession();
}