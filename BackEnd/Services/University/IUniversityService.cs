namespace BackEnd.Services.University
{
    public interface IUniversityService
    {
        Task<List<Models.Output.University>> GetUniversities();
    }
}
