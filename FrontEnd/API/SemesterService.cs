using System.Runtime.CompilerServices;
using FrontEnd.Helpers;
using FrontEnd.Interface;
using FrontEnd.Model;
using FrontEnd.Pages;

namespace FrontEnd.API;

public class SemesterService :  BaseService, ISemesterService
{
    public SemesterService(IHttpService httpService) : base(httpService, "Semester")
    {
    }
    public async Task<List<Semester>?> GetSemesters()
    {
       var semesters =  await this.Get<Semester>();
       if (semesters is null or { Count: 0 })
       {
           throw Helpers.Alert.Create(Constants.Error.NotExistAnyDepartment);
       }

       return semesters;
    }

    public async Task<Semester?> EditSemester(Semester model)
    {
        var result = await this.Edit<Semester?, Semester>(model);
        return result;
    }
}



