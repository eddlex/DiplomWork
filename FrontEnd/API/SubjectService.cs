using BackEnd.Models.Input;
using FrontEnd.Interface;
using FrontEnd.Model;
using FrontEnd.Model.BL;

namespace FrontEnd.API;

public class SubjectService : BaseService , ISubjectService
{
    public SubjectService(IHttpService httpService) : base(httpService, "Subject")
    {

    }
    public async Task<List<SubjectBl>?> GetSubjects(int? departmentId = null)
    {
        var result = await this.Get<SubjectBl>(departmentId);
        return result;
    }
    
    public async Task<SubjectBl?> AddSubject(SubjectBl model)
    {
        var result = await this.Add<SubjectBl, SubjectBl>(model);
        return result;
    }

    public async Task<bool?> DelSubject(SubjectBl model)
    {
        var result = await this.Delete<bool, SubjectBl>(model);
        return result;
    }

    public async Task<SubjectBl?> EditSubject(SubjectBl model)
    {
        var result = await this.Edit<SubjectBl, SubjectBl>(model);
        return result;
    }

    public async Task<bool> EvaluateModel()
    {
        var result = await this.Get<bool>(method: "Evaluate");
        return result.FirstOrDefault();
    }

    public async Task<bool> TrainModel()
    {
        var result = await this.Get<bool>(method: "Train");
        return result.FirstOrDefault();
    }
    
    public async Task<List<ScheduleRowBl>> ScheduleModel(int id)
    {
        var result = await this.Get<ScheduleRowBl>(id,  "Hours");
        return result;
    }
    
    
    
    public async Task<List<ScheduleBl>> GetSubjectsSchedulesCalculations()
    {
        var result = await this.Get<ScheduleBl>(method: "Schedule");
        return result;
    }
    
    public async Task<ScheduleBl> AddSubjectScheduleCalculation(ScheduleBl model)
    {
        var result = await this.Add<ScheduleBl, ScheduleBl>(model, method: "Schedule");
        return result;
    }

    public async  Task<ScheduleBl> EditSubjectScheduleCalculation(ScheduleBl model)
    {
        var result = await this.Edit<ScheduleBl, ScheduleBl>(model,  "Schedule");
            return result;
    }

    public async Task<bool?> DeleteSubjectScheduleCalculation(ScheduleBl model)
    {
        var result = await this.Delete<bool, ScheduleBl>(model,  "Schedule");
        return result;
    }

    public async Task<List<ScheduleRowBl>> GetSubjectsScheduleRow(int  id)
    {
        var result = await this.Get<ScheduleRowBl>(id,  "ScheduleRow");
        return result;
    }

    public async Task<ScheduleRowBl> AddSubjectsScheduleRow(ScheduleRowBl model)
    {
        var result = await this.Add<ScheduleRowBl, ScheduleRowBl>(model, method: "ScheduleRow");
        return result;
    }

    public async Task<bool?> DelSubjectsScheduleRow(ScheduleRowBl model)
    {
        var result = await this.Delete<bool?, ScheduleRowBl>(model,  "ScheduleRow");
        return result;
    }

  
    //public async Task<List<SubjectOptimized>?> GetOptimizedHours(int? hours = null , List<int> ids = null)
    //{
    //    var result = await this.Get<SubjectOptimized>(hours, ids);
    //    return result;
    //}
}