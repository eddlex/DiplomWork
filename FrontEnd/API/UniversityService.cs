using System.Security.Claims;
using Blazored.SessionStorage;
using FrontEnd.Helpers;
using FrontEnd.Interface;
using FrontEnd.Model;
using Microsoft.AspNetCore.Components.Authorization;
using Exception = System.Exception;

namespace FrontEnd.API;

public class UniversityService : HttpService, IUniversityService
{
    public UniversityService(HttpClient httpClient):base(httpClient)
    {
    }


    public async Task<List<University>?> GetUniversities()
    {
        var result = await Execute<List<University>, object>(HttpMethod.Get, "University");
        return result;
    }
}



