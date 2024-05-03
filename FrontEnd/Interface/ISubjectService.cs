using BackEnd.Models.Input;
using FrontEnd.Model;
using FrontEnd.Model.BL;

namespace FrontEnd.Interface;

public interface ISubjectService
{
    public Task<List<SubjectBl>?> GetSubjects(int? departmentId = null);

    public Task<SubjectBl?> AddSubject(SubjectBl model);
    public Task<bool?> DelSubject(SubjectBl model);
    public Task<SubjectBl?> EditSubject(SubjectBl model);

    public Task<bool> EvaluateModel();

    public Task<bool> TrainModel();

    public Task<List<ScheduleBl>> GetSubjectsSchedulesCalculations();
    public Task<ScheduleBl> AddSubjectScheduleCalculation(ScheduleBl model);
    public Task<ScheduleBl> EditSubjectScheduleCalculation(ScheduleBl model);
    public Task<bool?> DeleteSubjectScheduleCalculation(ScheduleBl model);
    public Task<List<ScheduleRowBl>> GetSubjectsScheduleRow(int id);
    public Task<ScheduleRowBl> AddSubjectsScheduleRow(ScheduleRowBl model);
    public Task<bool?> DelSubjectsScheduleRow(ScheduleRowBl model);


}