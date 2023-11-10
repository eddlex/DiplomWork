using BackEnd.Services.Db;
using System.Data;

namespace BackEnd.Services.SMTPConfig
{
    public class SmtpService : ISmtpService
    {
        private readonly DbService dbService;
        public SmtpService(IDbService dbService)
        {
            this.dbService = (DbService)dbService;
        }

        public async Task<SmtpConfig> GetSmtpConfig(int id)
        {
            var cmd = this.dbService.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spGetSmtpConfigurations";

            cmd.Parameters.AddWithValue("Id", id);

            using var reader = await cmd.ExecuteReaderAsync();
            var result = new SmtpConfig();

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

        public async Task<bool> UpdateSmtpConfig(SmtpConfig config)
        {
            using var cmd = this.dbService.CreateCommand();
            cmd.CommandText = "spUpdateSmtpConfiguration";
            cmd.CommandType = CommandType.StoredProcedure;
     
            cmd.Parameters.AddWithValue("Id", config.Id);
            cmd.Parameters.AddWithValue("SmtpServer", config.SmtpServer);
            cmd.Parameters.AddWithValue("Port", config.Port);
            cmd.Parameters.AddWithValue("Username", config.Username);
            cmd.Parameters.AddWithValue("Password", config.Password);
            cmd.Parameters.AddWithValue("EnableSSL", config.EnableSSL);

            return (await cmd.ExecuteNonQueryAsync()) > 0;
        }

        public async Task<bool> DelSmtpConfig(int ConfigId)
        {
            using var cmd = this.dbService.CreateCommand();
            cmd.CommandText = "spDeleteSmtpConfigurations";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("Id", ConfigId);

            return (await cmd.ExecuteNonQueryAsync()) > 0;
        }
    }

    public class SmtpConfig
    {
        public int Id { get; set; }
        public int UniversityId { get; }
        public string? SmtpServer { get; set; }
        public int Port { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public bool? EnableSSL { get; set; }
    }
}
