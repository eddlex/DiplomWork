using FrontEnd.Model;

namespace FrontEnd.Interface;

public interface IUniversityService
{
    public Task<List<University>?> GetUniversities();
}