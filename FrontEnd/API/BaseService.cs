using System.Net;
using FrontEnd.Helpers;
using FrontEnd.Interface;

namespace FrontEnd.API;

public abstract class BaseService : IBaseService
{
    private readonly IHttpService? httpService;
    public string Controller { get; set; }

    protected BaseService(IHttpService httpService, string controller)
    {
        this.httpService = httpService;
        this.Controller = controller;
    }
    
    public virtual async Task<List<T>?> Get<T>(object? id = null, string method = "")
    {
        if (this.httpService is null)
            throw Alert.Create(Constants.Error.Injection);
        if (id != null)
            return await this.httpService.Execute<List<T>, object>(HttpMethod.Get, this.Controller + "/" + method, id);
        else
            return await this.httpService.Execute<List<T>, object>(HttpMethod.Get, this.Controller + "/" + method);

    }
    
    public virtual async Task<T1?> Delete<T1, T2>(T2 model, string method = "")
    {
        if (this.httpService is null) 
            throw Alert.Create(Constants.Error.Injection);
        var result = await this.httpService.Execute<T1, T2>(HttpMethod.Delete, this.Controller + "/" + method, model  );
        return result;
    }
    
    public virtual async Task<T1> Add<T1, T2>(T2 model, string method = "")
    {
        if (this.httpService is null)
            throw Alert.Create(Constants.Error.Injection);
        var result = await this.httpService.Execute<T1, T2>(HttpMethod.Post, this.Controller + "/" + method, model);
        
        return result ?? throw Alert.Create(Constants.Error.BackEnd);
    }
    public virtual async Task<T1> Edit<T1, T2>(T2 model, string method = "")
    {
        if (this.httpService is null)
            throw Alert.Create(Constants.Error.Injection);
        var result = await this.httpService.Execute<T1, T2>(HttpMethod.Put, this.Controller + "/" + method, model);
        return result ?? throw Alert.Create(Constants.Error.BackEnd);
    }

    
}