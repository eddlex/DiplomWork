using BackEnd.Services.Db;
using BackEnd.Services.Interfaces;
using Dapper;
using System.Data;
using BackEnd.Models.Input;
using BackEnd.Models.Output;
using static BackEnd.Helpers.Enums;

namespace BackEnd.Services.Services
{
    public class SmtpService : ISmtpService
    {
        private readonly DbService dbService;
        public SmtpService(IDbService dbService)
        {
            this.dbService = (DbService)dbService;
        }

        public async Task<bool> UpdateSmtpConfig(int PermissionId, SmtpConfigPut config)
        {
            using var connection = dbService.CreateConnection();
            var perm = await connection.ExecuteScalarAsync<int>("spGetPermission", new { PermissionId }, commandType: CommandType.StoredProcedure);

            if (perm != null && perm >= 3)
            {
                using var cmd = dbService.CreateCommand();
                cmd.CommandText = "spUpdateSmtpConfiguration";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", config.Id);
                cmd.Parameters.AddWithValue("DepartmentId", config.UniversityId);
                cmd.Parameters.AddWithValue("SmtpServer", config.SmtpServer);
                cmd.Parameters.AddWithValue("Port", config.Port);
                cmd.Parameters.AddWithValue("UserName", config.UserName);
                cmd.Parameters.AddWithValue("Password", config.Password);
                cmd.Parameters.AddWithValue("EnableSSL", config.EnableSSL);

                return await cmd.ExecuteNonQueryAsync() > 0;
            }
            return false;
        }

        public async Task<bool> DelSmtpConfig(int PermissionId, int id)
        {
            using var connection = dbService.CreateConnection();

            var perm = await connection.ExecuteScalarAsync<int>("spGetPermission", new { PermissionId }, commandType: CommandType.StoredProcedure);

            if (perm != null && perm == 7)
            {
                using var cmd = dbService.CreateCommand();
                cmd.CommandText = "spDeleteSmtpConfigurations";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", id);

                return await cmd.ExecuteNonQueryAsync() > 0;
            }
            return false;
        }

        public async Task<List<SmtpConfig>> GetSmtpConfig(int universityId)
        {
            using var connection = dbService.CreateConnection();

            return (List<SmtpConfig>)(await connection.QueryAsync<SmtpConfig>("spGetSmtpConfigurations", new { UniversityId = universityId }, commandType: CommandType.StoredProcedure));

        }
    }

    //public class SmtpConfig
    //{
    //    public int Id { get; set; }
    //    public int DepatmentId { get; }
    //    public string? SmtpServer { get; set; }
    //    public int Port { get; set; }
    //    public string? Username { get; set; }
    //    public string? Password { get; set; }
    //    public bool? EnableSSL { get; set; }
    //}
}
