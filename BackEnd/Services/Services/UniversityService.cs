using BackEnd.Models.Input;
using BackEnd.Services.Db;
using BackEnd.Services.Interfaces;
using Dapper;
using System.Data;

namespace BackEnd.Services.Services
{
    public class UniversityService : IUniversityService
    {
        private readonly DbService dbService;
        public UniversityService(IDbService dbService)
        {
            this.dbService = (DbService)dbService;
        }

        public async Task<List<Models.Output.University>> GetUniversities()
        {
            using var connection = dbService.CreateConnection();

            return (await connection.QueryAsync<Models.Output.University>("spGetUniversities", commandType: CommandType.StoredProcedure)).ToList();

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
