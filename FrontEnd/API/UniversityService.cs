using FrontEnd.Interface;
using FrontEnd.Model;

namespace FrontEnd.API;

public class UniversityService :  IUniversityService
{
    // public UniversityService(HttpClient httpClient):base(httpClient)
    // {
    // }
    private readonly IHttpService httpService;

    public UniversityService(IHttpService httpService)
    {
        this.httpService = httpService;
    }
    public async Task<List<University>?> GetUniversities()
    {
       return await this.httpService.Execute<List<University>, object>(HttpMethod.Get, "University");
    }
}



