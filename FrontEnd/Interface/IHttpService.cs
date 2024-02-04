namespace FrontEnd.Interface;

public interface IHttpService
{
    Task<T1?> Execute<T1, T2>(HttpMethod method, string apiUrl, T2? requestBody = default);
}