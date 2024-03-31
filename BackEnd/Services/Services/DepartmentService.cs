using BackEnd.Models.Input;
using BackEnd.Services.Db;
using BackEnd.Services.Interfaces;
using Dapper;
using System.Data;
using BackEnd.Helpers;
using BackEnd.Models.Input.Put;
using BackEnd.Models.Output;
using FrontEnd.Helpers;

namespace BackEnd.Services.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly DbService dbService;
        public (int UserId, int DepartmentId, int RoleId) Token { get; set; }
        public DepartmentService(IDbService dbService,
                                 IHttpContextAccessor httpContextAccessor)
        {
            if (httpContextAccessor.HttpContext != null)
                this.Token = httpContextAccessor.HttpContext.User.ParseToken();
            this.dbService = (DbService)dbService;
        }

        public async Task<List<Department?>> GetDepartments()
        {
            var departments = (await dbService.QueryAsync<Department>("spGetDepartments")).ToList();
          
            if (departments == null || !departments.Any())
                throw Alert.Create(Constants.Error.NotExistAnyDepartment);
            
            return departments;
        }

        public async Task<Department?> AddDepartment(DepartmentPost department)
        {
            if (Token.RoleId != 2)
                Alert.Create(Constants.Error.WrongPermissions);

            var result =  (await this.dbService.QueryAsync<Department?>("spEditDepartment", department)).FirstOrDefault();
            if (result == null)
                Alert.Create(Constants.Error.SomethingWrong);
            return result;

        }
        
        public async Task<Department?> EditDepartment(DepartmentPut department)
        {
            if (Token.RoleId != 2)
                Alert.Create(Constants.Error.WrongPermissions);

            var result =  (await this.dbService.QueryAsync<Department?>("spEditDepartment", department)).FirstOrDefault();
            if (result == null)
                Alert.Create(Constants.Error.SomethingWrong);
            return result;

        }


        public async Task<bool> DelDepartment(int id)
        {
            if (Token.RoleId != 2)
                Alert.Create(Constants.Error.WrongPermissions);
            
            await using var cmd = dbService.CreateCommand();
            cmd.CommandText = "spDelDepartment";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", id);

            return Convert.ToBoolean(await cmd.ExecuteNonQueryAsync());
        }





    }
}
