using BackEnd.Services.Db;
using System.Data;
using BackEnd.Helpers;
using Dapper;
using BackEnd.Models.Input;
using BackEnd.Services.Interfaces;
using BackEnd.Models.Output;
using FrontEnd.Helpers;

namespace BackEnd.Services.Services
{
    public class SemesterService : ISemesterService
    {
        private readonly DbService dbService;

        public (int UserId, int DepartmentId, int RoleId) Token { get; set; }

        public SemesterService(IDbService dbService,
                                IHttpContextAccessor httpContextAccessor)
        {
            this.dbService = (DbService)dbService;
            if (httpContextAccessor.HttpContext != null)
                this.Token = httpContextAccessor.HttpContext.User.ParseToken();
        }

        public async Task<List<Semester>> GetSemesters()
        {
            var res = (await dbService.QueryAsync<Semester>("spGetSemesters", new { })).ToList();
            return res;
        }
        
        public async Task<Semester?> EditSemester(Semester model)
        {

            var res = (await dbService.QueryAsync<Semester>("spEditSemester",
                new
                {
                    model.Id,
                    model.Name,
                    model.Hours
                })).FirstOrDefault();

            if (res == default)
                throw Alert.Create(Constants.Error.SomethingWrong);
            return res;
        }
    }
}
