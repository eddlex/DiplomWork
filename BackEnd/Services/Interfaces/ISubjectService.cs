using BackEnd.Models.Input.Delete;
using BackEnd.Models.Input.Post;
using BackEnd.Models.Input.Put;
using BackEnd.Models.Output;

namespace BackEnd.Services.Interfaces
{
    public interface ISubjectService
    {
        Task<List<Subject>> GetSubjects(int? id);
        Task<Subject?> AddSubject(SubjectPost model);
        Task<bool?> DeleteSubject(SubjectDelete model);
        Task<Subject?> EditSubject(SubjectPut model);
        Task<List<SubjectOptimized>> GetOptimizedHours(int hours, List<int> ids);
        string ExecutePythonScript(string scriptPath, string arguments);
        Task<List<bool>> TrainModel();
        Task<List<bool>> EvaluateModel();
    }
}
