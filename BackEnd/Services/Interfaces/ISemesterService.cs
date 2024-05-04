using BackEnd.Models.Input;
using BackEnd.Models.Output;

namespace BackEnd.Services.Interfaces
{
    public interface ISemesterService
    {
        Task<List<Semester?>> GetSemesters();
        Task<Semester?> EditSemester(Semester model);

    }
}
