using FrontEnd.Model;

namespace FrontEnd.Interface;

public interface ISemesterService
{
    public Task<List<Semester?>> GetSemesters();
    public Task<Semester?> EditSemester(Semester model);

}