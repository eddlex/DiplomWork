using BackEnd.Models.Input;
using BackEnd.Services.Db;
using BackEnd.Services.Interfaces;
using Dapper;
using System.Data;
using BackEnd.Helpers;
using BackEnd.Models.Output;
using FrontEnd.Helpers;
using Exception = FrontEnd.Helpers.Exception;

namespace BackEnd.Services.Services
{
    public class UniversityService : IUniversityService
    {
        private readonly DbService dbService;
        public UniversityService(IDbService dbService)
        {
            this.dbService = (DbService)dbService;
        }

        public async Task<List<University?>> GetUniversities()
        {
            var universities = (await dbService.QueryAsync<University>("spGetUniversities")).ToList();
          
            if (universities == null || !universities.Any())
                throw Exception.Create(Constants.Error.NotExistAnyUniversity);
            
            return universities;
        }

        public async Task<bool> AddUniversity(UniversityPost university)
        {
            using var cmd = dbService.CreateCommand();
            cmd.CommandText = "spAddUniversity";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Name", university.Name);
            cmd.Parameters.AddWithValue("@Description", university.Description);

            return Convert.ToBoolean(await cmd.ExecuteNonQueryAsync());
        }


        public async Task<bool> DelUniversity(int id)
        {
            using var cmd = dbService.CreateCommand();
            cmd.CommandText = "spDelUniversity";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", id);

            return Convert.ToBoolean(await cmd.ExecuteNonQueryAsync());
        }





    }
}
