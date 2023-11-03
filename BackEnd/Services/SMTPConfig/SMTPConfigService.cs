using BackEnd.Models.Input;
using BackEnd.Models.Output;
using BackEnd.Services.Db;
using System.Data;

namespace BackEnd.Services.SMTPConfig
{
    public class SMTPConfigService : ISMTPConfigService
    {
        private readonly DbService dbService;
        public SMTPConfigService(IDbService dbService)
        {
            this.dbService = (DbService)dbService;
        }

        public async Task<SMTPConfig> GetConfig(int ConfigId)
        {
            var cmd = this.dbService.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spGetSmtpConfigurations";

            cmd.Parameters.AddWithValue("ConfigId", ConfigId);

            using var reader = await cmd.ExecuteReaderAsync();
            var result = new SMTPConfig();

            if (await reader.ReadAsync())
            {
                result.SmtpServer = reader["SmtpServer"].ToString();
                result.Port = Convert.ToInt32(reader["Port"]);
                result.Username = reader["Username"].ToString();
                result.Password = reader["Password"].ToString();
                result.EnableSSL = (bool)reader["EnableSSL"];

                reader.Close();
            }

            return result;
        }

        public async Task<bool> UpdateSMTPConfig(int ConfigId, SMTPConfig config)
        {
            using var cmd = this.dbService.CreateCommand();
            cmd.CommandText = "spUpdateAllSmtpConfiguration";
            cmd.CommandType = CommandType.StoredProcedure;
     
            cmd.Parameters.AddWithValue("ConfigId", ConfigId);
            cmd.Parameters.AddWithValue("NewSmtpServer", config.SmtpServer);
            cmd.Parameters.AddWithValue("NewPort", config.Port);
            cmd.Parameters.AddWithValue("NewUsername", config.Username);
            cmd.Parameters.AddWithValue("NewPassword", config.Password);
            cmd.Parameters.AddWithValue("NewEnableSSL", config.EnableSSL);

            return (await cmd.ExecuteNonQueryAsync()) > 0;
        }

        public async Task<bool> DelSMTPConfig(int ConfigId)
        {
            using var cmd = this.dbService.CreateCommand();
            cmd.CommandText = "spDeleteSmtpConfigurations";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("ConfigId", ConfigId);

            return (await cmd.ExecuteNonQueryAsync()) > 0;
        }
    }

    public class SMTPConfig
    {
        public int Id { get; }
        public string? SmtpServer { get; set; }
        public int Port { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public bool? EnableSSL { get; set; }
    }
}
