using FrontEnd.Interface;
using FrontEnd.Model;

namespace FrontEnd.API;

public class UniversityService : HttpService, IUniversityService
{
    public UniversityService(HttpClient httpClient):base(httpClient)
    {
    }
    
    public async Task<List<University>?> GetUniversities()
    {
       return await Execute<List<University>, object>(HttpMethod.Get, "University");
    }
}



