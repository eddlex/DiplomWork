using BackEnd.Services.Configuration;
using System.Data.SqlClient;

namespace BackEnd.Services.Db
{

    public abstract class DbServiceBase : IDbService
    {
        private readonly IConfigurationService configurationService;

        public DbServiceBase(IConfigurationService configurationService)
        {
            this.configurationService = configurationService;
        }
        public string ConnectionString { get => this.configurationService.ConnectionString; set => throw new NotImplementedException(); }


        //public void CreateConnection()
        //{
        //    using (var connection = new SqlConnection(this.ConnectionString))
        //    {
        //        connection.Open();
        //    }
        //}

        public SqlCommand CreateCommand()
        {
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(string.Empty, connection))
                {
                    return command;
                }
            }

        }
    }
}
