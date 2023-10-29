using BackEnd.Services.Configuration;
using System.Data.SqlClient;

namespace BackEnd.Services.Db
{
    public class DbService : DbServiceBase
    {
        private new readonly string ConectionString;

        public DbService(IConfigurationService configurationService) : base(configurationService)
        {
            this.ConectionString =  this.ConnectionString;
        }


        public SqlConnection CreateConnection()
        {
            var connection = new SqlConnection(this.ConnectionString);
            
            connection.Open();
            return connection;
          
        }

    }
}
