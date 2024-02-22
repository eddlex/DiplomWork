using FrontEnd.Interface;

namespace FrontEnd.API;

public class BaseService : IBaseService
{
    public readonly IHttpService? HttpService;
    public string Controller { get; set; }
    
    public BaseService(IHttpService httpService, string controller)
    {
        this.HttpService = httpService;
        this.Controller = controller;
    }
    
    public virtual async Task<List<T>?> Get<T>()
    {
        var result = await this.HttpService.Execute<List<T>, object>(HttpMethod.Get, "Form");
        return result;
    }
    
    public virtual async Task<T1?> Delete<T1, T2>(T2 model)
    {
        var result = await this.HttpService.Execute<T1, T2>(HttpMethod.Delete, "Form", model);
        return result;
    }
    
    public virtual async Task<T1> Add<T1, T2>(T2 model)
    {
        var result = await this.HttpService.Execute<T1, T2>(HttpMethod.Post, "Form", model);
        return result;
    }
    public virtual async Task<T1> Edit<T1, T2>(T2 model)
    {
        var result = await this.HttpService.Execute<T1, T2>(HttpMethod.Put, "Form", model);
        return result;
    }

    
}