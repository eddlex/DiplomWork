
namespace FrontEnd.Interface;

public interface IBaseService
{
     Task<List<TRes>?> Get<TRes>();
     Task<TRes?> Delete<TRes, TReq>(TReq model);
     Task<TRes> Add<TRes, TReq>(TReq model);
     Task<TRes> Edit<TRes, TReq>(TReq model);
     string Controller { get; set; }
}