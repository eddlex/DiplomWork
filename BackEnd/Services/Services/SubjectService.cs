using BackEnd.Services.Db;
using System.Data;
using BackEnd.Helpers;
using Dapper;
using BackEnd.Models.Input;
using BackEnd.Models.Input.Delete;
using BackEnd.Models.Input.Post;
using BackEnd.Models.Input.Put;
using BackEnd.Services.Interfaces;
using BackEnd.Models.Output;
using FrontEnd.Helpers;

namespace BackEnd.Services.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly DbService dbService;

        public (int UserId, int DepartmentId, int RoleId) Token { get; set; }

        public SubjectService(IDbService dbService,
            IHttpContextAccessor httpContextAccessor)
        {
            this.dbService = (DbService)dbService;
            if (httpContextAccessor.HttpContext != null)
                this.Token = httpContextAccessor.HttpContext.User.ParseToken();
        }

        public async Task<List<Subject>> GetSubjects(int? id)
        {
            if (Token.RoleId < 2 && id != Token.DepartmentId)
                throw Alert.Create(Constants.Error.WrongPermissions);
            var res = (await dbService.QueryAsync<Subject>("spGetSubjects", new { RoleId = Token.RoleId, DepartmentId = id }))
                .ToList();
            return res;
        }
        
        public async Task<Subject?> AddSubject(SubjectPost model)
        {
            var res = await dbService.QueryAsync<Subject>("spAddSubject", model);
            return res.FirstOrDefault();
        }

        public async Task<bool?> DeleteSubject(SubjectDelete model)
        {
            if (Token.DepartmentId != model.DepartmentId && Token.RoleId < 2)
                throw Alert.Create(Constants.Error.WrongPermissions);

            var res = await dbService.QueryAsync<bool?>("spDeleteSubject", new { Id = model.Id });
            return res.FirstOrDefault();
        }

        public async Task<Subject?> EditSubject(SubjectPut model)
        {
            var res = (await dbService.QueryAsync<Subject>("spEditSubject", model)).FirstOrDefault();
            return res;
        }


    }
}
