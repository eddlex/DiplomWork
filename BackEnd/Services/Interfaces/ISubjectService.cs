﻿using BackEnd.Models.Input;
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
        Task<List<SubjectOptimized>> GetOptimizedHours(int sheduleId);
        string ExecutePythonScript(string scriptPath, string arguments);
        Task<List<bool>> TrainModel();
        Task<List<bool>> EvaluateModel();
        Task<List<Schedule?>> GetSubjectSchedules();
        Task<Schedule?> AddSubjectSchedules(SchedulePost model);
        Task<Schedule?> EditSubjectSchedules(SchedulePut model);
        
        Task<List<ScheduleRow?>> GetSubjectScheduleRows(int id);
        Task<ScheduleRow?> AddSubjectScheduleRow(ScheduleRowPost id);
        Task<bool> DeleteSubjectScheduleRow(ScheduleRowDelete model);
    }
}
