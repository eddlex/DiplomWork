using BackEnd.Models.Input;
using BackEnd.Services.Db;
using Dapper;
using System.Data;

namespace BackEnd.Services.University
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
            using var connection = this.dbService.CreateConnection();

            return (await connection.QueryAsync<Models.Output.University>("spGetUniversities", commandType: CommandType.StoredProcedure)).ToList();

        }

        public async Task<bool> DelUniversities(int id)
        {
            using var cmd = this.dbService.CreateCommand();
            cmd.CommandText = "spDelUniversity";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", id);

            return Convert.ToBoolean(await cmd.ExecuteNonQueryAsync());
        }
    }
}
