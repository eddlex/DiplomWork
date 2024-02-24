
namespace FrontEnd.Interface;

public interface IBaseService
{
    Task<List<T>?> Get<T>(int? id = null, string method = "");
     Task<TRes?> Delete<TRes, TReq>(TReq model);
     Task<TRes> Add<TRes, TReq>(TReq model);
     Task<TRes> Edit<TRes, TReq>(TReq model);
     string Controller { get; set; }
}